using SQLitePCL;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WordleClient.libraries.CustomControls;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.network;
using WordleClient.libraries.StateFrom;
namespace WordleClient.views
{
    public partial class MultiPlayground : Form
    {
        /* ============================================================
         * SHARED ATTRIBUTES
         * ============================================================ */
        private int rows; // literally readonly
        private int cols; // literally readonly
        private int streak = 0;
        private int lives = 3;
        private Panel matrixPanel; // literally readonly
        private Panel? keyboardPanel;
        private readonly Dictionary<char, CharBox> keyboardKeys = [];
        private const int boxSize = 60;
        private const int spacing = 6;
        private string currentString = string.Empty;
        private bool GameEnded = false;
        private int HintRemaining;
        private int GameSeed;
        private bool inputLocked = false;
        private int currentRow = 0;
        private int currentCol = 0;
        private DictionaryChecker dictionaryChecker;
        private readonly bool isServer;
        private int NumOfPlayers; // Since clients cannot use GameRoom, they get it here
        private readonly string PlayerName;
        private List<GameStatus> FinishedPlayers;

        /* ============================================================
         * GUARDS
         * ============================================================ */
        private bool _forceClose = false;
        private bool _serverCleanupDone = false;
        private bool _clientCleanupDone = false;

        /* ============================================================
         * CLIENT-USAGE ONLY ATTRIBUTES
         * ============================================================ */
        private readonly SemaphoreSlim _requestLock = new(1, 1);
        private TaskCompletionSource<Hint>? _hintWaiter = null;
        private TaskCompletionSource<StateArray>? _resultWaiter = null;
        private TaskCompletionSource<GameStatus>? _finishedConfirmWaiter = null;
        private CancellationTokenSource _disconnectCts = new();

        /* ============================================================
         * SERVER-USAGE ONLY ATTRIBUTES
         * ============================================================ */
        private GameInstance? gameInstance = null;
        private string? LastToken = null;

        /* ============================================================
         * CLIENT-USAGE ONLY METHODS
         * ============================================================*/
        private async Task<Hint> RequestHintAsync(int seed)
        {
            if (isServer)
                throw new InvalidOperationException();

            await _requestLock.WaitAsync();
            try
            {
                _hintWaiter = new TaskCompletionSource<Hint>(
                    TaskCreationOptions.RunContinuationsAsynchronously);

                await PacketConnectionManager.SendAsync(
                    new SEND_HINT_REQUEST_Packet(PlayerName, seed, PlayerName, "Server"));

                using var timeoutCts = new CancellationTokenSource(3000);

                var completed = await Task.WhenAny(
                    _hintWaiter.Task,
                    Task.Delay(Timeout.Infinite, timeoutCts.Token));

                if (completed != _hintWaiter.Task)
                    throw new TimeoutException();

                timeoutCts.Cancel();
                return await _hintWaiter.Task;
            }
            finally
            {
                _hintWaiter = null;
                _requestLock.Release();
            }
        }
        private async Task<StateArray> RequestResultAsync(string guess)
        {
            if (isServer)
                throw new InvalidOperationException("Server should not call client async requests.");

            await _requestLock.WaitAsync();
            try
            {
                _resultWaiter = new TaskCompletionSource<StateArray>(
                    TaskCreationOptions.RunContinuationsAsynchronously);

                await PacketConnectionManager.SendAsync(
                    new SEND_GUESS_Packet(guess, PlayerName, "Server"));

                using var timeoutCts = new CancellationTokenSource(3000);

                var completed = await Task.WhenAny(
                    _resultWaiter.Task,
                    Task.Delay(Timeout.Infinite, timeoutCts.Token));

                if (completed != _resultWaiter.Task)
                    throw new TimeoutException("Result request timed out.");

                timeoutCts.Cancel();
                return await _resultWaiter.Task;
            }
            finally
            {
                _resultWaiter = null;
                _requestLock.Release();
            }
        }
        private async Task<GameStatus> SendFinishedSignal(GameStatus gs)
        {
            if (isServer)
                throw new InvalidOperationException("Server should not call client async requests.");

            await _requestLock.WaitAsync();
            try
            {
                _finishedConfirmWaiter = new TaskCompletionSource<GameStatus>(
                    TaskCreationOptions.RunContinuationsAsynchronously);

                await PacketConnectionManager.SendAsync(
                    new GAME_STATUS_UPDATE_REQUEST_Packet(gs, PlayerName, "Server"));

                using var timeoutCts = new CancellationTokenSource(3000);

                var completed = await Task.WhenAny(
                    _finishedConfirmWaiter.Task,
                    Task.Delay(Timeout.Infinite, timeoutCts.Token));

                if (completed != _finishedConfirmWaiter.Task)
                    throw new TimeoutException("Finish confirmation timed out.");

                timeoutCts.Cancel();
                return await _finishedConfirmWaiter.Task;
            }
            finally
            {
                _finishedConfirmWaiter = null;
                _requestLock.Release();
            }
        }

        /* ============================================================
         * SERVER-USAGE ONLY NETWORK EVENT HANDLERS
         * ============================================================ */
        private void OnServerPacket(PacketConnection conn, Packet packet)
        {
            if (!isServer || gameInstance == null)
                return;

            // JOIN requests must be handled immediately (no UI involved)
            if (packet is JOIN_REQUEST_Packet reeq)
            {
                Debug.WriteLine($"Received a JOIN REQUEST FROM {reeq.Sender}");

                ServerManager.SendTo(
                    conn,
                    new JOIN_APPROVAL_RESPONSE_Packet(
                        $"{reeq.Username}|The game has started, you cannot join.",
                        false,
                        PlayerName));

                return;
            }

            if (!GameRoom.HasPlayer(packet.Sender))
                return;

            switch (packet)
            {
                case SEND_HINT_REQUEST_Packet req:
                    {
                        Hint hint = HintGetter.GetHint(
                            gameInstance.GetToken(),
                            req.Seed);

                        ServerManager.SendTo(
                            conn,
                            new HINT_RESPONSE_Packet(
                                hint,
                                "Server",
                                req.Sender));
                        break;
                    }

                case SEND_GUESS_Packet req:
                    {
                        StateArray result = gameInstance.EvaluateGuess(req.Guess);

                        ServerManager.SendTo(
                            conn,
                            new GUESS_RESULT_Packet(
                                result,
                                "Server",
                                req.Sender));
                        break;
                    }

                case GAME_STATUS_UPDATE_REQUEST_Packet req:
                    {
                        Debug.WriteLine($"Received payload! Payload requested to add {req.GS.Username}");

                        // Marshal UI work to UI thread
                        if (IsDisposed)
                            return;

                        BeginInvoke(new Action(() =>
                        {
                            if (IsDisposed)
                                return;

                            if (!FinishedPlayers.Any(f => f.Username == req.GS.Username))
                            {
                                FinishedPlayers.Add(req.GS);
                            }

                            UpdateFinishedPlayerList(FinishedPlayers);
                            //UpdateRestartButtonVisibility();
                        }));

                        // Network broadcast can stay on background thread
                        ServerManager.Broadcast(
                            new GAME_STATUS_UPDATE_RESPONSE_Packet(
                                req.GS, "Server", "All"));

                        break;
                    }
            }
        }

        private void OnClientDisconnectedUI(string ip)
        {
            BeginInvoke(() =>
            {
                RestartGameBtn.Visible = true;

                NumOfPlayers = GameRoom.NumPlayers;

                UpdateCurrentPlayerList(GameRoom.SerializePlayers());
                ServerManager.Broadcast(
                new PLAYER_LIST_SYNC_Packet(
                    GameRoom.SerializePlayers(),
                    "Server",
                    "All"));
            });
        }

        /* ============================================================
         * CLIENT-USAGE ONLY NETWORK EVENT HANDLERS
         * ============================================================ */
        private void OnPacketReceived(Packet packet)
        {
            if (_clientCleanupDone)
                return;

            BeginInvoke(() =>
            {
                switch (packet)
                {
                    case HINT_RESPONSE_Packet resp:
                        {
                            _hintWaiter?.TrySetResult(resp.Hint);
                            break;
                        }

                    case GUESS_RESULT_Packet resp:
                        {
                            _resultWaiter?.TrySetResult(resp.SA);
                            break;
                        }

                    case GAME_STATUS_UPDATE_RESPONSE_Packet resp:
                        {
                            Debug.WriteLine($"Added {resp.GS.Username} to finished players.");
                            _finishedConfirmWaiter?.TrySetResult(resp.GS);

                            if (!FinishedPlayers.Any(f => f.Username == resp.GS.Username))
                            {
                                FinishedPlayers.Add(resp.GS);
                            }

                            UpdateFinishedPlayerList(FinishedPlayers);
                            break;
                        }

                    case SERVER_SHUTDOWN_Packet:
                        {
                            _forceClose = true;

                            MessageBox.Show(
                                "Server has shutdown.",
                                "Server shutdown",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            CleanupClientOnce();
                            this.Close();

                            break;
                        }

                    case PLAYER_LIST_SYNC_Packet list:
                        {
                            NumOfPlayers = list.Players.Count;
                            UpdateCurrentPlayerList(list.Players);
                            break;
                        }

                    case START_GAME_Packet resp:
                        {
                            ResetGame(new WDBRecord_Simplified(
                                resp.WordLength,
                                resp.Topic,
                                resp.Level
                                ));
                            break;
                        }

                }
            });
        }
        private void OnDisconnected()
        {
            BeginInvoke(() =>
            {
                if (_clientCleanupDone)
                    return;

                _forceClose = true;

                MessageBox.Show(
                    "Disconnected from server.",
                    "Disconnected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                CleanupClientOnce();
                this.Close();
            });
        }

        /* ============================================================
         * SHARED BASE CONSTRUCTOR
         * ============================================================ */
        private void BaseConstructor(WDBRecord_Simplified TheChosenOne, int MaxGuessCount, int GameSeed)
        {
            InitializeComponent();

            this.rows = MaxGuessCount;
            this.cols = TheChosenOne.TOKEN_LENGTH;
            this.GameSeed = GameSeed;
            lbl_Diff.Text = TheChosenOne.LEVEL;
            lbl_Tpc.Text = TheChosenOne.GROUP_NAME;
            this.HintRemaining = 2;
            LoadHearts();
            this.matrixPanel = new Panel
            {
                BackColor = Color.Transparent,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                TabIndex = 3
            };
            this.panel2.Controls.Add(matrixPanel);
            lbl_Diff.Text = TheChosenOne.LEVEL;
            lbl_Tpc.Text = TheChosenOne.GROUP_NAME.Replace("&", "And");
            lbl_HintRemaining.Text = HintRemaining.ToString();
            CreateMatrix();
            CenterMatrix();
            BuildKeyboard();
            PositionKeyboard();
            this.KeyPreview = true;
            this.KeyPress += Playground_KeyPress;
            this.Resize += (s, e) =>
            {
                CenterMatrix();
                PositionKeyboard();
            };
            this.panel2.Resize += (s, e) =>
            {
                CenterMatrix();
                PositionKeyboard();
            };
        }

        /* ============================================================
         * FORM LOADING EVENT
         * ============================================================ */
        private void Playground_Load_Client(object? sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            btn_DarkLight.Image = CustomDarkLight.IsDark ? Properties.Resources.Dark : Properties.Resources.Light;
            btn_DarkLight.boderGradientBottom1 = CustomDarkLight.IsDark ? Color.FromArgb(40, 40, 40) : Color.FromArgb(220, 220, 220);
            btn_DarkLight.boderGradientTop1 = CustomDarkLight.IsDark ? Color.FromArgb(40, 40, 40) : Color.FromArgb(240, 240, 240);
            UpdateCustomGroupBoxTheme();
            customPictureBox1.Image = ProfileState.GetAvatar();

            string nickname = (ProfileState.Current == null)
                ? "Player"
                : ProfileState.Current.Nickname
                ?? "Player";

            new AlertBox(
                3000, CustomDarkLight.IsDark)
                .ShowAlert(this,
                "Welcome", $"Welcome to Playground, {nickname}!",
                MessageBoxIcon.None);

            CustomSound.PlayClickAlert();
            label8.Text = nickname;
        }
        private async void Playground_Load_Server(object? sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            btn_DarkLight.Image = CustomDarkLight.IsDark ? Properties.Resources.Dark : Properties.Resources.Light;
            btn_DarkLight.boderGradientBottom1 = CustomDarkLight.IsDark ? Color.FromArgb(40, 40, 40) : Color.FromArgb(220, 220, 220);
            btn_DarkLight.boderGradientTop1 = CustomDarkLight.IsDark ? Color.FromArgb(40, 40, 40) : Color.FromArgb(240, 240, 240);
            UpdateCustomGroupBoxTheme();
            customPictureBox1.Image = ProfileState.GetAvatar();

            string nickname =
                (ProfileState.Current == null)
                ? "Player"
                : ProfileState.Current.Nickname
                ?? "Player";

            new AlertBox(
                3000, CustomDarkLight.IsDark)
                .ShowAlert(this,
                "Welcome", $"Welcome to Playground, {nickname}!",
                MessageBoxIcon.None);

            CustomSound.PlayClickAlert();
            label8.Text = nickname;

            await Task.Delay(1500);
            ServerManager.Broadcast(
                new PLAYER_LIST_SYNC_Packet(
                    GameRoom.SerializePlayers(),
                    "Server",
                    "All"));
        }

        /* ============================================================
         * EXIT CLICK EVENT
         * ============================================================ */
        private void ExitBtn_Click_Server(object? sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Close();
        }
        private void ExitBtn_Click_Client(object? sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Close();
        }

        /* ============================================================
         * CLEANUPS HELPERS
         * ============================================================ */
        private void CleanupClientOnce()
        {
            if (_clientCleanupDone)
                return;

            _clientCleanupDone = true;

            _disconnectCts.Cancel();

            _hintWaiter?.TrySetCanceled();
            _resultWaiter?.TrySetCanceled();
            _finishedConfirmWaiter?.TrySetCanceled();

            PacketConnectionManager.PacketReceived -= OnPacketReceived;
            PacketConnectionManager.Disconnected -= OnDisconnected;

            PacketConnectionManager.Disconnect();
        }
        private void CleanupServerOnce()
        {
            if (_serverCleanupDone)
                return;

            _serverCleanupDone = true;

            ServerManager.ServerPacketReceived -= OnServerPacket;
            ServerManager.ClientDisconnected -= OnClientDisconnectedUI;

            ServerManager.Broadcast(
                new SERVER_SHUTDOWN_Packet("Server", "All"));

            ServerManager.Stop();

            dictionaryChecker.Dispose();
            gameInstance?.Dispose();

            GameRoom.Dispose();
        }

        /* ============================================================
         * THE EXIT PROMPTS
         * ============================================================ */
        private void Playground_FormClosing_Client(object? sender, FormClosingEventArgs e)
        {
            // Prompt only for user-initiated close
            if (!_forceClose && e.CloseReason == CloseReason.UserClosing)
            {
                if (CustomMessageBoxYesNo.Show(
                    this,
                    "Are you sure you want to exit?",
                    MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            CleanupClientOnce();
        }
        private void Playground_FormClosing_Server(object? sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("[SERVER] Playground_FormClosing_Server fired");

            if (!_forceClose)
            {
                if (CustomMessageBoxYesNo.Show(
                    this,
                    "Stop the server and exit? Everyone else will be kicked!",
                    MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                _forceClose = true;
            }

            CleanupServerOnce();
        }

        /* ============================================================
         * CONSTRUCTORS FOR CLIENTS
         * ============================================================ */
        public MultiPlayground(WDBRecord_Simplified TheChosenOne, int MaxGuessCount, int GameSeed, int NumPlayers)
        {
            isServer = false;
            this.dictionaryChecker = new(TheChosenOne.TOKEN_LENGTH);
            this.NumOfPlayers = NumPlayers;
            this.PlayerName = ProfileState.GetPlayername();
            this.FinishedPlayers = [];

            BaseConstructor(TheChosenOne, MaxGuessCount, GameSeed);
            this.Load += Playground_Load_Client;

            RestartGameBtn.Visible = false;

            this.FormClosing += Playground_FormClosing_Client;
            this.ExitBtn.Click += ExitBtn_Click_Client;

            PacketConnectionManager.PacketReceived += OnPacketReceived;
            PacketConnectionManager.Disconnected += OnDisconnected;
        }

        /* ============================================================
         * CONSTRUCTORS FOR SERVER
         * ============================================================ */
        public MultiPlayground(WDBRecord TheChosenOne, int MaxGuessCount, int GameSeed, int NumPlayers)
        {
            isServer = true;
            this.dictionaryChecker = new(TheChosenOne.TOKEN.Length);
            this.NumOfPlayers = NumPlayers;
            this.PlayerName = ProfileState.GetPlayername();
            this.FinishedPlayers = [];

            this.gameInstance = new(TheChosenOne);
            this.LastToken = TheChosenOne.TOKEN;

            BaseConstructor(
                new WDBRecord_Simplified(
                    TheChosenOne.TOKEN.Length, TheChosenOne.GROUP_NAME, TheChosenOne.LEVEL),
                    MaxGuessCount, GameSeed);
            this.Load += Playground_Load_Server;

            UpdateCurrentPlayerList(GameRoom.SerializePlayers());
            //RestartGameBtn.Visible = false;

            this.FormClosing += Playground_FormClosing_Server;
            this.ExitBtn.Click += ExitBtn_Click_Server;

            ServerManager.ServerPacketReceived += OnServerPacket;
            ServerManager.ClientDisconnected += OnClientDisconnectedUI;

        }

        /* ============================================================
         * REDIRECT TO MAINMENU
         * ============================================================ */
        private void MultiPlayground_FormClosed(object sender, FormClosedEventArgs e)
        {
            var main = Application.OpenForms.OfType<MainMenu>().FirstOrDefault();
            if (main != null)
            {
                main.Show();
                CustomSound.PlayBackgroundLoop();
            }
        }

        /* ============================================================
         * GAME RESET
         * ============================================================ */
        private void ResetGame(WDBRecord_Simplified TheChosenOne)
        {
            dictionaryChecker.Dispose();
            dictionaryChecker = new(TheChosenOne.TOKEN_LENGTH);

            FinishedPlayers.Clear();
            listFinishedPlayers.Items.Clear();

            inputLocked = false;
            GameEnded = false;
            currentRow = 0;
            currentCol = 0;
            HintRemaining = 2;
            lives = 3;

            lbl_HintRemaining.Text = "2";
            lbl_Hint1_Placeholder.Text = "Unknown";
            lbl_Hint2_Placeholder.Text = "Unknown";

            LoadHearts();

            GetHintBtn.Visible = true;
            lbl_Diff.Text = TheChosenOne.LEVEL;
            lbl_Tpc.Text = TheChosenOne.GROUP_NAME.Replace("&", "And");
            cols = TheChosenOne.TOKEN_LENGTH;
            CreateMatrix();
            CenterMatrix();
            BuildKeyboard();
            PositionKeyboard();
            matrixPanel.Refresh();
            ThemeManager.ApplyTheme(this);
            this.Refresh();
        }

        /* ============================================================
         * GUI INITIALISE
         * ============================================================ */
        private void CreateMatrix()
        {
            matrixPanel.Controls.Clear();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    CharBox box = new()
                    {
                        Size = new Size(boxSize, boxSize),
                        Location = new Point(
                            j * (boxSize + spacing),
                            i * (boxSize + spacing))
                    };

                    box.SetCharacter('-');
                    matrixPanel.Controls.Add(box);
                }
            }

            currentRow = 0;
            currentCol = 0;
            currentString = GetRowString(0);
            UpdateCursorIndicator();
        }
        private void CenterMatrix()
        {
            int panelWidth = cols * (boxSize + spacing) - spacing;
            int panelHeight = rows * (boxSize + spacing) - spacing;

            matrixPanel.Location = new Point(
                (panel2.Width - panelWidth) / 2,
                (panel2.Height - panelHeight) / 2 - 80);
        }
        private void BuildKeyboard()
        {
            if (keyboardPanel != null)
                panel2.Controls.Remove(keyboardPanel);

            keyboardPanel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            panel2.Controls.Add(keyboardPanel);
            keyboardKeys.Clear();

            string[] keyRows = [
                "QWERTYUIOP",
                "ASDFGHJKL",
                "ZXCVBNM"
            ];

            int keySize = 40;
            int keySpace = 6;
            int top = 0;

            foreach (string row in keyRows)
            {
                int left = (panel2.Width - (row.Length * (keySize + keySpace))) / 2;
                foreach (char c in row)
                {
                    CharBox key = new()
                    {
                        Size = new Size((int)(keySize * 1), keySize),
                        Location = new Point(left, top),
                        BackColor = Color.LightGray
                    };
                    key.SetCharacter(c);
                    key.Click += (s, e) => OnVirtualKeyPress(c);
                    keyboardPanel.Controls.Add(key);
                    keyboardKeys[c] = key;
                    left += keySize + keySpace;
                }
                top += keySize + keySpace;
            }
        }
        private void PositionKeyboard()
        {
            if (keyboardPanel == null)
                return;

            keyboardPanel.Location = new Point(
                (panel2.Width - keyboardPanel.Width) / 2,
                matrixPanel.Bottom + 30);
        }

        /* ============================================================
         * PLAYER-LISTS UPDATE
         * ============================================================ */
        private void UpdateCurrentPlayerList(List<string> AllPlayers)
        {

            listPlayers.Items.Clear();
            string? tmpServerUsername = null;
            foreach (string raw in AllPlayers)
            {
                Player p = Player.Parse(raw);

                tmpServerUsername ??= p.Username;

                if (p.Username == tmpServerUsername)
                    listPlayers.Items
                        .Add($"HOST: {p.Username}{(PlayerName == p.Username
                            ? " (YOU)"
                            : String.Empty)}");
                else
                    listPlayers.Items
                        .Add($"{p.Username}{(PlayerName == p.Username
                            ? " (YOU)"
                            : String.Empty)}");
            }
        }
        private void UpdateFinishedPlayerList(List<GameStatus> allPlayers)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateFinishedPlayerList(allPlayers)));
                return;
            }

            listFinishedPlayers.Items.Clear();

            foreach (var p in allPlayers)
                listFinishedPlayers.Items.Add($"{p.Username} - {(p.IsWin ? "SOLVED" : "FAILED")}");
        }

        /* ============================================================
         * MISCELLANEOUS UI GETTERS AND SETTERS
         * ============================================================ */
        private CharBox? GetBox(int r, int c)
        {
            int index = r * cols + c;
            if (index < 0 || index >= matrixPanel.Controls.Count)
                return null;
            return
                matrixPanel.Controls[index]
                as CharBox;
        }
        private string GetRowString(int row)
        {
            StringBuilder sb = new();
            for (int c = 0; c < cols; c++)
            {
                var b = GetBox(row, c);
                if (b == null) continue;
                var ch = b.Character;
                if (!string.IsNullOrEmpty(ch)
                    && ch != "-" && ch != "\0")
                    sb.Append(ch[0]);
            }
            return sb.ToString();
        }
        private static bool IsBoxEmpty(CharBox box)
        {
            if (box == null) return true;
            return string
                .IsNullOrEmpty(box.Character)
                || box.Character == "-"
                || box.Character == "\0";
        }
        private bool IsRowFilled(int row)
        {
            for (int c = 0; c < cols; c++)
            {
                var b = GetBox(row, c);
                if (b == null || IsBoxEmpty(b))
                    return false;
            }
            return true;
        }
        private void UpdateKeyboardColors(StateArray? result, Hint? hintData)
        {
            if (result == null && hintData == null) return;
            if (result != null && hintData == null)
            {
                for (int col = 0; col < result.Length; col++)
                {
                    char c = currentString[col];
                    char up = char.ToUpper(c);
                    if (!keyboardKeys.ContainsKey(up)) continue;
                    var key = keyboardKeys[up];
                    switch (result.Get(col))
                    {
                        case TriState.MATCH:
                            key.SetBackgroundColor(
                                Color.FromArgb(0x53, 0x8D, 0x4E));
                            break;
                        case TriState.INVALID_ORDER:
                            if (key.BackColor !=
                                Color.FromArgb(0x53, 0x8D, 0x4E))
                                key.SetBackgroundColor(
                                    Color.FromArgb(0xB5, 0x9F, 0x3B));
                            break;
                        case TriState.NOT_EXIST:
                            if (key.BackColor !=
                                Color.FromArgb(0x53, 0x8D, 0x4E)
                                && key.BackColor !=
                                Color.FromArgb(0xB5, 0x9F, 0x3B))
                                key.SetBackgroundColor(
                                    Color.FromArgb(0x3A, 0x3A, 0x3C));
                            break;
                    }
                }
            }
            else if (result == null && hintData != null)
            {
                if (hintData.h_type == HintType.Present && hintData.pre_letter != null)
                {
                    char c = (char)hintData.pre_letter;
                    char up = char.ToUpper(c);
                    var key = keyboardKeys[up];
                    if (key.BackColor != Color.FromArgb(0x53, 0x8D, 0x4E))
                        key.SetBackgroundColor(
                            Color.FromArgb(0xB5, 0x9F, 0x3B));
                }
                else
                {
                    char[] greyedOut =
                        (hintData.abs_type == AbsentType.VOWEL)
                        ? ['A', 'E', 'I', 'O', 'U']
                        : ['B', 'C', 'D', 'F', 'G',
                           'H', 'J', 'K', 'L', 'M',
                           'N', 'P', 'Q', 'R', 'S',
                           'T', 'V', 'W', 'X', 'Y',
                           'Z'];

                    foreach (char c in greyedOut)
                        keyboardKeys[c]
                            .SetBackgroundColor(
                            Color.FromArgb(0x3A, 0x3A, 0x3C));
                }
            }
        }

        /* ============================================================
         * PLAYER INPUTS
         * ============================================================ */
        private async void GetHintBtn_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            if (GameEnded)
            {
                new AlertBox(
                    750, CustomDarkLight.IsDark)
                    .ShowAlert(this,
                    "Get Hint", "Your game has ended.",
                    MessageBoxIcon.Warning);
                return;
            }

            if (HintRemaining <= 0)
            {
                new AlertBox(
                    750, CustomDarkLight.IsDark)
                    .ShowAlert(this,
                    "Get Hint", "No more hints.",
                    MessageBoxIcon.Warning);
                return;
            }

            Hint? hintObject = null;

            if (isServer && gameInstance != null)
            {
                hintObject = HintGetter.GetHint(
                    gameInstance.GetToken(),
                    HintRemaining + GameSeed);
            }
            else
            {
                try
                {
                    hintObject = await RequestHintAsync(HintRemaining + GameSeed);
                }
                catch (TimeoutException)
                {
                    new AlertBox(
                        1500, CustomDarkLight.IsDark)
                        .ShowAlert(this,
                        "Network Error", "Cannot get result from server. Please try again later.",
                        MessageBoxIcon.Error);
                }
                catch (OperationCanceledException)
                {
                    // already handled on disconnect
                }
            }

            // ---- UI updates (safe, back on UI thread) ----
            if (hintObject == null) return;
            UpdateKeyboardColors(null, hintObject);

            string literalHint = HintGetter.HintTranslator(hintObject);

            CustomSound.PlayClickAlert();
            new AlertBox(
                1500, CustomDarkLight.IsDark)
                .ShowAlert(this,
                "Get Hint", literalHint,
                MessageBoxIcon.Information);

            HintRemaining--;

            if (HintRemaining == 1)
                lbl_Hint1_Placeholder.Text = literalHint;
            else if (HintRemaining == 0)
                lbl_Hint2_Placeholder.Text = literalHint;

            lbl_HintRemaining.Text = HintRemaining.ToString();

            if (HintRemaining == 0)
                GetHintBtn.Visible = false;
        }
        private void OnVirtualKeyPress(char c)
        {
            CustomSound.PlayClick();
            Playground_KeyPress(this, new KeyPressEventArgs(c));
        }
        private async void Playground_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (inputLocked) return;
            if (GameEnded) return;
            if (e.KeyChar == '\r')
            {
                if (IsRowFilled(currentRow))
                {
                    currentString = GetRowString(currentRow);
                    if (dictionaryChecker.TokenExists(currentString))
                    {
                        inputLocked = true;
                        StateArray? result = null;
                        if (isServer && gameInstance != null)
                        {
                            result = gameInstance.EvaluateGuess(currentString);
                        }
                        else
                        {
                            try
                            {
                                result = await RequestResultAsync(currentString);
                            }
                            catch (TimeoutException)
                            {
                                inputLocked = false;
                                new AlertBox
                                    (1500, CustomDarkLight.IsDark)
                                    .ShowAlert(this,
                                    "Network Error", "Cannot get result from server. Please try again later.",
                                    MessageBoxIcon.Error);
                            }
                            catch (OperationCanceledException)
                            {
                                // already handled on disconnect
                            }
                        }

                        if (result == null) return;

                        await FlipRow(currentRow, result);
                        UpdateKeyboardColors(result, null);

                        if (result.IsFullValue(TriState.MATCH))
                        {
                            GameEnded = true;

                            streak++;
                            lbl_Streak.Text = streak.ToString();

                            CustomSound.PlayClickAlert();

                            new AlertBox(
                                1500, CustomDarkLight.IsDark)
                                .ShowAlert(this,
                                "Success", "You found the hidden word!",
                                MessageBoxIcon.None);

                            inputLocked = false;

                            var payload = new GameStatus(PlayerName, true);

                            if (!isServer)
                            {
                                try
                                {
                                    await SendFinishedSignal(payload);
                                }
                                catch (TaskCanceledException)
                                {
                                    // Network disconnected while waiting
                                    return;
                                }
                                catch (TimeoutException)
                                {
                                    MessageBox.Show(
                                        "Server did not respond.",
                                        "Warning",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                RestartGameBtn.Visible = true;

                                if (!FinishedPlayers.Any(f => f.Username == payload.Username))
                                {
                                    FinishedPlayers.Add(payload);
                                }

                                UpdateFinishedPlayerList(FinishedPlayers);
                                ServerManager.Broadcast(
                                    new GAME_STATUS_UPDATE_RESPONSE_Packet(
                                        payload, "Server", "All"));
                            }

                            return;
                        }

                        if (currentRow < rows - 1)
                        {
                            currentRow++;
                            currentCol = 0;
                            UpdateCursorIndicator();
                        }
                        else
                        {
                            GameEnded = true;
                            
                            streak = 0;
                            lbl_Streak.Text = streak.ToString();

                            CustomSound.PlayClickGameOver();

                            new AlertBox(
                                1500, CustomDarkLight.IsDark)
                                .ShowAlert(this,
                                "Game Over", "You could not guess the word.",
                                MessageBoxIcon.None);

                            inputLocked = false;

                            var payload = new GameStatus(PlayerName, false);

                            if (!isServer)
                            {
                                try
                                {
                                    await SendFinishedSignal(payload);
                                }
                                catch (TaskCanceledException)
                                {
                                    // Network disconnected while waiting
                                    return;
                                }
                                catch (TimeoutException)
                                {
                                    MessageBox.Show(
                                        "Server did not respond.",
                                        "Warning",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                RestartGameBtn.Visible = true;

                                if (!FinishedPlayers.Any(f => f.Username == payload.Username))
                                {
                                    FinishedPlayers.Add(payload);
                                }

                                UpdateFinishedPlayerList(FinishedPlayers);
                                ServerManager.Broadcast(
                                    new GAME_STATUS_UPDATE_RESPONSE_Packet(
                                        payload, "Server", "All"));
                            }

                            return;
                        }

                        inputLocked = false;
                    }
                    else
                    {
                        CustomSound.PlayClickAlertError();
                        new AlertBox(
                            750, CustomDarkLight.IsDark)
                            .ShowAlert(this,
                            "Invalid Word", "Word not in dictionary!",
                            MessageBoxIcon.Warning);
                        await ShakeRow(currentRow);
                        await Loselife();
                    }
                    e.Handled = true;
                }
                return;
            }
            if (e.KeyChar == '\b')
            {
                if (currentCol > 0)
                {
                    currentCol--;
                    var box = GetBox(currentRow, currentCol);
                    box?.SetCharacter('-');
                }
                else
                {
                    var first = GetBox(currentRow, 0);
                    first?.SetCharacter('-');
                }
                UpdateCursorIndicator();
                e.Handled = true;
                return;
            }
            if (char.IsLetter(e.KeyChar))
            {
                if (currentCol >= cols) return;
                char ch = char.ToUpper(e.KeyChar);
                var box = GetBox(currentRow, currentCol);
                if (box != null)
                {
                    box.SetCharacter(ch);
                    currentCol++;
                    UpdateCursorIndicator();
                }
                e.Handled = true;
                return;
            }
        }
        private void UpdateCursorIndicator()
        {
            foreach (Control c in matrixPanel.Controls)
                if (c is CharBox cb)
                    cb.ShowCursor(false);

            CharBox? cursor =
                (currentCol < cols)
                ? GetBox(currentRow, currentCol)
                : GetBox(currentRow, cols - 1);

            cursor?.ShowCursor(true);
        }
        private async Task ShakeRow(int row)
        {
            int offset = 4;
            int cycles = 5;

            for (int i = 0; i < cycles; i++)
            {
                foreach (int sign in new[] { 1, -2, 1 })
                {
                    for (int c = 0; c < cols; c++)
                    {
                        var box = GetBox(row, c);
                        if (box != null)
                            box.Left += offset * sign;
                    }
                    await Task.Delay(30);
                }
            }
        }
        private async Task FlipRow(int row, StateArray result)
        {
            for (int col = 0; col < cols; col++)
            {
                var box = GetBox(row, col);
                if (box == null) continue;
                await Animation.FlipBox(box);
                switch (result.Get(col))
                {
                    case TriState.MATCH:
                        box.SetBackgroundColor(
                            Color.FromArgb(0x53, 0x8D, 0x4E));
                        break;
                    case TriState.INVALID_ORDER:
                        box.SetBackgroundColor(
                            Color.FromArgb(0xB5, 0x9F, 0x3B));
                        break;
                    case TriState.NOT_EXIST:
                        box.SetBackgroundColor(
                            Color.FromArgb(0x3A, 0x3A, 0x3C));
                        break;
                }
            }
        }
        private void btn_DarkLight_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            CustomDarkLight.IsDark = !CustomDarkLight.IsDark;
            btn_DarkLight.Image = CustomDarkLight.IsDark ? Properties.Resources.Dark : Properties.Resources.Light;
            btn_DarkLight.boderGradientBottom1 = CustomDarkLight.IsDark ? Color.FromArgb(40, 40, 40) : Color.FromArgb(220, 220, 220);
            btn_DarkLight.boderGradientTop1 = CustomDarkLight.IsDark ? Color.FromArgb(40, 40, 40) : Color.FromArgb(240, 240, 240);
            UpdateCustomGroupBoxTheme();
            Color matchColor = Color.FromArgb(0x53, 0x8D, 0x4E);
            Color invalidOrderColor = Color.FromArgb(0xB5, 0x9F, 0x3B);
            Color notExistColor = Color.FromArgb(0x3A, 0x3A, 0x3C);
            var savedKeyColors = new Dictionary
                <char, Color>(keyboardKeys.Count);
            foreach (var kvp in keyboardKeys)
            {
                var key = kvp.Value;
                var c = key.BackColor;
                if (c == matchColor
                    || c == invalidOrderColor
                    || c == notExistColor)
                    savedKeyColors[kvp.Key] = c;
            }
            var savedBoxColors = new Dictionary
                <int, Color>(matrixPanel.Controls.Count);
            for (int i = 0; i < matrixPanel.Controls.Count; i++)
            {
                if (matrixPanel.Controls[i] is CharBox cb)
                {
                    var c = cb.BackColor;
                    if (c == matchColor
                        || c == invalidOrderColor
                        || c == notExistColor)
                        savedBoxColors[i] = c;
                }
            }
            foreach (Form f in Application.OpenForms)
            {
                ThemeManager.ApplyTheme(f);
                f.Refresh();
            }
            foreach (var kvp in savedKeyColors)
            {
                if (keyboardKeys.TryGetValue(
                    kvp.Key, out var key))
                    key.SetBackgroundColor(kvp.Value);
            }
            foreach (var kvp in savedBoxColors)
            {
                int idx = kvp.Key;
                if (idx >= 0 && idx < matrixPanel.Controls.Count
                    && matrixPanel.Controls[idx] is CharBox cb)
                    cb.SetBackgroundColor(kvp.Value);
            }
        }
        private void UpdateCustomGroupBoxTheme()
        {
            gameStats.BackgroundColor = CustomDarkLight.IsDark ? Color.FromArgb(25, 26, 36) : Color.White;
            revealedHints.BackgroundColor = CustomDarkLight.IsDark ? Color.FromArgb(25, 26, 36) : Color.White;
            playerInfo.BackgroundColor = CustomDarkLight.IsDark ? Color.FromArgb(25, 26, 36) : Color.White;
            playersInRoom.BackgroundColor = CustomDarkLight.IsDark ? Color.FromArgb(25, 26, 36) : Color.White;
            playersFinished.BackgroundColor = CustomDarkLight.IsDark ? Color.FromArgb(25, 26, 36) : Color.White;

            gameStats.TextColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            revealedHints.TextColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            playerInfo.TextColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            playersInRoom.TextColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            playersFinished.TextColor = CustomDarkLight.IsDark ? Color.White : Color.Black;

            gameStats.BorderColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            revealedHints.BorderColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            playerInfo.BorderColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            playersInRoom.BorderColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            playersFinished.BorderColor = CustomDarkLight.IsDark ? Color.White : Color.Black;

            GetHintBtn.TextColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            ExitBtn.TextColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            customButton3.TextColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            customButton4.TextColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            RestartGameBtn.TextColor = CustomDarkLight.IsDark ? Color.White : Color.Black;

            GetHintBtn.BorderColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            ExitBtn.BorderColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            customButton3.BorderColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            customButton4.BorderColor = CustomDarkLight.IsDark ? Color.White : Color.Black;
            RestartGameBtn.BorderColor = CustomDarkLight.IsDark ? Color.White : Color.Black;

            GetHintBtn.BackColor = !CustomDarkLight.IsDark ? Color.White : Color.FromArgb(25, 26, 36);
            ExitBtn.BackColor = !CustomDarkLight.IsDark ? Color.White : Color.FromArgb(25, 26, 36);
            customButton3.BackColor = !CustomDarkLight.IsDark ? Color.White : Color.FromArgb(25, 26, 36);
            customButton4.BackColor = !CustomDarkLight.IsDark ? Color.White : Color.FromArgb(25, 26, 36);
            RestartGameBtn.BackColor = !CustomDarkLight.IsDark ? Color.White : Color.FromArgb(25, 26, 36);

            GetHintBtn.BackgroundColor = !CustomDarkLight.IsDark ? Color.White : Color.FromArgb(25, 26, 36);
            ExitBtn.BackgroundColor = !CustomDarkLight.IsDark ? Color.White : Color.FromArgb(25, 26, 36);
            customButton3.BackgroundColor = !CustomDarkLight.IsDark ? Color.White : Color.FromArgb(25, 26, 36);
            customButton4.BackgroundColor = !CustomDarkLight.IsDark ? Color.White : Color.FromArgb(25, 26, 36);
            RestartGameBtn.BackgroundColor = !CustomDarkLight.IsDark ? Color.White : Color.FromArgb(25, 26, 36);
        }
        private void LoadHearts()
        {
            flp_Hearts.Controls.Clear();
            for (int i = 0; i < lives; i++)
            {
                flp_Hearts.Controls.Add(new PictureBox()
                {
                    Image = Properties.Resources.Heart,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(30, 30),
                    Margin = new Padding(2)
                });
            }
        }
        private async Task Loselife()
        {
            if (lives <= 0)
            {
                return;
            }
            lives--;
            if (flp_Hearts.Controls.Count > 0)
            {
                flp_Hearts.Controls.RemoveAt(
                    flp_Hearts.Controls.Count - 1);
            }
            if (lives <= 0)
            {
                GameEnded = true;

                streak = 0;
                lbl_Streak.Text = streak.ToString();

                CustomSound.PlayClickGameOver();

                new AlertBox(
                    1700, CustomDarkLight.IsDark)
                    .ShowAlert(this,
                    "Game Over", $"You lost all lives!",
                    MessageBoxIcon.Information);

                var payload = new GameStatus(PlayerName, false);

                if (!isServer)
                {
                    try
                    {
                        await SendFinishedSignal(payload);
                        Debug.WriteLine("Payload has return!!!");
                    }
                    catch (TaskCanceledException)
                    {
                        // Network disconnected while waiting
                        return;
                    }
                    catch (TimeoutException)
                    {
                        MessageBox.Show(
                            "Server did not respond.",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    RestartGameBtn.Visible = true;

                    if (!FinishedPlayers.Any(f => f.Username == payload.Username))
                    {
                        FinishedPlayers.Add(payload);
                    }

                    UpdateFinishedPlayerList(FinishedPlayers);
                    ServerManager.Broadcast(
                        new GAME_STATUS_UPDATE_RESPONSE_Packet(
                            payload, "Server", "All"));
                }
            }
        }
        private void customButton3_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            Playground_KeyPress(this, new KeyPressEventArgs('\b'));
        }
        private void customButton4_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            Playground_KeyPress(this, new KeyPressEventArgs('\r'));
        }
        private void RestartGameBtn_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            if (!isServer) return;

            WordDatabaseReader wdr = new();
            WDBRecord? TheChosenOne = null;

            do TheChosenOne = wdr.ReadRandomWord(null, null);

            while (
                TheChosenOne != null
                && TheChosenOne.TOKEN == LastToken!
            );

            wdr.Close();
            if (TheChosenOne == null)
            {
                MessageBox.Show(
                    "Failed to load new word.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LastToken = TheChosenOne.TOKEN;

            gameInstance = new GameInstance(
                TheChosenOne);

            Random rd = new();
            GameSeed = rd.Next(0, 2);

            ServerManager.Broadcast(new START_GAME_Packet
            (
                TheChosenOne.TOKEN.Length,
                TheChosenOne.GROUP_NAME,
                TheChosenOne.LEVEL,
                rows, // ignored
                GameSeed, // ignored
                GameRoom.NumPlayers, // ignored
                "Server",
                "All"
            ));

            ResetGame(
                new WDBRecord_Simplified(
                    TheChosenOne.TOKEN.Length,
                    TheChosenOne.GROUP_NAME,
                    TheChosenOne.LEVEL));
        }
    }
}
