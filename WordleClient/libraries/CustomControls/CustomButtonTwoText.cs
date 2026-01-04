using System.ComponentModel;
using System.Drawing.Drawing2D;
namespace WordleClient.libraries.CustomControls
{
    public class CustomButtonTwoText : Control
    {
        private string leftText = "Left";
        private string rightText = "Right";
        private Color leftBackColor = Color.MediumSlateBlue;
        private Color rightBackColor = Color.SlateBlue;
        private Color borderColor = Color.DarkSlateBlue;
        private int borderSize = 2;
        private int borderRadius = 20;
        [Category("Custom")]
        public string LeftText
        {
            get => leftText;
            set
            {
                leftText = value;
                Invalidate();
            }
        }
        [Category("Custom")]
        public string RightText
        {
            get => rightText;
            set
            {
                rightText = value;
                Invalidate();
            }
        }
        [Category("Custom")]
        public Color LeftBackColor
        {
            get => leftBackColor;
            set
            {
                leftBackColor = value;
                Invalidate();
            }
        }
        [Category("Custom")]
        public Color RightBackColor
        {
            get => rightBackColor;
            set
            {
                rightBackColor = value;
                Invalidate();
            }
        }
        [Category("Custom")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }
        [Category("Custom")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                Invalidate();
            }
        }
        [Category("Custom")]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }
        public CustomButtonTwoText()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.Size = new Size(200, 50);
            this.Cursor = Cursors.Hand;
        }
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2f;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.Region = new Region(GetFigurePath(this.ClientRectangle, borderRadius));
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int midX = rectSurface.Width / 2;
            Rectangle leftRect = new Rectangle(rectSurface.X, rectSurface.Y, midX, rectSurface.Height);
            using (GraphicsPath pathLeft = GetFigurePath(leftRect, borderRadius)) using (SolidBrush brushLeft = new SolidBrush(leftBackColor))
            {
                e.Graphics.FillRectangle(brushLeft, leftRect);
            }
            Rectangle rightRect = new Rectangle(rectSurface.X + midX, rectSurface.Y, midX, rectSurface.Height);
            using (SolidBrush brushRight = new SolidBrush(rightBackColor))
            {
                e.Graphics.FillRectangle(brushRight, rightRect);
            }
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize)) using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(penBorder, pathBorder);
            }
            using (Pen linePen = new Pen(borderColor, 1))
            {
                int lineX = midX;
                e.Graphics.DrawLine(linePen, lineX, 4, lineX, rectSurface.Height - 4);
            }
            TextRenderer.DrawText(e.Graphics, leftText, this.Font, leftRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            TextRenderer.DrawText(e.Graphics, rightText, this.Font, rightRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
        private Color originalLeft, originalRight;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            originalLeft = leftBackColor;
            originalRight = rightBackColor;
            leftBackColor = ControlPaint.Dark(leftBackColor);
            rightBackColor = ControlPaint.Dark(rightBackColor);
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            leftBackColor = originalLeft;
            rightBackColor = originalRight;
            Invalidate();
        }
    }
}