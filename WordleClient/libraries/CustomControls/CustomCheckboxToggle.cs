using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WordleClient.libraries.CustomControls
{
    public class CustomCheckboxToggle : Control
    {
        // Fields
        private bool isChecked = false;
        private Image? circleImage = null;
        private string textLabel = "";
        private Color backColorUnchecked = Color.LightGray;
        private Color backColorChecked = Color.MediumSeaGreen;
        private int padding = 10;
        // Properties
        [Category("Custom")]
        public bool Checked
        {
            get => isChecked;
            set { isChecked = value; Invalidate(); }
        }
        [Category("Custom")]
        public Image? CircleImage
        {
            get => circleImage;
            set { circleImage = value; Invalidate(); }
        }
        [Category("Custom")]
        public string TextLabel
        {
            get => textLabel;
            set { textLabel = value; Invalidate(); }
        }
        [Category("Custom")]
        public Color BackColorUnchecked
        {
            get => backColorUnchecked;
            set { backColorUnchecked = value; Invalidate(); }
        }
        [Category("Custom")]
        public Color BackColorChecked
        {
            get => backColorChecked;
            set { backColorChecked = value; Invalidate(); }
        }
        // Constructor
        public CustomCheckboxToggle()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.Size = new Size(200, 40);
            this.Cursor = Cursors.Hand;
        }
        // Paint event
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = this.ClientRectangle;
            // Vẽ nền bo tròn
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = rect.Height / 2;
                path.AddArc(rect.X, rect.Y, rect.Height, rect.Height, 90, 180);
                path.AddArc(rect.Right - rect.Height, rect.Y, rect.Height, rect.Height, 270, 180);
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(isChecked ? backColorChecked : backColorUnchecked))
                {
                    e.Graphics.FillPath(brush, path);
                }
                this.Region = new Region(path);
            }
            //Paint circle
            int circleDiameter = rect.Height - 2 * padding;
            int circleX = isChecked ? rect.Width - circleDiameter - padding : padding;
            int circleY = padding;
            Rectangle circleRect = new Rectangle(circleX, circleY, circleDiameter, circleDiameter);
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillEllipse(brush, circleRect);
            }
            //Paint circle image
            if (circleImage != null)
            {
                e.Graphics.DrawImage(circleImage, new Rectangle(circleRect.X + 2, circleRect.Y + 2, circleRect.Width - 4, circleRect.Height - 4));
            }
            //Paint text
            int textX = isChecked ? padding : padding + circleDiameter + padding;
            int textWidth = rect.Width - circleDiameter - 3 * padding;
            Rectangle textRect = new Rectangle(textX, 0, textWidth, rect.Height);
            TextRenderer.DrawText(e.Graphics, textLabel, this.Font, textRect, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            isChecked = !isChecked;
            Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate(); //Paint again when resize
        }
    }
}
