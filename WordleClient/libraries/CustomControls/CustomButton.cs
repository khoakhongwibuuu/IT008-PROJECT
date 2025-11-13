using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WordleClient.libraries.CustomControls
{
    public partial class CustomButton : Control
    {
        // Fields
        private int borderSize = 2;
        private int borderRadius = 20;
        private Color borderColor = Color.FromArgb(153, 214, 214);
        private Color backgroundColor = Color.FromArgb(153, 214, 214);
        private Color textColor = Color.White;
        private Image? buttonImage;
        private int imageSize = 24; //Size of the image
        private ContentAlignment textAlign = ContentAlignment.MiddleCenter;
        // Properties
        [Category("CustomControl")]
        public int BorderSize { get => borderSize; set { borderSize = value; Invalidate(); } }
        [Category("CustomControl")]
        public int BorderRadius { get => borderRadius; set { borderRadius = value; Invalidate(); } }
        [Category("CustomControl")]
        public Color BorderColor { get => borderColor; set { borderColor = value; Invalidate(); } }
        [Category("CustomControl")]
        public Color BackgroundColor { get => backgroundColor; set { backgroundColor = value; Invalidate(); } }
        [Category("CustomControl")]
        public Color TextColor { get => textColor; set { textColor = value; Invalidate(); } }
        [Category("CustomControl")]
        public Image? ButtonImage { get => buttonImage; set { buttonImage = value; Invalidate(); } }
        [Category("CustomControl")]
        public int ImageSize { get => imageSize; set { imageSize = value; Invalidate(); } }
        [Category("CustomControl")]
        public ContentAlignment TextAlign { get => textAlign; set { textAlign = value; Invalidate(); } }
        // Constructor
        public CustomButton()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.Size = new Size(150, 40);
            this.Cursor = Cursors.Hand;
            this.Resize += CustomButton_Resize;
        }
        private void CustomButton_Resize(object? sender, EventArgs e)
        {
            if (borderRadius > this.Height)
            {
                borderRadius = this.Height;
            }
        }
        //Create round rectangle path
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
        //Start paint
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //Fields
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            //Paint surface
            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (SolidBrush brush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillPath(brush, pathSurface);
                this.Region = new Region(pathSurface);
            }
            //Paint border
            if (borderSize > 0)
            {
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            //Pain text and image
            int padding = 8;
            Rectangle textRect = rectSurface;
            if (buttonImage != null)
            {
                Rectangle imageRect = new Rectangle(padding, (this.Height - imageSize) / 2, imageSize, imageSize);
                e.Graphics.DrawImage(buttonImage, imageRect);
                textRect = new Rectangle(imageRect.Right + padding, 0, this.Width - imageRect.Right - 2 * padding, this.Height);
            }
            //Text alignment
            TextFormatFlags flags = TextFormatFlags.SingleLine;
            switch (textAlign)
            {
                case ContentAlignment.TopLeft: flags |= TextFormatFlags.Top | TextFormatFlags.Left; break;
                case ContentAlignment.TopCenter: flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter; break;
                case ContentAlignment.TopRight: flags |= TextFormatFlags.Top | TextFormatFlags.Right; break;
                case ContentAlignment.MiddleLeft: flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left; break;
                case ContentAlignment.MiddleCenter: flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter; break;
                case ContentAlignment.MiddleRight: flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right; break;
                case ContentAlignment.BottomLeft: flags |= TextFormatFlags.Bottom | TextFormatFlags.Left; break;
                case ContentAlignment.BottomCenter: flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter; break;
                case ContentAlignment.BottomRight: flags |= TextFormatFlags.Bottom | TextFormatFlags.Right; break;
            }
            //Draw text
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, textRect, textColor, flags);
        }
        //Animation on mouse down
        private Color originalBack;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            originalBack = backgroundColor;
            backgroundColor = ControlPaint.Dark(backgroundColor);
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            backgroundColor = originalBack;
            Invalidate();
        }
    }
}
