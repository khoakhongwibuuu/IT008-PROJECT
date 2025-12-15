using WordleClient.libraries.CustomControls;
using WordleClient.libraries.StateFrom;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.network;
using System.Diagnostics;

namespace WordleClient.views
{
    public partial class ClientLobby : CustomForm
    {
        public bool ReturnToMainOnClose { get; set; } = true;
        private ClientConnection connection = new ClientConnection();

        public ClientLobby()
        {
            InitializeComponent();
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            connection.Disconnect();
            this.Close();
        }
        private async void btn_search_Click(object sender, EventArgs e)
        {
            string ip = textBox1.Text.Trim();

            if (!System.Net.IPAddress.TryParse(ip, out _))
            {
                MessageBox.Show("Invalid IP Address", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btn_search.Enabled = false;
            lblStatus.Text = "Checking server...";

            bool reachable;

            try
            {
                reachable = await connection.TryConnectAsync(ip, 5000);
            }
            catch
            {
                reachable = false;
            }

            btn_search.Enabled = true;

            if (reachable)
            {
                lblStatus.Text = "Server is online ✅";

                await connection.ConnectAsync(ip, 5000);
            }
            else
            {
                lblStatus.Text = "Server not reachable ❌";
            }
        }

        private void btn_JoinRequest_Click(object sender, EventArgs e)
        {

        }
    }
}
