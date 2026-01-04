namespace WordleClient.libraries.CustomControls
{
    public partial class AlertBox : CustomForm
    {
        private System.Windows.Forms.Timer autoCloseTimer;
        public AlertBox(int interval, bool isDarkMode)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
            autoCloseTimer = new System.Windows.Forms.Timer();
            autoCloseTimer.Tick += AutoCloseTimer_Tick;
            autoCloseTimer.Interval = interval;
            if (isDarkMode)
            {
                this.customGroupBox1.BackgroundColor = Color.FromArgb(25, 26, 36);
                this.customGroupBox1.BorderColor = Color.White;
                this.lbl_Caption.ForeColor = Color.White;
                this.lbl_Content.ForeColor = Color.LightGray;
            }
            else
            {
                this.customGroupBox1.BackgroundColor = Color.White;
                this.customGroupBox1.BorderColor = Color.Black;
                this.lbl_Caption.ForeColor = Color.Black;
                this.lbl_Content.ForeColor = Color.Black;
            }
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
                case MessageBoxIcon.None:
                    customPictureBox1.Image = Properties.Resources.Tick;
                    break;
                default:
                    customPictureBox1.Image = null;
                    break;
            }
            int targetX = parent.Right - this.Width - 20;
            int startY = parent.Top + 50;
            this.Location = new Point(targetX, startY);
            this.Show();
            autoCloseTimer.Start();
        }
    }
}