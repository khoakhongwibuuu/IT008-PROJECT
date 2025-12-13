using WordleClient.libraries.CustomControls;
using WordleClient.libraries.StateFrom;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;
using System.Diagnostics;

namespace WordleClient.views
{
    public partial class ServerLobby : CustomForm
    {
        public bool ReturnToMainOnClose { get; set; } = true;

        public ServerLobby()
        {
            InitializeComponent();
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
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
