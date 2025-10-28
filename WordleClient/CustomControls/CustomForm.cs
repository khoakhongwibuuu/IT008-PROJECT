using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace WordleClient.CustomControls
{
    public class CustomForm : Form
    {
        private int borderRadius = 30;
        private GraphicsPath? roundedPath;
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
            //Turn on double buffering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.Resize += CustomForm_Resize;
            UpdateRegion(); //Create initial region
        }
        private void CustomForm_Resize(object? sender, EventArgs e)
        {
            UpdateRegion(); //Update region on resize
        }
        //Update the region when border radius or size changes
        private void UpdateRegion()
        {
            if (roundedPath != null)
            {
                roundedPath.Dispose();
            }
            roundedPath = new GraphicsPath();
            int r = borderRadius;
            roundedPath.AddArc(0, 0, r, r, 180, 90); 
            roundedPath.AddArc(this.Width - r, 0, r, r, 270, 90); 
            roundedPath.AddArc(this.Width - r, this.Height - r, r, r, 0, 90); 
            roundedPath.AddArc(0, this.Height - r, r, r, 90, 90); 
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
