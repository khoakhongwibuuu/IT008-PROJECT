using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WordleClient.libraries.CustomControls
{
    // Simple user control that acts as a "box" which can show one character
    // and have its background color changed via the public methods.
    public class CharBox : UserControl
    {
        private readonly Label lbl;
        private int borderRadius = 5;
        private Color borderColor = SystemColors.ControlDark;
        private int borderSize = 1;

        public CharBox()
        {
            DoubleBuffered = true;
            lbl = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                AutoSize = false,
                BackColor = Color.Transparent
            };

            BorderStyle = BorderStyle.None;
            BackColor = SystemColors.Window;
            Controls.Add(lbl);
            Size = new Size(45, 45);
            Padding = new Padding(borderSize);
            UpdateRegion();
        }
        public void SetCharacter(char ch)
        {
            if (ch == '\0')
                lbl.Text = string.Empty;
            else
                lbl.Text = ch.ToString();
        }
        public void SetBackgroundColor(Color color)
        {
            BackColor = color;
            Invalidate();
        }
        public string Character
        {
            get => lbl.Text;
            set => lbl.Text = string.IsNullOrEmpty(value) ? string.Empty : value[0].ToString();
        }

        [Category("Appearance")]
        [DefaultValue(5)]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = Math.Max(0, value);
                UpdateRegion();
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "ControlDark")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(1)]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = Math.Max(0, value);
                Padding = new Padding(borderSize);
                UpdateRegion();
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0) return;

            using GraphicsPath path = GetRoundedRectanglePath(rect, borderRadius);
            using (var brush = new SolidBrush(BackColor))
            {
                g.FillPath(brush, path);
            }

            if (borderSize > 0)
            {
                using var pen = new Pen(borderColor, borderSize);
                g.DrawPath(pen, path);
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
            Invalidate();
        }
        private void UpdateRegion()
        {
            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0)
            {
                Region = null;
                return;
            }

            using GraphicsPath path = GetRoundedRectanglePath(rect, borderRadius);
            Region?.Dispose();
            Region = new Region(path);
        }
        private static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                path.CloseFigure();
                return path;
            }

            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;

            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;

            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;

            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
