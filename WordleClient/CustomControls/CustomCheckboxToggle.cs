using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
namespace WordleClient.CustomControls
{
    public class CustomCheckboxToggle : CheckBox
    {
        //Fields
        private Color onBackColor = Color.MediumSlateBlue;
        private Color offBackColor = Color.Gray;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offToggleColor = Color.Gainsboro;
        private bool solidStyle = true;
        //Constructor
        public CustomCheckboxToggle()
        {
            this.MinimumSize = new Size(45, 22);
        }
        //Properties
        [Category("Custom Appearance")]
        public Color OnBackColor
        {
            get { return onBackColor; }
            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }
        [Category("Custom Appearance")]
        public Color OffBackColor
        {
            get { return offBackColor; }
            set
            {
                offBackColor = value;
                this.Invalidate();
            }
        }
        [Category("Custom Appearance")]
        public Color OnToggleColor
        {
            get { return onToggleColor; }
            set
            {
                onToggleColor = value;
                this.Invalidate();
            }
        }
        [Category("Custom Appearance")]
        public Color OffToggleColor
        {
            get { return offToggleColor; }
            set
            {
                offToggleColor = value;
                this.Invalidate();
            }
        }
        [Category("Custom Appearance")]
        public bool SolidStyle
        {
            get { return solidStyle; }
            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }
        //Methods
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
            if (this.Checked)
            {
                if (solidStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(OffToggleColor), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(OffToggleColor, 2), GetFigurePath());
                }
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else
            {
                if(solidStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(OnBackColor), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(OnBackColor, 2), GetFigurePath());
                }
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));

            }
        }
    }
}
