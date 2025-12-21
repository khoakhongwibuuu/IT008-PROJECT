using WordleClient.libraries.CustomControls;
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
        private bool _handledKick = false;
        private bool _sessionEnded = false;

        public ClientLobby()
        {
            InitializeComponent();
        }

        private async void btn_search_Click(object sender, EventArgs e)
        {
            _handledKick = false;
            _sessionEnded = false;

            btn_search.Enabled = false;
            lblStatus.Text = "Searching...";

            try
            {
                PacketConnectionManager.PacketReceived += OnPacketReceived;
                PacketConnectionManager.Disconnected += OnDisconnected;

                await PacketConnectionManager.ConnectAsync(
                    textBox1.Text.Trim(), ServerPort);

                lblStatus.Text = "Server found. Ready to join.";
                btn_JoinRequest.Visible = true;
            }
            catch
            {
                MessageBox.Show("No room found at this IP");
                lblStatus.Text = "Standby";
            }
        }

        private async void btn_JoinRequest_Click(object sender, EventArgs e)
        {
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

                            // approved case stays unchanged
                            lblStatus.Text = $"Joined {parts[0]}'s room";
                            btn_JoinRequest.Visible = false;
                            break;
                        }


                    case PLAYER_LIST_SYNC_Packet list:
                        {
                            if (_handledKick) 
                                return;

                            listBoxPlayers.Items.Clear();

                            foreach (string raw in list.Players)
                            {
                                Player p = Player.Parse(raw);

                                serverUsername ??= p.Username;
                                lblStatus.Text = $"Joined {serverUsername}'s room successfully.";

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

                            if (_handledKick || _sessionEnded)
                                return;

                            _handledKick = true;

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

                    case START_GAME_Packet start_pkg:
                        {
                            MessageBox.Show(
                                $"{start_pkg.WordLength}-{start_pkg.MaxAttempts}-{start_pkg.Level}-{start_pkg.Topic}",
                                "Packet Received",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            break;
                        }
                }
            });
        }
        private void OnDisconnected()
        {
            BeginInvoke(() =>
            {
                if (_handledKick)
                    return;

                lblStatus.Text = "Disconnected";
                listBoxPlayers.Items.Clear();
                btn_JoinRequest.Visible = false;
            });
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            Close();
        }
    }
}
