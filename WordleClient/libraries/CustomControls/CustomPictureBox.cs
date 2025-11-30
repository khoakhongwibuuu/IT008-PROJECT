using System.Drawing.Drawing2D;

namespace WordleClient.libraries.CustomControls
{
    public class CustomPictureBox: PictureBox
    {
        //Fields
        private int boderSize = 2;
        private int boderRadius = 40;
        private float gradientAngle = 90f;
        private Color boderGradientTop = Color.MediumSlateBlue;
        private Color boderGradientBottom = Color.SlateBlue;
        //Constructor
        public CustomPictureBox()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            SizeMode = PictureBoxSizeMode.StretchImage;
           Size = new Size(120, 120);
        }
        //Properties
        public int boderSize1
        {
            get { return boderSize; }
            set
            {
                boderSize = value;
                Invalidate();
            }
        }
        public int boderRadius1
            {
            get { return boderRadius; }
            set
            {
                boderRadius = value;
                Invalidate();
            }
        }
        public float gradientAngle1
        {
            get { return gradientAngle; }
            set
            {
                gradientAngle = value;
                Invalidate();
            }
        }
        public Color boderGradientTop1
        {
            get { return boderGradientTop; }
            set
            {
                boderGradientTop = value;
                Invalidate();
            }
        }
        public Color boderGradientBottom1
        {
            get { return boderGradientBottom; }
            set
            {
                boderGradientBottom = value;
                Invalidate();
            }
        }
        //Methods
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(Width, Height);
        }
        //Start Paint
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var graphics = pe.Graphics;
            var rectangleSmooth = Rectangle.Inflate(ClientRectangle, -1, -1);
            var rectangleBorder = Rectangle.Inflate(ClientRectangle, -boderSize, -boderSize);
            var smoothSize = boderSize > 0 ? boderSize * 3  : 1;
            using (var BoderGadientColor = new LinearGradientBrush(rectangleBorder,boderGradientTop, boderGradientBottom, gradientAngle))
            using (var pathSmooth = new Pen(Parent.BackColor,smoothSize))
            using (var pathRegion = new GraphicsPath())
            using (var pathBorder = new Pen(BoderGadientColor,smoothSize))
            {
                pathRegion.AddEllipse(rectangleSmooth);
                Region  = new Region (pathRegion);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.DrawEllipse(pathSmooth, rectangleSmooth);
                if(boderSize > 0 )
                {
                    graphics.DrawEllipse(pathBorder, rectangleBorder);
                }
            }
            Size = new Size(Width, Height);
        }
    }
}
