using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WordleClient.libraries.CustomControls;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.StateFrom;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WordleClient.views
{
    public partial class Playground : Form
    {
        // Matrix dimensions
        private readonly int rows;
        private int cols;
        private int streak = 0;
        private int lives = 5;
        private readonly Panel matrixPanel;

        // Virtual keyboard
        private Panel? keyboardPanel;
        private Dictionary<char, CharBox> keyboardKeys = new();

        // Does nothing when Difficulty is set to HARD
        private readonly string? initialTopic;
        private readonly string? initialDifficulty;

        // For Hard reset
        private string? hardTopic = null;
        private string? hardLevel = null;

        // Size constants
        private const int boxSize = 60;
        private const int spacing = 6;

        // Tracks the current string being built in the current row
        private string currentString = string.Empty;

        // Game flags
        private bool GameEnded = false;
        private int HintRemaining;
        private int GameSeed;

        // Tracks current cursor position
        private int currentRow = 0;
        private int currentCol = 0;

        // Game Instance
        private GameInstance gameInstance;

        // Dictionary checker
        private DictionaryChecker dictionaryChecker;

        // Logger
        private readonly SingleplayerLogger logger = new();

        // Store last token to prevent duplicates
        private string? lastToken = null;

        public Playground(WDBRecord TheChosenOne, int MaxGuessCount, string? topic, string? difficulty)
        {
            Random rd = new();
            this.rows = MaxGuessCount;
            this.cols = TheChosenOne.TOKEN.Length;
            this.gameInstance = new GameInstance(TheChosenOne);
            this.initialTopic = topic;
            this.initialDifficulty = difficulty;
            this.dictionaryChecker = new DictionaryChecker(TheChosenOne.TOKEN.Length);
            this.GameSeed = rd.Next(0, 2);
            this.HintRemaining = 2;
            this.lastToken = TheChosenOne.TOKEN;
            InitializeComponent();
            LoadHearts();
            StartHeartAnimation();
            // Dynamic matrix panel
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

            this.KeyPreview = true;
            this.KeyPress += Playground_KeyPress;

            this.Resize += (s, e) => { CenterMatrix(); PositionKeyboard(); };
            this.panel2.Resize += (s, e) => { CenterMatrix(); PositionKeyboard(); };

            this.FormClosing += Playground_FormClosing;
            this.Load += Playground_Load;
        }

        private void Playground_Load(object? sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(this);
            string nickname = (ProfileState.Current == null) ? "Player" : ProfileState.Current.Nickname ?? "Player";
            AlertBox alertBox = new AlertBox(3000);
            CustomSound.PlayClickAlert();
            alertBox.ShowAlert(this, "Welcome", $"Welcome to Playground, {nickname}!");
            label8.Text = nickname;
        }

        private void Playground_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (GameEnded) return;

            if (CustomMessageBoxYesNo.Show(this, "Are you sure you want to exit?", MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                dictionaryChecker.Dispose();
                logger.SaveToDatabase(new SingleplayerPlayLog(
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    gameInstance.GetToken(),
                    gameInstance.GetGroupName(),
                    gameInstance.GetDifficulty(),
                    false, rows, currentRow
                ));
                gameInstance.Dispose();
                logger.Close();
            }
        }

        // ============================
        // MATRIX
        // ============================
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
                        Location = new Point(j * (boxSize + spacing), i * (boxSize + spacing))
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
                (panel2.Height - panelHeight) / 2 - 80
            );
        }

        private void PositionKeyboard()
        {
            if (keyboardPanel == null) return;

            keyboardPanel.Location = new Point(
                (panel2.Width - keyboardPanel.Width) / 2,
                matrixPanel.Bottom + 30
            );
        }

        private CharBox? GetBox(int r, int c)
        {
            int index = r * cols + c;
            if (index < 0 || index >= matrixPanel.Controls.Count)
                return null;
            return matrixPanel.Controls[index] as CharBox;
        }

        private string GetRowString(int row)
        {
            StringBuilder sb = new();
            for (int c = 0; c < cols; c++)
            {
                var b = GetBox(row, c);
                if (b == null) continue;

                var ch = b.Character;
                if (!string.IsNullOrEmpty(ch) && ch != "-" && ch != "\0")
                    sb.Append(ch[0]);
            }
            return sb.ToString();
        }

        private bool IsBoxEmpty(CharBox box)
        {
            if (box == null) return true;
            return string.IsNullOrEmpty(box.Character) || box.Character == "-" || box.Character == "\0";
        }

        private bool IsRowFilled(int row)
        {
            for (int c = 0; c < cols; c++)
            {
                var b = GetBox(row, c);
                if (b == null || IsBoxEmpty(b)) return false;
            }
            return true;
        }

        // ============================
        // VIRTUAL KEYBOARD
        // ============================
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

            string[] keyRows =
            {
                "QWERTYUIOP",
                "ASDFGHJKL",
                "ZXCVBNM"
            };

            int keySize = 40;
            int keySpace = 6;

            int top = 0;

            foreach (string row in keyRows)
            {
                int left = (panel2.Width - (row.Length * (keySize + keySpace))) / 2;

                foreach (char c in row)
                {
                    CharBox key = new CharBox
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

            PositionKeyboard();
        }

        private void UpdateKeyboardColors(StateArray result)
        {
            for (int col = 0; col < cols; col++)
            {
                char c = currentString[col];
                char up = char.ToUpper(c);

                if (!keyboardKeys.ContainsKey(up)) continue;

                var key = keyboardKeys[up];

                switch (result.Get(col))
                {
                    case TriState.MATCH:
                        key.SetBackgroundColor(Color.FromArgb(0x53, 0x8D, 0x4E));
                        break;

                    case TriState.INVALID_ORDER:
                        if (key.BackColor != Color.FromArgb(0x53, 0x8D, 0x4E))
                            key.SetBackgroundColor(Color.FromArgb(0xB5, 0x9F, 0x3B));
                        break;

                    case TriState.NOT_EXIST:
                        if (key.BackColor != Color.FromArgb(0x53, 0x8D, 0x4E) && key.BackColor != Color.FromArgb(0xB5, 0x9F, 0x3B))
                            key.SetBackgroundColor(Color.FromArgb(0x3A, 0x3A, 0x3C));
                        break;
                }
            }
        }

        private void GetHintBtn_Click(object sender, EventArgs e)
        {
            if (HintRemaining > 0 && !GameEnded)
            {
                CustomSound.PlayClick();
                string hint = gameInstance.GetHint(HintRemaining + GameSeed);

                CustomSound.PlayClickAlert();
                AlertBox alert = new AlertBox(1500);
                alert.ShowAlert(this, "Hint", hint);

                HintRemaining--;

                if (HintRemaining == 1)
                    lbl_Hint1_Placeholder.Text = hint;
                else if (HintRemaining == 0)
                    lbl_Hint2_Placeholder.Text = hint;

                lbl_HintRemaining.Text = HintRemaining.ToString();

                if (HintRemaining == 0)
                    customButton1.Visible = false;
            }
            else if (GameEnded)
            {
                MessageBox.Show("The game has ended.", "Get Hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("No hints remaining.", "Get Hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnVirtualKeyPress(char c)
        {
            Playground_KeyPress(this, new KeyPressEventArgs(c));
        }

        private void OnVirtualEnter()
        {
            Playground_KeyPress(this, new KeyPressEventArgs('\r'));
        }

        private void OnVirtualBackspace()
        {
            Playground_KeyPress(this, new KeyPressEventArgs('\b'));
        }

        // ============================
        // KEY INPUT LOGIC
        // ============================
        private async void Playground_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (GameEnded) return;

            // ENTER
            if (e.KeyChar == '\r')
            {
                if (IsRowFilled(currentRow))
                {
                    currentString = GetRowString(currentRow);

                    if (dictionaryChecker.TokenExists(currentString))
                    {
                        var result = gameInstance.EvaluateGuess(currentString);

                        await FlipRow(currentRow, result);
                        UpdateKeyboardColors(result);

                        if (result.IsFullValue(TriState.MATCH))
                        {
                            GameEnded = true;
                            streak++;
                            lbl_Streak.Text = streak.ToString();

                            CustomSound.PlayClickAlert();
                            new AlertBox(1500).ShowAlert(this, "Success", "You found the hidden word!");

                            logger.SaveToDatabase(new SingleplayerPlayLog(
                                DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                                gameInstance.GetToken(),
                                gameInstance.GetGroupName(),
                                gameInstance.GetDifficulty(),
                                true, rows, currentRow + 1
                            ));

                            await Task.Delay(1500);

                            if (initialDifficulty == "HARD")
                                ResetHardGame();
                            else
                                Resetnew_Game();
                            ThemeManager.ApplyTheme(this);
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
                            CustomSound.PlayClickGameOver();
                            new AlertBox(1500).ShowAlert(
                                this,
                                "Failed",
                                $"The hidden word was {gameInstance.GetToken()}",
                                MessageBoxIcon.Information
                            );

                            logger.SaveToDatabase(new SingleplayerPlayLog(
                                DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                                gameInstance.GetToken(),
                                gameInstance.GetGroupName(),
                                gameInstance.GetDifficulty(),
                                false, rows, currentRow + 1
                            ));

                            await Task.Delay(2000);

                            if (CustomMessageBoxYesNo.Show(this, "Start a new game?", MessageBoxIcon.Question)
                                == DialogResult.Yes)
                            {
                                lives = 5;
                                LoadHearts();
                                StartHeartAnimation();
                                streak = 0;
                                lbl_Streak.Text = "0";

                                if (initialDifficulty == "HARD")
                                    ResetHardGame();
                                else
                                    Resetnew_Game();
                                ThemeManager.ApplyTheme(this);
                            }
                            else this.Close();

                            return;
                        }
                    }
                    else
                    {
                        CustomSound.PlayClickAlertError();
                        new AlertBox(750).ShowAlert(this, "Invalid Word", "Word not in dictionary!", MessageBoxIcon.Warning);
                        await ShakeRow(currentRow);
                        Loselife();
                        e.Handled = true;
                        return;
                    }

                    e.Handled = true;
                }
                return;
            }

            // BACKSPACE
            if (e.KeyChar == '\b')
            {
                if (currentCol > 0)
                {
                    currentCol--;
                    var box = GetBox(currentRow, currentCol);
                    if (box != null)
                        box.SetCharacter('-');
                }
                else
                {
                    var first = GetBox(currentRow, 0);
                    if (first != null)
                        first.SetCharacter('-');
                }

                UpdateCursorIndicator();
                e.Handled = true;
                return;
            }

            // A–Z Input
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

        // ============================
        // CURSOR HANDLING
        // ============================
        private void UpdateCursorIndicator()
        {
            foreach (Control c in matrixPanel.Controls)
                if (c is CharBox cb)
                    cb.ShowCursor(false);

            CharBox? cursor = GetBox(currentRow, currentCol);
            cursor?.ShowCursor(true);
        }

        // ============================
        // ROW ANIMATIONS
        // ============================
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

        static private async Task FlipBox(CharBox box)
        {
            int steps = 5;
            for (int i = 0; i < steps; i++) { box.Height -= 5; box.Top += 2; await Task.Delay(10); }
            for (int i = 0; i < steps; i++) { box.Height += 5; box.Top -= 2; await Task.Delay(10); }
        }

        private async Task FlipRow(int row, StateArray result)
        {
            for (int col = 0; col < cols; col++)
            {
                var box = GetBox(row, col);
                if (box == null) continue;

                await FlipBox(box);

                switch (result.Get(col))
                {
                    case TriState.MATCH:
                        box.SetBackgroundColor(Color.FromArgb(0x53, 0x8D, 0x4E));
                        break;

                    case TriState.INVALID_ORDER:
                        box.SetBackgroundColor(Color.FromArgb(0xB5, 0x9F, 0x3B));
                        break;

                    case TriState.NOT_EXIST:
                        box.SetBackgroundColor(Color.FromArgb(0x3A, 0x3A, 0x3C));
                        break;
                }
            }
        }

        // ============================
        // RESET GAME
        // ============================
        private void Resetnew_Game()
        {
            ThemeManager.ApplyTheme(this);

            WordDatabaseReader wdr = new();
            WDBRecord? newWord;

            do newWord = wdr.ReadRandomWord(initialTopic, initialDifficulty);
            while (newWord != null && newWord.TOKEN == lastToken);

            wdr.Close();

            if (newWord == null)
            {
                MessageBox.Show("Failed to load new word.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lastToken = newWord.TOKEN;

            gameInstance = new GameInstance(newWord);
            dictionaryChecker = new DictionaryChecker(newWord.TOKEN.Length);

            GameEnded = false;

            currentRow = 0;
            currentCol = 0;

            Random rd = new();
            GameSeed = rd.Next(0, 2);
            HintRemaining = 2;

            lbl_HintRemaining.Text = "2";
            lbl_Hint1_Placeholder.Text = "Unknown";
            lbl_Hint2_Placeholder.Text = "Unknown";
            customButton1.Visible = true;

            lbl_Diff.Text = newWord.LEVEL;
            lbl_Tpc.Text = newWord.GROUP_NAME.Replace("&", "And");

            cols = newWord.TOKEN.Length;

            CreateMatrix();
            CenterMatrix();
            BuildKeyboard();

            matrixPanel.Refresh();
            this.Refresh();
        }

        private void ResetHardGame()
        {
            WordDatabaseReader wdr = new();
            WDBRecord? newWord;

            if (hardTopic == null || hardLevel == null)
            {
                do newWord = wdr.ReadRandomWord(null, null);
                while (newWord != null && newWord.TOKEN == lastToken);

                if (newWord != null)
                {
                    hardTopic = newWord.GROUP_NAME;
                    hardLevel = newWord.LEVEL;
                }
            }
            else
            {
                do newWord = wdr.ReadRandomWord(hardTopic, hardLevel);
                while (newWord != null && newWord.TOKEN == lastToken);
            }

            wdr.Close();

            if (newWord == null)
            {
                MessageBox.Show("Failed to load new word.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lastToken = newWord.TOKEN;

            gameInstance = new GameInstance(newWord);
            dictionaryChecker = new DictionaryChecker(newWord.TOKEN.Length);

            GameEnded = false;

            currentRow = 0;
            currentCol = 0;

            Random rd = new();
            GameSeed = rd.Next(0, 2);
            HintRemaining = 2;

            lbl_HintRemaining.Text = "2";
            lbl_Hint1_Placeholder.Text = "Unknown";
            lbl_Hint2_Placeholder.Text = "Unknown";
            customButton1.Visible = true;

            lbl_Diff.Text = newWord.LEVEL;
            lbl_Tpc.Text = newWord.GROUP_NAME.Replace("&", "And");

            cols = newWord.TOKEN.Length;

            CreateMatrix();
            CenterMatrix();
            BuildKeyboard();

            matrixPanel.Refresh();
            this.Refresh();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Close();
        }
        private void LoadHearts()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < lives; i++)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Image = Properties.Resources.heart,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(30, 30),
                    Margin = new Padding(2)
                };
                flowLayoutPanel1.Controls.Add(pictureBox);
            }
        }
        private void Loselife()
        {
            if(lives <= 0)
            {
                return;
            }
            lives--;
            if(flowLayoutPanel1.Controls.Count > 0)
            {
                flowLayoutPanel1.Controls.RemoveAt(flowLayoutPanel1.Controls.Count - 1);
            }
            if(lives <= 0)
            {
                GameEnded = true;
                CustomSound.PlayClickGameOver();
                new AlertBox(1700).ShowAlert(
                    this,
                    "Game Over",
                    $"You lost all lives!The word was: {gameInstance.GetToken()}",
                    MessageBoxIcon.Information
                );
                logger.SaveToDatabase(new SingleplayerPlayLog(
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    gameInstance.GetToken(),
                    gameInstance.GetGroupName(),
                    gameInstance.GetDifficulty(),
                    false, rows, currentRow + 1
                ));
                Task.Delay(1700).Wait();
                if (CustomMessageBoxYesNo.Show(this, "Play again?", MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lives = 5;
                    LoadHearts();
                    StartHeartAnimation();
                    if (initialDifficulty == "HARD")
                        ResetHardGame();
                    else
                        Resetnew_Game();
                }
                else this.Close();
            }
        }
        private async Task HeartAnimation(PictureBox heart)
        {
            if (heart == null) return;
            // Size ban đầu
            int originalW = heart.Width;
            int originalH = heart.Height;
            // Độ nở
            int beatW = originalW + 4;
            int beatH = originalH + 4;
            // Cập nhật size mới
            heart.Size = new Size(beatW, beatH);
            // Giữ tâm nở đều cả 4 phía
            heart.Location = new Point(heart.Location.X - 2, heart.Location.Y - 2);
            await Task.Delay(120);
            // Trở về vị trí cũ
            heart.Size = new Size(originalW, originalH);
            heart.Location = new Point(heart.Location.X + 2, heart.Location.Y + 2);
            await Task.Delay(120);
        }
        private async void StartHeartAnimation()
        {
            while (!GameEnded)
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    if (c is PictureBox pb)
                        await HeartAnimation(pb);
                }
                await Task.Delay(600); 
            }
        }
    }
}
