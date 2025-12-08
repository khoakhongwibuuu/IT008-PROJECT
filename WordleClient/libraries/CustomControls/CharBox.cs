using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WordleClient.libraries.CustomControls
{
    public class CharBox : UserControl
    {
        private readonly Label lbl;

        private int borderRadius = 8;
        private Color borderColor = SystemColors.ControlDark;
        private int borderSize = 1;

        // === Cursor fields ===
        private bool _showCursor = false;
        private bool _cursorVisible = false;
        private readonly System.Windows.Forms.Timer blinkTimer;

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

            Controls.Add(lbl);
            Size = new Size(50, 50);
            Padding = new Padding(borderSize);

            UpdateRegion();

            // === blinking cursor timer ===
            blinkTimer = new System.Windows.Forms.Timer();
            blinkTimer.Interval = 500; // blinking duration
            blinkTimer.Tick += (s, e) =>
            {
                if (_showCursor)
                {
                    _cursorVisible = !_cursorVisible;
                    Invalidate();
                }
            };
        }

        // ===== Character Handling =====
        public void SetCharacter(char ch)
        {
            if (ch == '\0' || ch == '-')
                lbl.Text = string.Empty;
            else
                lbl.Text = ch.ToString();
        }

        public string Character
        {
            get => lbl.Text;
            set => lbl.Text = string.IsNullOrEmpty(value) ? string.Empty : value.Substring(0, 1);
        }

        public void SetBackgroundColor(Color color)
        {
            BackColor = color;
            Invalidate();
        }

        // ===== Cursor Control =====
        public void ShowCursor(bool show)
        {
            _showCursor = show;

            if (show)
            {
                _cursorVisible = true;   // dot visible immediately
                blinkTimer.Stop();
                blinkTimer.Start();
            }
            else
            {
                blinkTimer.Stop();
                _cursorVisible = false;
            }

            Invalidate();
        }

        // ====== Draw Control ======
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0) return;

            using GraphicsPath path = CreateRoundRect(rect, borderRadius);

            using (var brush = new SolidBrush(BackColor))
                g.FillPath(brush, path);

            if (borderSize > 0)
                using (var pen = new Pen(borderColor, borderSize))
                    g.DrawPath(pen, path);

            // === draw blinking cursor dot ===
            if (_showCursor && _cursorVisible)
            {
                int size = 9;
                g.FillEllipse(
                    Brushes.Red,
                    (Width - size) / 2,
                    Height - size - 5,
                    size,
                    size
                );
            }
        }

        // === Border radius properties ===
        [Category("Appearance")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; UpdateRegion(); Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int BorderSize
        {
            get => borderSize;
            set { borderSize = value; Padding = new Padding(value); UpdateRegion(); Invalidate(); }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0)
            {
                Region = null;
                return;
            }

            using GraphicsPath path = CreateRoundRect(rect, borderRadius);
            Region?.Dispose();
            Region = new Region(path);
        }

        private static GraphicsPath CreateRoundRect(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(r);
                return path;
            }

            int d = radius * 2;
            Rectangle arc = new Rectangle(r.Location, new Size(d, d));

            path.AddArc(arc, 180, 90);

            arc.X = r.Right - d;
            path.AddArc(arc, 270, 90);

            arc.Y = r.Bottom - d;
            path.AddArc(arc, 0, 90);

            arc.X = r.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
