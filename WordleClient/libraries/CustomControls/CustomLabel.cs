using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WordleClient.libraries.CustomControls
{
    public class CustomLabel : Control
    {
        //Fields:
        private Color startColor = Color.MediumSlateBlue;
        private Color endColor = Color.MediumPurple;
        private Color borderColor = Color.White;
        private float boderRadius = 3f;
        private int shadowOffset = 4;
        //Properties:
        [Category("Custom")]
        public Color StartColor
        {
            get => startColor;
            set { startColor = value; Invalidate(); } // Trigger repaint
        }
        [Category("Custom")]
        public Color EndColor
        {
            get => endColor;
            set { endColor = value; Invalidate(); }
        }
        [Category("Custom")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }
        [Category("Custom")]
        public float BoderRadius
        {
            get => boderRadius;
            set { boderRadius = Math.Max(0, value); Invalidate(); } // Ensure non-negative
        }

        [Category("Custom")]
        public int ShadowOffset
        {
            get => shadowOffset;
            set { shadowOffset = Math.Max(0, value); Invalidate(); } // Ensure non-negative
        }
        //Constructor:
        public CustomLabel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.Size = new Size(100, 100);
            this.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.ForeColor = Color.White;
        }
        //Start paint:
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Enable anti-aliasing
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            //Create circle region
            int diameter = Math.Min(this.Width, this.Height);
            Rectangle rectCircle = new Rectangle(
                (this.Width - diameter) / 2,
                (this.Height - diameter) / 2,
                diameter - 1,
                diameter - 1
            );
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(rectCircle);
            this.Region = new Region(path);
            //Draw shadow
            if (shadowOffset > 0)
            {
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(60, Color.Black)))
                {
                    Rectangle shadowRect = rectCircle;
                    shadowRect.Offset(shadowOffset, shadowOffset);
                    e.Graphics.FillEllipse(shadowBrush, shadowRect);
                }
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(rectCircle, startColor, endColor, LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillEllipse(brush, rectCircle);
            }
            //Draw border
            if (boderRadius > 0)
            {
                using (Pen pen = new Pen(borderColor, boderRadius))
                {
                    e.Graphics.DrawEllipse(pen, rectCircle);
                }
            }
            //Draw text centered
            StringFormat stringFomat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            //Draw text
            using (SolidBrush textBrush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.DrawString(this.Text, this.Font, textBrush, rectCircle, stringFomat);
            }
        }
    }
}
