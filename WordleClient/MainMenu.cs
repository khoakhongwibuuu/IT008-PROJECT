using WordleClient.libraries.CustomControls;
using WordleClient.libraries.StateFrom;
using WordleClient.views;

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
        private void btn_SinglePlayer_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            FormOption formOption = new FormOption();
            formOption.FormClosed += FormOption_FormClosed;
            formOption.Show();
            this.Hide();
        }

        private void FormOption_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Only show MainMenu again when FormOption indicates it should return to main.
            if (sender is FormOption fo && fo.ReturnToMainOnClose)
            {
                this.Show();
            }
        }

        private void btn_MultiPlayer_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            MessageBox.Show("Multiplayer mode is under development.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
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