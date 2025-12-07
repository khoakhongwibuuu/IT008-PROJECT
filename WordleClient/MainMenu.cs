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
            btn_Sound.Image = CustomSound.IsMuted() ? (CustomDarkLight.IsDark ? Properties.Resources.MusicOffDark : Properties.Resources.MusicOffLight) : (CustomDarkLight.IsDark ? Properties.Resources.MusicOnDark : Properties.Resources.MusicOnLight);
            btn_DarkLight.Image = CustomDarkLight.IsDark ? Properties.Resources.Dark : Properties.Resources.Light;
            //ThemeManager.ApplyTheme(this);
        }
        private void btn_SinglePlayer_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            FormOption formOption = new FormOption();
            formOption.FormClosed += FormOption_FormClosed;
            formOption.Show();
            this.Hide();
        }
        private void btn_MultiPlayer_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            Multiplayer multiplayer = new Multiplayer();
            multiplayer.ShowDialog();
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
        private void btn_DarkLight_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            CustomDarkLight.IsDark = !CustomDarkLight.IsDark;
            btn_DarkLight.Image = CustomDarkLight.IsDark ? Properties.Resources.Dark : Properties.Resources.Light;
            btn_DarkLight.boderGradientBottom1 = CustomDarkLight.IsDark ? Color.FromArgb(40, 40, 40) : Color.FromArgb(220, 220, 220);
            btn_DarkLight.boderGradientTop1 = CustomDarkLight.IsDark ? Color.FromArgb(40, 40, 40) : Color.FromArgb(240, 240, 240);
            btn_Sound.Image = CustomSound.IsMuted() ? (CustomDarkLight.IsDark ? Properties.Resources.MusicOffDark : Properties.Resources.MusicOffLight) : (CustomDarkLight.IsDark ? Properties.Resources.MusicOnDark : Properties.Resources.MusicOnLight);
            btn_Sound.boderGradientBottom1 = CustomDarkLight.IsDark ? Color.FromArgb(40, 40, 40) : Color.FromArgb(220, 220, 220);
            btn_Sound.boderGradientTop1 = CustomDarkLight.IsDark ? Color.FromArgb(40, 40, 40) : Color.FromArgb(240, 240, 240);
        }
        private void FormOption_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Only show MainMenu again when FormOption indicates it should return to main.
            if (sender is FormOption fo && fo.ReturnToMainOnClose)
            {
                this.Show();
            }
        }
        private void btn_SingleStats_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            MessageBox.Show("This feature is coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_MultiStats_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            MessageBox.Show("This feature is coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FormHelp help = new FormHelp();
            help.ShowDialog(); 
        }
    }
}