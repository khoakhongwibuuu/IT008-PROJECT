using WordleClient.libraries.CustomControls;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.network;
using WordleClient.libraries.StateFrom;

namespace WordleClient.views
{
    public partial class ClientLobby : CustomForm
    {
        private const int ServerPort = 12880;
        public bool ReturnToMainOnClose { get; set; } = true;
        private string? serverUsername;

        // GUARDS
        private bool _sessionEnded = false;
        private bool _eventsSubscribed = false;
        private bool _connectionReady = false;

        public ClientLobby()
        {
            InitializeComponent();
        }

        private async void btn_search_Click(object sender, EventArgs e)
        {
            _connectionReady = false;
            _sessionEnded = false;

            btn_search.Enabled = false;
            lblStatus.Text = "Searching...";

            // Ensure clean state when re-entering ClientLobby
            if (PacketConnectionManager.IsConnected)
            {
                PacketConnectionManager.Disconnect();
            }

            try
            {
                if (!_eventsSubscribed)
                {
                    PacketConnectionManager.PacketReceived += OnPacketReceived;
                    PacketConnectionManager.Disconnected += OnDisconnected;
                    _eventsSubscribed = true;
                }

                await PacketConnectionManager.ConnectAsync(
                    textBox1.Text.Trim(), ServerPort);

                _connectionReady = true;
                lblStatus.Text = "Server found. Ready to join.";
                btn_JoinRequest.Visible = true;
            }
            catch
            {
                MessageBox.Show("No room found at this IP");
                btn_search.Enabled = true;
                lblStatus.Text = "Standby";
            }
        }

        private async void btn_JoinRequest_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();

            if (!_connectionReady || !PacketConnectionManager.IsConnected)
            {
                lblStatus.Text = "Connection lost. Please search again.";
                btn_JoinRequest.Visible = false;
                return;
            }

            btn_JoinRequest.Visible = false;
            lblStatus.Text = "Waiting for host approval...";

            string username = ProfileState.GetPlayername();

            await PacketConnectionManager.SendAsync(
                new JOIN_REQUEST_Packet(username, username, "Server"));
        }

        private void OnPacketReceived(Packet packet)
        {
            BeginInvoke(() =>
            {
                switch (packet)
                {
                    case JOIN_APPROVAL_RESPONSE_Packet res:
                        {
                            string[] parts = res.Username.Split('|');

                            if (!res.Approved)
                            {
                                if (_sessionEnded)
                                    return;

                                _sessionEnded = true;

                                string reason = parts.Length > 1
                                    ? parts[1]
                                    : "Join request denied";

                                MessageBox.Show(
                                    reason,
                                    "Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                btn_JoinRequest.Enabled = true;
                                btn_JoinRequest.Visible = true;
                                btn_search.Enabled = true;

                                lblStatus.Text = "Standby";
                                PacketConnectionManager.Disconnect();
                                return;
                            }

                            lblStatus.Text = $"Joined {res.Sender}'s room successfully.";
                            btn_JoinRequest.Visible = false;
                            break;
                        }


                    case PLAYER_LIST_SYNC_Packet list:
                        {
                            if (_sessionEnded)
                                return;

                            listBoxPlayers.Items.Clear();

                            foreach (string raw in list.Players)
                            {
                                Player p = Player.Parse(raw);

                                serverUsername ??= p.Username;

                                if (p.Username == serverUsername)
                                    listBoxPlayers.Items.Add($"HOST: {p.Username}");
                                else
                                    listBoxPlayers.Items.Add(p.Username);
                            }
                            break;
                        }

                    case PLAYER_DISCONNECT_Packet:
                        {
                            listBoxPlayers.Items.Clear();

                            if (_sessionEnded)
                                return;

                            listBoxPlayers.Items.Clear();
                            lblStatus.Text = "You have been kicked";

                            MessageBox.Show(
                                "You have been kicked from the room by the host.",
                                "Kicked",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            btn_search.Enabled = true;
                            btn_JoinRequest.Visible = false;

                            PacketConnectionManager.Disconnect();
                            lblStatus.Text = "Standby";
                            break;
                        }

                    case START_GAME_Packet pkg:
                        {
                            PacketConnectionManager.PacketReceived -= OnPacketReceived;
                            PacketConnectionManager.Disconnected -= OnDisconnected;

                            var mp = new MultiPlayground(
                                new WDBRecord_Simplified(pkg.WordLength, pkg.Topic, pkg.Level),
                                pkg.MaxAttempts,
                                pkg.GameSeed,
                                pkg.NumPlayers
                            );

                            ReturnToMainOnClose = false;

                            Hide();
                            CustomSound.StopBackground();
                            mp.Show();

                            Close();
                            break;
                        }
                }
            });
        }
        private void OnDisconnected()
        {
            BeginInvoke(() =>
            {
                _connectionReady = false;
                if (_sessionEnded)
                    return;

                lblStatus.Text = "Disconnected";
                listBoxPlayers.Items.Clear();
                btn_JoinRequest.Visible = false;
                btn_search.Enabled = true;
            });
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            _connectionReady = false;

            PacketConnectionManager.PacketReceived -= OnPacketReceived;
            PacketConnectionManager.Disconnected -= OnDisconnected;
            PacketConnectionManager.Disconnect();

            Close();
        }
    }
}
