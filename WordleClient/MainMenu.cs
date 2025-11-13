using WordleClient.views;
using WordleClient.libraries.StateFrom;
using WordleClient.libraries.CustomControls;

namespace WordleClient
{
    public partial class MainMenu : CustomForm
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (!CustomSound.IsMuted())
            {
                CustomSound.PlayBackgroundLoop();
            }
        }
        private void btn_SinglePlayer_Click_1(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            FormOption formOption = new FormOption();
            formOption.ShowDialog();
        }
        private void btn_MultiPlayer_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            Application.Exit();
        }
        private void btn_Setting_Click_1(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            FormSetting setting = new FormSetting();
            setting.ShowDialog();
        }
        private void minimunsize_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
