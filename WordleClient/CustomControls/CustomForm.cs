using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WordleClient.CustomControls
{
    public class CustomForm : Form
    {
        private int borderRadius = 30;
        private GraphicsPath roundedPath;
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                UpdateRegion();
            }
        }
        public CustomForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            // Bật double buffering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.Resize += CustomForm_Resize;
            UpdateRegion(); // tạo region lúc đầu
        }
        private void CustomForm_Resize(object? sender, EventArgs e)
        {
            UpdateRegion(); // Cập nhật region khi resize
        }
        // Cập nhật region với bo tròn
        private void UpdateRegion()
        {
            if (roundedPath != null)
            {
                roundedPath.Dispose();
            }
            roundedPath = new GraphicsPath();
            int r = borderRadius;
            roundedPath.AddArc(0, 0, r, r, 180, 90); // góc trên trái
            roundedPath.AddArc(this.Width - r, 0, r, r, 270, 90); // góc trên phải
            roundedPath.AddArc(this.Width - r, this.Height - r, r, r, 0, 90); // góc dưới phải
            roundedPath.AddArc(0, this.Height - r, r, r, 90, 90); // góc dưới trái
            roundedPath.CloseFigure();
            this.Region = new Region(roundedPath);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }
    }
}
