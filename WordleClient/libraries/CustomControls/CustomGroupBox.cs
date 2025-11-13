using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WordleClient.libraries.CustomControls
{
    public class CustomGroupBox : GroupBox
    {
        //Fields
        private int borderRadius = 15;
        private int borderSize = 2;
        private Color borderColor = Color.Teal;
        private Color backgroundColor = Color.White;
        private Color textColor = Color.Black;
        private ContentAlignment titleAlign = ContentAlignment.TopLeft;
        private int titlePadding = 10;
        //Properties
        [Category("Custom GroupBox")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = Math.Max(0, value); Invalidate(); }
        }
        [Category("Custom GroupBox")]
        public int BorderSize
        {
            get => borderSize;
            set { borderSize = Math.Max(0, value); Invalidate(); }
        }
        [Category("Custom GroupBox")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }
        [Category("Custom GroupBox")]
        public Color BackgroundColor
        {
            get => backgroundColor;
            set { backgroundColor = value; Invalidate(); }
        }
        [Category("Custom GroupBox")]
        public Color TextColor
        {
            get => textColor;
            set { textColor = value; Invalidate(); }
        }
        [Category("Custom GroupBox")]
        public ContentAlignment TitleAlign
        {
            get => titleAlign;
            set { titleAlign = value; Invalidate(); }
        }
        [Category("Custom GroupBox")]
        public int TitlePadding
        {
            get => titlePadding;
            set { titlePadding = value; Invalidate(); }
        }
        //Constructor
        public CustomGroupBox()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            ResizeRedraw = true;
            BackColor = Color.Transparent;
        }
        //Boder Radius
        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curve = radius * 2f;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curve, curve, 180, 90);
            path.AddArc(rect.Right - curve, rect.Y, curve, curve, 270, 90);
            path.AddArc(rect.Right - curve, rect.Bottom - curve, curve, curve, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curve, curve, curve, 90, 90);
            path.CloseFigure();
            return path;
        }
        //Start paint
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //Paint surface and border
            Rectangle rectSurface = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            using (GraphicsPath pathSurface = GetRoundPath(rectSurface, borderRadius))
            using (SolidBrush brushSurface = new SolidBrush(backgroundColor))
            {
                Region = new Region(pathSurface);
                e.Graphics.FillPath(brushSurface, pathSurface);
            }
            //Calculate text position
            SizeF textSize = e.Graphics.MeasureString(Text, Font);
            float textY = titlePadding;
            float textX = titleAlign switch
            {
                ContentAlignment.TopCenter => (Width - textSize.Width) / 2,
                ContentAlignment.TopRight => Width - textSize.Width - titlePadding,_=> titlePadding
            };
            //Paint text
            using (SolidBrush brushText = new SolidBrush(textColor))
                e.Graphics.DrawString(Text, Font, brushText, textX, textY);
            //Paint border
            using (GraphicsPath pathBorder = GetRoundPath(rectBorder, borderRadius - borderSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(penBorder, pathBorder);
            }
        }
    }
}
