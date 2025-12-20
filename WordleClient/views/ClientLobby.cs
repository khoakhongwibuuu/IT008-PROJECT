using WordleClient.libraries.CustomControls;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.network;
using WordleClient.libraries.StateFrom;

namespace WordleClient.views
{
    public partial class ClientLobby : CustomForm
    {
        private const int ServerPort = 5000;
        public bool ReturnToMainOnClose { get; set; } = true;
        private string? serverUsername;

        public ClientLobby()
        {
            InitializeComponent();
        }

        private async void btn_search_Click(object sender, EventArgs e)
        {
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
                btn_JoinRequest.Enabled = true;
            }
            catch
            {
                MessageBox.Show("No room found at this IP");
                lblStatus.Text = "Standby";
            }
            finally
            {
                btn_search.Enabled = true;
            }
        }

        private async void btn_JoinRequest_Click(object sender, EventArgs e)
        {
            btn_JoinRequest.Enabled = false;
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
                            string name = parts[0];
                            string? reason = parts.Length > 1 ? parts[1] : null;

                            if (!res.Approved)
                            {
                                MessageBox.Show(
                                    reason ?? "Join request denied",
                                    "Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                btn_JoinRequest.Enabled = true;
                                btn_JoinRequest.Visible = true;
                                lblStatus.Text = "Standby";
                                return;
                            }

                            lblStatus.Text = $"Joined {name}'s room";
                            btn_JoinRequest.Visible = false;
                            break;
                        }

                    case PLAYER_LIST_SYNC_Packet list:
                        {
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
                }
            });
        }

        private void OnDisconnected()
        {
            BeginInvoke(() =>
            {
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
