using System;
using System.Drawing;
using System.Windows.Forms;
using WordleClient.libraries.StateFrom;

namespace WordleClient.libraries.CustomControls
{
    public partial class CustomMessageBoxYesNo : CustomForm
    {
        private DialogResult result = DialogResult.No;
        private System.Windows.Forms.Timer timeAnimation;
        private Point originalLocation;
        private bool moveLeft = true;
        private int shakeCount = 0;

        public CustomMessageBoxYesNo()
        {
            InitializeComponent();


            customButtonYes.Click += (s, e) => { CustomSound.PlayClick(); result = DialogResult.Yes; this.Close(); };
            customButtonNo.Click += (s, e) => { CustomSound.PlayClick(); result = DialogResult.No; this.Close(); };

            // Timer cho hiệu ứng lắc lư
            timeAnimation = new System.Windows.Forms.Timer();
            timeAnimation.Interval = 50;
            timeAnimation.Tick += TimeAnimation_Tick;
        }

        private void TimeAnimation_Tick(object? sender, EventArgs e)
        {
            int offset = 5;
            Point loc = this.Location;
            this.Location = moveLeft
                ? new Point(loc.X - offset, loc.Y)
                : new Point(loc.X + offset, loc.Y);

            moveLeft = !moveLeft;
            shakeCount += 1;
            if (shakeCount >= 10)
            {
                timeAnimation.Stop();
                this.Location = originalLocation;
            }
        }

        public static DialogResult Show(Form owner, string content, MessageBoxIcon icon)
        {
            using var msgBox = new CustomMessageBoxYesNo();

            // Set caption và content
            msgBox.lbl_Content.Text = content;

            // Center
            msgBox.lbl_Content.Left = (msgBox.ClientSize.Width - msgBox.lbl_Content.Width) / 2;

            // Option Icon
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    msgBox.customPictureBox1.Image = Properties.Resources.Tick;
                    break;
                case MessageBoxIcon.Error:
                    msgBox.customPictureBox1.Image = Properties.Resources.Error;
                    break;
                case MessageBoxIcon.Warning:
                    msgBox.customPictureBox1.Image = Properties.Resources.Warnning;
                    break;
                case MessageBoxIcon.Question:
                    msgBox.customPictureBox1.Image = Properties.Resources.Quest;
                    break;
                default:
                    msgBox.customPictureBox1.Image = null;
                    break;
            }

            // Display Center
            msgBox.StartPosition = FormStartPosition.Manual;
            msgBox.Location = new Point(
                owner.Location.X + (owner.Width - msgBox.Width) / 2,
                owner.Location.Y + (owner.Height - msgBox.Height) / 2
            );

            // Shake setup
            msgBox.originalLocation = msgBox.Location;
            msgBox.shakeCount = 0;
            msgBox.moveLeft = true;
            msgBox.timeAnimation.Start();
            msgBox.ShowDialog(owner);
            return msgBox.result;
        }
    }
}
