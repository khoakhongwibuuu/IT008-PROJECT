using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace WordleClient
{
    public partial class CustomButtonAnimation : Control
    {
        //Thuộc tính:
        private int borderSize = 2;
        private int borderRadius = 20;
        private Color borderColor = Color.FromArgb(153, 214, 214);
        private Color backgroundColor = Color.FromArgb(153, 214, 214);
        private Color textColor = Color.White;
        private Image? buttonImage;
        private int imageSize = 24;
        private ContentAlignment textAlign = ContentAlignment.MiddleCenter;
        //Hiệu ứng sọc:
        private System.Windows.Forms.Timer stripeTimer;
        private int stripeOffset = 0;
        private bool enableStripe = true;
        private int stripeSpeed = 4;
        private Color stripeColor1 = Color.FromArgb(180, 255, 255, 255);
        private Color stripeColor2 = Color.FromArgb(0, 255, 255, 255);
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
        [Category("Animation")]
        public bool EnableStripe { get => enableStripe; set { enableStripe = value; Invalidate(); } }
        [Category("Animation")]
        public int StripeSpeed { get => stripeSpeed; set { stripeSpeed = value; Invalidate(); } }
        // Constructor
        public CustomButtonAnimation()
        {
            this.Size = new Size(150, 40);
            this.DoubleBuffered = true;
            this.Cursor = Cursors.Hand;
            this.Resize += CustomControl1_Resize;
            // Timer hiệu ứng sọc
            stripeTimer = new Timer();
            stripeTimer.Interval = 30;
            stripeTimer.Tick += (s, e) =>
            {
                stripeOffset = (stripeOffset + stripeSpeed) % 40;
                Invalidate();
            };
            stripeTimer.Start();
        }
        private void CustomControl1_Resize(object? sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                borderRadius = this.Height;
        }
        //Path bo tròn:
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
        //Vẽ control:
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            //Nền cơ bản:
            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
            using (SolidBrush brush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillPath(brush, pathSurface);
                this.Region = new Region(pathSurface);
            //Hiệu ứng sọc động
                if (enableStripe)
                {
                    DrawMovingStripes(e.Graphics, rectSurface, borderRadius);
                }             
            }
            // Viền:
            if (borderSize > 0)
            {
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            // Ảnh + text
            int padding = 8;
            Rectangle textRect = rectSurface;
            if (buttonImage != null)
            {
                Rectangle imageRect = new Rectangle(padding, (this.Height - imageSize) / 2, imageSize, imageSize);
                e.Graphics.DrawImage(buttonImage, imageRect);
                textRect = new Rectangle(imageRect.Right + padding, 0, this.Width - imageRect.Right - 2 * padding, this.Height);
            }
            // Text align
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
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, textRect, textColor, flags);
        }
        //Hàm vẽ hiệu ứng sọc:
        private void DrawMovingStripes(Graphics g, Rectangle rect, int radius)
        {
            //tạo brush dạng chéo 45:
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, 40, 40), stripeColor1,stripeColor2, 45f))
            {
            //tạo texture pattern:
                using (Bitmap bmp = new Bitmap(40, 40))
                using (Graphics g2 = Graphics.FromImage(bmp))
                {
                    g2.FillRectangle(brush, 0, 0, 40, 40);
                    TextureBrush tBrush = new TextureBrush(bmp);
                    tBrush.TranslateTransform(stripeOffset, 0);
                    tBrush.WrapMode = WrapMode.Tile;
                    using (GraphicsPath path = GetFigurePath(rect, radius))
                    {
                        g.FillPath(tBrush, path);
                    }
                }
            }
        }
        //Hiệu ứng nhấn:
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
