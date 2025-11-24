using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using WordleClient.libraries.CustomControls;
namespace WordleClient.libraries.CustomControls
{
    public partial class AlertBox : CustomForm
    {
        // Timers and variables for sliding and auto-closing
        private System.Windows.Forms.Timer slideTimer;
        private System.Windows.Forms.Timer autoCloseTimer;
        private int targetX;
        private int speed = 20;

        public AlertBox()
        {
            InitializeComponent();

            // Form setup
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;

            // Timer trượt vào
            slideTimer = new System.Windows.Forms.Timer();
            slideTimer.Interval = 10;
            slideTimer.Tick += SlideTimer_Tick;

            // Timer tự đóng
            autoCloseTimer = new System.Windows.Forms.Timer();
            autoCloseTimer.Interval = 2500; 
            autoCloseTimer.Tick += AutoCloseTimer_Tick;
        }
        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            if (this.Left > targetX)
            {
                this.Left -= speed;
            }
            else
            {
                slideTimer.Stop();
                autoCloseTimer.Start();
            }
        }
        private void AutoCloseTimer_Tick(object sender, EventArgs e)
        {
            autoCloseTimer.Stop();
            this.Close();
        }
        public void ShowAlert(Form parent, string caption, string content)
        {
            lbl_Caption.Text = caption;
            lbl_Content.Text = content;
            // Locate the form off-screen to the right
            int startX = parent.Right;
            int startY = parent.Top + 50;
            targetX = parent.Right - this.Width - 20;
            this.Location = new Point(startX, startY);
            this.Show();
            slideTimer.Start();
        }
    }
}
