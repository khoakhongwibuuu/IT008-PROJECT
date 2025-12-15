using WordleClient.libraries.CustomControls;
using WordleClient.libraries.network;
using WordleClient.libraries.StateFrom;

namespace WordleClient.views
{
    public partial class ServerLobby : CustomForm
    {
        public bool ReturnToMainOnClose { get; set; } = true;

        private const int ServerPort = 5000;

        public ServerLobby()
        {
            InitializeComponent();
        }

        private void ServerLobby_Load(object sender, EventArgs e)
        {
            try
            {
                if (!ServerManager.IsRunning)
                {
                    ServerManager.Start(ServerPort);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to start server:\n" + ex.Message,
                    "Server Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();
            }
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();

            // TODO: broadcast START_GAME_Packet to clients
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            if (ServerManager.IsRunning)
            {
                ServerManager.Stop();
            }
            this.Close();
        }
    }
}
