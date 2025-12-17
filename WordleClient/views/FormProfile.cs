using WordleClient.libraries.CustomControls;
using WordleClient.libraries.StateFrom;

namespace WordleClient.views
{
    public partial class FormProfile : CustomForm
    {
        public FormProfile()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Close();
        }
        private void LoadAvatarList()
        {
            var avatarBoxes = new List<CustomPictureBox>
            {
                customPictureBox2, customPictureBox3, customPictureBox4,
                customPictureBox5, customPictureBox6, customPictureBox7,
                customPictureBox8, customPictureBox9
            };
            for (int i = 0; i < avatarBoxes.Count; i++)
            {
                var pb = avatarBoxes[i];
                int avatarIndex = i;
                pb.Image = Properties.Resources.ResourceManager.GetObject("Avatar" + avatarIndex) as Image;
                pb.Click += (s, e) =>
                {
                    if (ProfileState.Current != null)
                    {
                        CustomSound.PlayClick();
                        ProfileState.Current.AvatarPath = "Avatar" + avatarIndex;
                        ProfileState.Save();
                        customPictureBox1.Image = pb.Image;
                    }
                };
            }
        }
        private void FormProfile_Load(object sender, EventArgs e)
        {
            ProfileState.Load();
            LoadAvatarList();
            var currentProfile = ProfileState.Current ?? new ProfileState();
            label3.Text = currentProfile.Nickname;
            customPictureBox1.Image = ProfileState.GetAvatar();
            CenterLabel3();
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateNickname();
                e.SuppressKeyPress = true;
            }
        }
        private void UpdateNickname()
        {
            string newName = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(newName) && ProfileState.Current != null)
            {
                ProfileState.Current.Nickname = newName;
                ProfileState.Save();
                label3.Text = newName;
                CenterLabel3();
            }
        }
        private void CenterLabel3()
        {
            Control? parentControl = label3.Parent;
            if (parentControl != null)
            {
                if (!label3.AutoSize)
                {
                    label3.Invalidate();
                    label3.Update();
                }
                int parentWidth = parentControl.ClientSize.Width;
                int labelWidth = label3.Width;
                int newX = (parentWidth - labelWidth) / 2;
                label3.Location = new Point(newX, label3.Location.Y);
            }
        }
    }
}
