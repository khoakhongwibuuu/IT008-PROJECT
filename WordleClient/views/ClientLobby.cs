using WordleClient.libraries.CustomControls;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.network;
using WordleClient.libraries.StateFrom;

namespace WordleClient.views
{
    public partial class ClientLobby : CustomForm
    {
        public bool ReturnToMainOnClose { get; set; } = true;

        private const int ServerPort = 5000;

        public ClientLobby()
        {
            InitializeComponent();
        }
        private async void btn_search_Click(object sender, EventArgs e)
        {
            string ip = textBox1.Text.Trim();

            if (!System.Net.IPAddress.TryParse(ip, out _))
            {
                MessageBox.Show("Invalid IP Address");
                return;
            }

            btn_search.Enabled = false;
            lblStatus.Text = "Connecting...";

            try
            {
                await ConnectionManager.Connection.ConnectAsync(ip, ServerPort);
                lblStatus.Text = "Connected to server ✅";
            }
            catch
            {
                lblStatus.Text = "Server not reachable ❌";
            }
            finally
            {
                btn_search.Enabled = true;
            }
        }
        private async void btn_JoinRequest_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();

            if (!ConnectionManager.IsConnected)
            {
                MessageBox.Show("Not connected to server");
                return;
            }

            //var joinPacket = new JOIN_REQUEST_Packet(
            //    username: txtUsername.Text,
            //    sender: "client",
            //    recipient: "server");

            //await ConnectionManager.Connection.SendAsync(joinPacket);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            ConnectionManager.Connection.Disconnect();

            // When re-direct to Client-Playground, call these 2 lines b4 redirecting
            ConnectionManager.Connection.PacketReceived -= OnPacketReceived;
            ConnectionManager.Connection.Disconnected -= OnDisconnected;

            this.Close();
        }

        private void OnPacketReceived(Packet packet)
        {
            BeginInvoke(() =>
            {
                switch (packet)
                {
                    case JOIN_RESPONSE_Packet join:
                        lblStatus.Text = join.Success
                            ? "Joined server successfully"
                            : "Join failed";
                        break;

                    case GENERAL_MESSAGE_Packet msg:
                        //listBoxLog.Items.Add(msg.Message);
                        break;
                }
            });
        }

        private void OnDisconnected()
        {
            BeginInvoke(() =>
            {
                lblStatus.Text = "Disconnected from server";
            });
        }

        private void ClientLobby_Load(object sender, EventArgs e)
        {
            ConnectionManager.Connection.PacketReceived += OnPacketReceived;
            ConnectionManager.Connection.Disconnected += OnDisconnected;
        }
    }
}
