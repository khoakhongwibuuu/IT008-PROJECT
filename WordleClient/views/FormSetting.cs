using WordleClient.libraries.CustomControls;
using WordleClient.libraries.StateFrom;

namespace WordleClient.views
{
    public partial class FormSetting : CustomForm
    {
        public FormSetting()
        {
            InitializeComponent();
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Close();
        }
        private void btn_Sound_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            CustomSound.ToggleMute();
            if (CustomSound.IsMuted())
            {
                btn_Sound.Image = Properties.Resources.soundOFFicon;
            }
            else
            {
                btn_Sound.Image = Properties.Resources.SoundONicon;
            }
        }
        private void FormSetting_Load(object sender, EventArgs e)
        {
            btn_Sound.Image = CustomSound.IsMuted() ? Properties.Resources.soundOFFicon : Properties.Resources.SoundONicon;
            btn_DarkLight.Checked = CustomDarkLight.IsDark;
            if (CustomDarkLight.IsDark)
            {
                btn_DarkLight.CircleImage = Properties.Resources.Light;
                btn_DarkLight.TextLabel = "Light";
                this.BackColor = Color.FromArgb(34, 34, 34);
            }
            else
            {
                btn_DarkLight.CircleImage = Properties.Resources.Dark;
                btn_DarkLight.TextLabel = "Dark";
                this.BackColor = Color.White;
            }
        }
        private void btn_DarkLight_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            CustomDarkLight.IsDark = !CustomDarkLight.IsDark;
            if (CustomDarkLight.IsDark)
            {
                btn_DarkLight.CircleImage = Properties.Resources.Light;
                btn_DarkLight.TextLabel = "Light";
                this.BackColor = Color.FromArgb(34, 34, 34);
            }
            else
            {
                btn_DarkLight.CircleImage = Properties.Resources.Dark;
                btn_DarkLight.TextLabel = "Dark";
                this.BackColor = Color.White;
            }
        }
    }
}
