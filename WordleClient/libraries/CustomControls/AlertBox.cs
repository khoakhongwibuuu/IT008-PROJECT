using System;
using System.Drawing;
using System.Windows.Forms;
using WordleClient.libraries.CustomControls;

namespace WordleClient.libraries.CustomControls
{
    public partial class AlertBox : CustomForm
    {
        private System.Windows.Forms.Timer autoCloseTimer;

        public AlertBox(int interval)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;

            // Timer tự đóng
            autoCloseTimer = new System.Windows.Forms.Timer();
            autoCloseTimer.Tick += AutoCloseTimer_Tick;
            autoCloseTimer.Interval = interval;
        }

        private void AutoCloseTimer_Tick(object? sender, EventArgs e)
        {
            autoCloseTimer.Stop();
            this.Close();
        }

        public void ShowAlert(Form parent, string caption, string content)
        {
            lbl_Caption.Text = caption;
            lbl_Content.Text = content;

            // Vị trí hiển thị trực tiếp
            int targetX = parent.Right - this.Width - 20;
            int startY = parent.Top + 50;

            this.Location = new Point(targetX, startY);
            this.Show();

            autoCloseTimer.Start();
        }

        public void ShowAlert(Form parent, string caption, string content, MessageBoxIcon icon)
        {
            lbl_Caption.Text = caption;
            lbl_Content.Text = content;

            switch (icon)
            {
                case MessageBoxIcon.Information:
                    customPictureBox1.Image = Properties.Resources.Info;
                    break;
                case MessageBoxIcon.Warning:
                    customPictureBox1.Image = Properties.Resources.Warnning;
                    break;
                case MessageBoxIcon.Error:
                    customPictureBox1.Image = Properties.Resources.Error;
                    break;
                case MessageBoxIcon.Question:
                    customPictureBox1.Image = Properties.Resources.Quest;
                    break;
                default:
                    customPictureBox1.Image = null;
                    break;
            }

            // Vị trí hiển thị trực tiếp
            int targetX = parent.Right - this.Width - 20;
            int startY = parent.Top + 50;

            this.Location = new Point(targetX, startY);
            this.Show();

            autoCloseTimer.Start();
        }
    }
}
