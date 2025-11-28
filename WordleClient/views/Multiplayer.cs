using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordleClient.libraries.CustomControls;
using WordleClient.libraries.StateFrom;
using static System.Windows.Forms.AxHost;

namespace WordleClient.views
{
    public partial class Multiplayer : CustomForm
    {
        int targetY;
        System.Windows.Forms.Timer? dropTimer;
        int frame = 0;
        int duration = 70;
        int startY;
        public Multiplayer()
        {
            InitializeComponent();
            this.Load += Multiplayer_Load;
        }
        private void Multiplayer_Load(object? sender, EventArgs e)
        {
            targetY = this.Top;
            startY = -this.Height;
            this.Top = startY;
            dropTimer = new System.Windows.Forms.Timer();
            dropTimer.Interval = 15;
            dropTimer.Tick += AnimateDrop;
            dropTimer.Start();
        }
        private void AnimateDrop(object? sender, EventArgs e)
        {
            frame++;
            double t = (double)frame / duration;
            if (t >= 1)
            {
                this.Top = targetY;
                if (dropTimer != null)
                    dropTimer.Stop();
                return;
            }
            double eased = 1 - Math.Pow(2, -10 * t);
            int newY = startY + (int)((targetY - startY) * eased);
            this.Top = newY;
        }
        private void customButton1_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Close();
        }

        private void customButtonAnimation1_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
        }

        private void customButtonAnimation2_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
        }
    }
}
