using System.Drawing.Drawing2D;

namespace WordleClient.libraries.CustomControls
{
    public partial class CustomPanel : UserControl
    {
        private int borderRadius = 30;
        private float gradientAngle = 90F;
        private Color gradientTopColor = Color.DodgerBlue;
        private Color gradientBottomColor = Color.CadetBlue;
        // Constructor
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.DoubleBuffered = true;
            this.Name = "CustomPanel";
            this.Load += new System.EventHandler(this.CustomPanel_Load);
            this.ResumeLayout(false);
        }
        private void CustomPanel_Load(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public CustomPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new Size(350, 200);
        }
        public int BorderRadius { get => borderRadius; set { borderRadius = value; this.Invalidate(); } }
        public float GradientAngle { get => gradientAngle; set { gradientAngle = value; this.Invalidate(); } }
        public Color GradientTopColor { get => gradientTopColor; set { gradientTopColor = value; this.Invalidate(); } }
        public Color GradientBottomColor { get => gradientBottomColor; set { gradientBottomColor = value; this.Invalidate(); } }
        //Methods
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this.GradientTopColor, this.GradientBottomColor, this.gradientAngle);
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(brush, ClientRectangle);
            // Border Radius
            RectangleF rectF = new RectangleF(0, 0, this.Width, this.Height);
            if (borderRadius > 2)
            {
                using (GraphicsPath path = GetFigurePath(rectF, borderRadius))
                {
                    if (Parent != null)
                    {
                        using (Pen pen = new Pen(Parent.BackColor, 2))
                        {
                            this.Region = new Region(path);
                            e.Graphics.DrawPath(pen, path);
                        }
                    }
                }
            }
            else
            {
                this.Region = new Region(rectF);
            }
        }
    }
}
