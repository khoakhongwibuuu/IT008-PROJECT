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
            //CustomSound.ToggleMute();
            ProfileState.Load();
            customPictureBox1.Image = ProfileState.GetAvatar();

            if (!CustomSound.IsMuted()) CustomSound.PlayBackgroundLoop();
            btn_Sound.Image = CustomSound.IsMuted() 
                ? (CustomDarkLight.IsDark ? Properties.Resources.MusicOffDark : Properties.Resources.MusicOffLight) 
                : (CustomDarkLight.IsDark ? Properties.Resources.MusicOnDark : Properties.Resources.MusicOnLight);
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            if (CustomMessageBoxYesNo.Show(this, "Are you sure you want to exit?", MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void minimunsize_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_Sound_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            CustomSound.ToggleMute();
            btn_Sound.Image = CustomSound.IsMuted() ? (CustomDarkLight.IsDark ? Properties.Resources.MusicOffDark : Properties.Resources.MusicOffLight) : (CustomDarkLight.IsDark ? Properties.Resources.MusicOnDark : Properties.Resources.MusicOnLight);
        }
        private void btn_SinglePlayer_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            FormOption formOption = new FormOption();
            formOption.FormClosed += FormOption_FormClosed;
            formOption.Show();
            this.Hide();
        }
        private void btn_Client_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            ClientLobby clientLobby = new ClientLobby();
            clientLobby.FormClosed += ClientLobby_FormClosed;
            clientLobby.Show();
            this.Hide();
        }

        private void btn_Server_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            ServerLobby serverLobby = new ServerLobby();
            serverLobby.FormClosed += ServerLobby_FormClosed;
            serverLobby.Show();
            this.Hide();
        }

        private void btn_Stats_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Hide();
            Statistic statistic = new Statistic();
            statistic.ShowDialog();
            this.Show();
        }
        private void FormOption_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Only show MainMenu again when FormOption indicates it should return to main.
            if (sender is FormOption fo && fo.ReturnToMainOnClose)
            {
                this.Show();
            }
        }
        private void ClientLobby_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Only show MainMenu again when ClientLobby indicates it should return to main.
            if (sender is ClientLobby cl && cl.ReturnToMainOnClose)
            {
                this.Show();
            }
        }
        private void ServerLobby_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Only show MainMenu again when ServerLobby indicates it should return to main.
            if (sender is ServerLobby sl && sl.ReturnToMainOnClose)
            {
                this.Show();
            }
        }
        private void customPictureBox1_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            FormProfile formProfile = new FormProfile();
            formProfile.ShowDialog();
            customPictureBox1.Image = ProfileState.GetAvatar();
        }
        private void btn_Guide_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            FormHelp help = new FormHelp();
            help.ShowDialog();
        }
    }
}