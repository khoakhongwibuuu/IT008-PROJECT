using WordleClient.libraries.CustomControls;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.network;
using WordleClient.libraries.StateFrom;

namespace WordleClient.views
{
    public partial class ServerLobby : CustomForm
    {
        private const int ServerPort = 12880;
        public bool ReturnToMainOnClose { get; set; } = true;

        // Pending approval UI
        private readonly Dictionary<string, Panel> _pendingRequests = new();
        private Panel panelRequests = null!;

        // Approved players UI
        private readonly Dictionary<string, Panel> _approvedPlayers = new();
        private Panel panelPlayers = null!;

        private string ServerUsername => ProfileState.GetPlayername();

        public ServerLobby()
        {
            InitializeComponent();
        }

        /* ============================================================
         * LOAD / EXIT
         * ============================================================ */
        private void ServerLobby_Load(object sender, EventArgs e)
        {
            btn_StartGame.Visible = false;
            btn_StartGame.Text = "At least 2 players is needed";

            panelRequests = CreateInnerPanel(GB_PlayerWaitForApproval);
            panelPlayers = CreateInnerPanel(GB_PlayerApproved);

            try
            {
                if (!ServerManager.IsRunning)
                {

                    ServerManager.Start(ServerPort);

                    // Event subscribe
                    ServerManager.ServerPacketReceived += OnServerPacket;
                    ServerManager.ClientDisconnected += OnClientDisconnectedUI;

                    GameRoom.Dispose();
                    GameRoom.SetHost(new Player(ServerUsername, "127.0.0.1"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server Error");
                Close();
            }
        }
        private static Panel CreateInnerPanel(Control groupBox)
        {
            Panel panel = new()
            {
                Left = 10,
                Top = 40,
                Width = groupBox.Width - 20,
                Height = groupBox.Height - 50,
                AutoScroll = true,
                BackColor = SystemColors.Window
            };
            groupBox.Controls.Add(panel);
            panel.BringToFront();

            groupBox.Resize += (_, _) =>
            {
                panel.Width = groupBox.Width - 20;
                panel.Height = groupBox.Height - 50;
            };

            return panel;
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();

            // Event unsubscribe on exit
            ServerManager.ServerPacketReceived -= OnServerPacket;
            ServerManager.ClientDisconnected -= OnClientDisconnectedUI;

            // Close server
            ServerManager.Stop();
            Close();
        }

        /* ============================================================
         * SERVER → UI
         * ============================================================ */
        private void OnServerPacket(Packet packet)
        {
            if (packet is not JOIN_APPROVAL_REQUEST_Packet req)
                return;

            BeginInvoke(() =>
            {
                Player player = Player.Parse(req.Username);

                if (IsUsernameServer(player.Username))
                {
                    Deny(player, "Name already taken (server)");
                    return;
                }

                if (IsUsernameApproved(player.Username))
                {
                    Deny(player, "Name already taken");
                    return;
                }

                AddJoinRequestUI(player);
                UpdatePendingDuplicateStyles();
            });
        }

        /* ============================================================
         * PENDING REQUESTS
         * ============================================================ */
        private void AddJoinRequestUI(Player player)
        {
            if (_pendingRequests.ContainsKey(player.IPAddress))
                return;

            Panel panel = new()
            {
                Width = panelRequests.ClientSize.Width - 5,
                Height = 50,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = player,
                BackColor = Color.Transparent
            };

            Label lbl = new()
            {
                Text = $"{player.Username} ({player.IPAddress})",
                Location = new Point(10, 15),
                AutoSize = true,
                ForeColor = Color.Black
            };

            Button btnAccept = new()
            {
                Text = "✓",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point),
                Size = new Size(40, 40),
                Left = panel.Width - 120,
                Top = 5,
                ForeColor = Color.Black
            };
            Button btnDeny = new()
            {
                Text = "✘",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point),
                Size = new Size(40, 40),
                Left = panel.Width - 60,
                Top = 5,
                ForeColor = Color.Black
            };

            btnAccept.Click += (_, _) => HandleApproval(player, true);
            btnDeny.Click += (_, _) => Deny(player, "Denied by host");

            panel.Controls.Add(lbl);
            panel.Controls.Add(btnAccept);
            panel.Controls.Add(btnDeny);

            panel.Top = _pendingRequests.Count * 55;
            panelRequests.Controls.Add(panel);
            _pendingRequests[player.IPAddress] = panel;
        }
        private void UpdatePendingDuplicateStyles()
        {
            HashSet<string> seen = new(StringComparer.OrdinalIgnoreCase);

            foreach (Panel panel in _pendingRequests.Values)
            {
                Player p = (Player)panel.Tag!;
                bool duplicate = !seen.Add(p.Username);
                panel.BackColor = duplicate ? Color.LightGray : SystemColors.Control;
            }
        }

        /* ============================================================
         * APPROVAL / DENY
         * ============================================================ */
        private void HandleApproval(Player player, bool approved)
        {
            RemoveJoinRequestUI(player.IPAddress);

            if (approved && IsUsernameApproved(player.Username))
            {
                Deny(player, "Name already taken");
                return;
            }

            if (!approved)
            {
                Deny(player, "Denied by host");
                return;
            }

            GameRoom.AddClient(player);

            ServerManager.SendTo(
                player.IPAddress,
                new JOIN_APPROVAL_RESPONSE_Packet(
                    $"{player.Username}|Approved",
                    true,
                    ServerUsername));

            AddApprovedPlayerUI(player);
            ServerManager.BroadcastPlayerList();
            UpdateStartGameState();
        }
        private void Deny(Player player, string reason)
        {
            RemoveJoinRequestUI(player.IPAddress);

            ServerManager.SendTo(
                player.IPAddress,
                new JOIN_APPROVAL_RESPONSE_Packet(
                    $"{player.Username}|{reason}",
                    false,
                    ServerUsername));

            UpdatePendingDuplicateStyles();
        }

        /* ============================================================
         * APPROVED PLAYERS
         * ============================================================ */
        private void AddApprovedPlayerUI(Player player)
        {
            if (_approvedPlayers.ContainsKey(player.IPAddress))
                return;

            Panel panel = new()
            {
                Width = panelPlayers.ClientSize.Width - 5,
                Height = 45,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightSteelBlue,
                Tag = player
            };

            Label lbl = new()
            {
                Text = player.Username,
                Location = new Point(10, 12),
                AutoSize = true,
                ForeColor = Color.Black
            };

            Button btnKick = new()
            {
                Text = "Kick",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.Black,
                Size = new Size(60, 30),
                Location = new Point(panel.Width - 80, 8)
            };
            btnKick.Click += (_, _) => KickPlayer(player);

            panel.Controls.Add(lbl);
            panel.Controls.Add(btnKick);

            panel.Top = _approvedPlayers.Count * 50;
            panelPlayers.Controls.Add(panel);
            _approvedPlayers[player.IPAddress] = panel;
        }
        private void KickPlayer(Player player)
        {
            if (!GameRoom.RemoveClient(player))
                return;

            ServerManager.SendTo(
                player.IPAddress,
                new PLAYER_DISCONNECT_Packet(
                    player.Username,
                    "Server",
                    player.Username));

            RemoveApprovedPlayerUI(player.IPAddress);
            ServerManager.BroadcastPlayerList();
            UpdateStartGameState();
        }

        /* ============================================================
         * CLEANUP / STATE
         * ============================================================ */
        private void RemoveJoinRequestUI(string ip)
        {
            if (_pendingRequests.Remove(ip, out Panel? panel))
            {
                panelRequests.Controls.Remove(panel);
                panel.Dispose();
            }
        }
        private void RemoveApprovedPlayerUI(string ip)
        {
            if (_approvedPlayers.Remove(ip, out Panel? panel))
            {
                panelPlayers.Controls.Remove(panel);
                panel.Dispose();
            }
        }
        private void OnClientDisconnectedUI(string ip)
        {
            BeginInvoke(() =>
            {
                RemoveJoinRequestUI(ip);
                RemoveApprovedPlayerUI(ip);
                UpdateStartGameState();
            });
        }
        private void UpdateStartGameState()
        {
            if (_approvedPlayers.Count + 1 >= 2)
            {
                btn_StartGame.Visible = true;
                btn_StartGame.Text = "Start Game";
            }
            else
            {
                btn_StartGame.Visible = false;
                btn_StartGame.Text = "At least 2 players is needed";
            }
        }

        /* ============================================================
         * USERNAME CHECKS
         * ============================================================ */
        private bool IsUsernameApproved(string username) =>
            _approvedPlayers.Values.Any(p =>
                ((Player)p.Tag!).Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        private bool IsUsernameServer(string username) =>
            username.Equals(ServerUsername, StringComparison.OrdinalIgnoreCase);

        /* ============================================================
         * START GAME
         * =========================================================== */
        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            WordDatabaseReader wdr = new();
            WDBRecord? TheChosenOne = wdr.ReadRandomWord(null, null);

            if (TheChosenOne == null)
            {
                //this is unlikely to happen
                MessageBox.Show("Failed to select a word from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Random rd = new();
            int GameSeed = rd.Next(0, 2);

            START_GAME_Packet startPacket = new
            (
                TheChosenOne.TOKEN.Length,
                TheChosenOne.GROUP_NAME,
                TheChosenOne.LEVEL,
                trackBarGuess.Value,
                GameSeed,
                GameRoom.NumPlayers,
                "Server",
                "All"
            );

            ServerManager.Broadcast(startPacket);

            ServerManager.ServerPacketReceived -= OnServerPacket;
            ServerManager.ClientDisconnected -= OnClientDisconnectedUI;

            MultiPlayground mp = new(TheChosenOne, trackBarGuess.Value, GameSeed, GameRoom.NumPlayers);
            this.ReturnToMainOnClose = false;
            this.Close();
            CustomSound.StopBackground();
            mp.Show();

        }
    }
}
