using WordleClient.libraries.CustomControls;
using WordleClient.libraries.StateFrom;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.network;
using System.Diagnostics;

namespace WordleClient.views
{
    public partial class ServerLobby : CustomForm
    {
        public bool ReturnToMainOnClose { get; set; } = true;

        private ServerListener serverListener = new ServerListener();
        private CancellationTokenSource? serverCts;
        private Task? serverTask;

        public ServerLobby()
        {
            InitializeComponent();
        }
        private void ServerLobby_Load(object sender, EventArgs e)
        {
            try
            {
                serverCts = new CancellationTokenSource();

                serverTask = serverListener.StartAsync(5000);

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
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            serverListener.Stop();
            this.Close();
        }
        private void btn_StartGame_Click(object sender, EventArgs e)
        {

        }
        private void btn_CloseServer_Click(object sender, EventArgs e)
        {

        }
    }
}
