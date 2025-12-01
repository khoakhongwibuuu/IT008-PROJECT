using WordleClient.views;
using WordleClient.libraries.StateFrom;
using WordleClient.libraries.CustomControls;

namespace WordleClient
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            minimunsize = new CustomPictureBox();
            btn_DarkLight = new CustomPictureBox();
            customLabel1 = new CustomLabel();
            customLabel6 = new CustomLabel();
            customLabel8 = new CustomLabel();
            customLabel9 = new CustomLabel();
            customLabel7 = new CustomLabel();
            customLabel2 = new CustomLabel();
            customLabel3 = new CustomLabel();
            customLabel4 = new CustomLabel();
            customLabel5 = new CustomLabel();
            customLabel10 = new CustomLabel();
            btn_Sound = new CustomPictureBox();
            customPanel1 = new CustomPanel();
            btn_SinglePlayer = new CustomButtonAnimation();
            btn_MultiPlayer = new CustomButtonAnimation();
            btn_SingleStats = new CustomButtonAnimation();
            btn_MultiStats = new CustomButtonAnimation();
            btn_Exit = new CustomButtonAnimation();
            exit = new CustomPictureBox();
            customPictureBox1 = new CustomPictureBox();
            ((System.ComponentModel.ISupportInitialize)minimunsize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_DarkLight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Sound).BeginInit();
            customPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // minimunsize
            // 
            minimunsize.boderGradientBottom1 = Color.White;
            minimunsize.boderGradientTop1 = Color.White;
            minimunsize.boderRadius1 = 40;
            minimunsize.boderSize1 = 0;
            minimunsize.gradientAngle1 = 90F;
            minimunsize.Image = (Image)resources.GetObject("minimunsize.Image");
            minimunsize.Location = new Point(1038, 11);
            minimunsize.Margin = new Padding(3, 2, 3, 2);
            minimunsize.Name = "minimunsize";
            minimunsize.Size = new Size(27, 26);
            minimunsize.SizeMode = PictureBoxSizeMode.StretchImage;
            minimunsize.TabIndex = 5;
            minimunsize.TabStop = false;
            minimunsize.Click += minimunsize_Click;
            // 
            // btn_DarkLight
            // 
            btn_DarkLight.boderGradientBottom1 = Color.White;
            btn_DarkLight.boderGradientTop1 = Color.White;
            btn_DarkLight.boderRadius1 = 40;
            btn_DarkLight.boderSize1 = 2;
            btn_DarkLight.Cursor = Cursors.Hand;
            btn_DarkLight.gradientAngle1 = 90F;
            btn_DarkLight.Image = Properties.Resources.Light;
            btn_DarkLight.Location = new Point(1045, 574);
            btn_DarkLight.Margin = new Padding(3, 2, 3, 2);
            btn_DarkLight.Name = "btn_DarkLight";
            btn_DarkLight.Size = new Size(60, 60);
            btn_DarkLight.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_DarkLight.TabIndex = 11;
            btn_DarkLight.TabStop = false;
            btn_DarkLight.Click += btn_DarkLight_Click;
            // 
            // customLabel1
            // 
            customLabel1.BoderRadius = 3F;
            customLabel1.BorderColor = Color.White;
            customLabel1.EndColor = Color.Blue;
            customLabel1.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel1.ForeColor = Color.White;
            customLabel1.Location = new Point(202, 86);
            customLabel1.Margin = new Padding(3, 2, 3, 2);
            customLabel1.Name = "customLabel1";
            customLabel1.ShadowOffset = 4;
            customLabel1.Size = new Size(129, 85);
            customLabel1.StartColor = Color.FromArgb(128, 255, 255);
            customLabel1.TabIndex = 7;
            customLabel1.Text = "W";
            // 
            // customLabel6
            // 
            customLabel6.BoderRadius = 3F;
            customLabel6.BorderColor = Color.White;
            customLabel6.EndColor = Color.Blue;
            customLabel6.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel6.ForeColor = Color.White;
            customLabel6.Location = new Point(229, 216);
            customLabel6.Margin = new Padding(3, 2, 3, 2);
            customLabel6.Name = "customLabel6";
            customLabel6.ShadowOffset = 5;
            customLabel6.Size = new Size(129, 85);
            customLabel6.StartColor = Color.MediumSlateBlue;
            customLabel6.TabIndex = 7;
            customLabel6.Text = "P";
            // 
            // customLabel8
            // 
            customLabel8.BoderRadius = 3F;
            customLabel8.BorderColor = Color.White;
            customLabel8.EndColor = Color.Blue;
            customLabel8.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel8.ForeColor = Color.White;
            customLabel8.Location = new Point(391, 216);
            customLabel8.Margin = new Padding(3, 2, 3, 2);
            customLabel8.Name = "customLabel8";
            customLabel8.ShadowOffset = 4;
            customLabel8.Size = new Size(129, 85);
            customLabel8.StartColor = Color.MediumSlateBlue;
            customLabel8.TabIndex = 7;
            customLabel8.Text = "L";
            // 
            // customLabel9
            // 
            customLabel9.BoderRadius = 3F;
            customLabel9.BorderColor = Color.White;
            customLabel9.EndColor = Color.Blue;
            customLabel9.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel9.ForeColor = Color.White;
            customLabel9.Location = new Point(553, 216);
            customLabel9.Margin = new Padding(3, 2, 3, 2);
            customLabel9.Name = "customLabel9";
            customLabel9.ShadowOffset = 4;
            customLabel9.Size = new Size(129, 85);
            customLabel9.StartColor = Color.MediumSlateBlue;
            customLabel9.TabIndex = 7;
            customLabel9.Text = "A";
            // 
            // customLabel7
            // 
            customLabel7.BoderRadius = 3F;
            customLabel7.BorderColor = Color.White;
            customLabel7.EndColor = Color.Blue;
            customLabel7.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel7.ForeColor = Color.White;
            customLabel7.Location = new Point(553, 122);
            customLabel7.Margin = new Padding(3, 2, 3, 2);
            customLabel7.Name = "customLabel7";
            customLabel7.ShadowOffset = 4;
            customLabel7.Size = new Size(105, 81);
            customLabel7.StartColor = Color.MediumSlateBlue;
            customLabel7.TabIndex = 7;
            customLabel7.Text = "D";
            // 
            // customLabel2
            // 
            customLabel2.BoderRadius = 3F;
            customLabel2.BorderColor = Color.White;
            customLabel2.EndColor = Color.Red;
            customLabel2.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel2.ForeColor = Color.White;
            customLabel2.Location = new Point(326, 125);
            customLabel2.Margin = new Padding(3, 2, 3, 2);
            customLabel2.Name = "customLabel2";
            customLabel2.ShadowOffset = 4;
            customLabel2.Size = new Size(104, 78);
            customLabel2.StartColor = Color.MediumSlateBlue;
            customLabel2.TabIndex = 7;
            customLabel2.Text = "O";
            // 
            // customLabel3
            // 
            customLabel3.BoderRadius = 3F;
            customLabel3.BorderColor = Color.White;
            customLabel3.EndColor = Color.Yellow;
            customLabel3.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel3.ForeColor = Color.White;
            customLabel3.Location = new Point(445, 89);
            customLabel3.Margin = new Padding(3, 2, 3, 2);
            customLabel3.Name = "customLabel3";
            customLabel3.ShadowOffset = 4;
            customLabel3.Size = new Size(102, 82);
            customLabel3.StartColor = Color.FromArgb(255, 128, 0);
            customLabel3.TabIndex = 7;
            customLabel3.Text = "R";
            // 
            // customLabel4
            // 
            customLabel4.BoderRadius = 3F;
            customLabel4.BorderColor = Color.White;
            customLabel4.EndColor = Color.Lime;
            customLabel4.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel4.ForeColor = Color.White;
            customLabel4.Location = new Point(663, 90);
            customLabel4.Margin = new Padding(3, 2, 3, 2);
            customLabel4.Name = "customLabel4";
            customLabel4.ShadowOffset = 4;
            customLabel4.Size = new Size(101, 81);
            customLabel4.StartColor = Color.White;
            customLabel4.TabIndex = 7;
            customLabel4.Text = "L";
            // 
            // customLabel5
            // 
            customLabel5.BoderRadius = 3F;
            customLabel5.BorderColor = Color.White;
            customLabel5.EndColor = Color.FromArgb(255, 128, 0);
            customLabel5.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel5.ForeColor = Color.White;
            customLabel5.Location = new Point(777, 122);
            customLabel5.Margin = new Padding(3, 2, 3, 2);
            customLabel5.Name = "customLabel5";
            customLabel5.ShadowOffset = 4;
            customLabel5.Size = new Size(98, 81);
            customLabel5.StartColor = Color.Red;
            customLabel5.TabIndex = 7;
            customLabel5.Text = "E";
            // 
            // customLabel10
            // 
            customLabel10.BoderRadius = 3F;
            customLabel10.BorderColor = Color.White;
            customLabel10.EndColor = Color.Blue;
            customLabel10.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel10.ForeColor = Color.White;
            customLabel10.Location = new Point(717, 216);
            customLabel10.Margin = new Padding(3, 2, 3, 2);
            customLabel10.Name = "customLabel10";
            customLabel10.ShadowOffset = 4;
            customLabel10.Size = new Size(129, 85);
            customLabel10.StartColor = Color.MediumSlateBlue;
            customLabel10.TabIndex = 7;
            customLabel10.Text = "Y";
            // 
            // btn_Sound
            // 
            btn_Sound.boderGradientBottom1 = Color.White;
            btn_Sound.boderGradientTop1 = Color.White;
            btn_Sound.boderRadius1 = 40;
            btn_Sound.boderSize1 = 2;
            btn_Sound.Cursor = Cursors.Hand;
            btn_Sound.gradientAngle1 = 90F;
            btn_Sound.Image = Properties.Resources.MusicOnLight;
            btn_Sound.Location = new Point(1045, 640);
            btn_Sound.Margin = new Padding(3, 2, 3, 2);
            btn_Sound.Name = "btn_Sound";
            btn_Sound.Size = new Size(60, 60);
            btn_Sound.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Sound.TabIndex = 10;
            btn_Sound.TabStop = false;
            btn_Sound.Click += btn_Sound_Click;
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderRadius = 30;
            customPanel1.Controls.Add(btn_SinglePlayer);
            customPanel1.Controls.Add(btn_MultiPlayer);
            customPanel1.Controls.Add(btn_SingleStats);
            customPanel1.Controls.Add(btn_MultiStats);
            customPanel1.Controls.Add(btn_Exit);
            customPanel1.ForeColor = Color.Black;
            customPanel1.GradientAngle = 90F;
            customPanel1.GradientBottomColor = Color.CadetBlue;
            customPanel1.GradientTopColor = Color.DodgerBlue;
            customPanel1.Location = new Point(200, 373);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(700, 300);
            customPanel1.TabIndex = 14;
            // 
            // btn_SinglePlayer
            // 
            btn_SinglePlayer.BackColor = Color.White;
            btn_SinglePlayer.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_SinglePlayer.BorderColor = Color.FromArgb(153, 214, 214);
            btn_SinglePlayer.BorderRadius = 20;
            btn_SinglePlayer.BorderSize = 2;
            btn_SinglePlayer.ButtonImage = null;
            btn_SinglePlayer.Cursor = Cursors.Hand;
            btn_SinglePlayer.EnableStripe = true;
            btn_SinglePlayer.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn_SinglePlayer.ImageSize = 24;
            btn_SinglePlayer.Location = new Point(80, 35);
            btn_SinglePlayer.Margin = new Padding(3, 2, 3, 2);
            btn_SinglePlayer.Name = "btn_SinglePlayer";
            btn_SinglePlayer.Size = new Size(250, 50);
            btn_SinglePlayer.StripeSpeed = 3;
            btn_SinglePlayer.TabIndex = 17;
            btn_SinglePlayer.Text = "Offline mode";
            btn_SinglePlayer.TextAlign = ContentAlignment.MiddleCenter;
            btn_SinglePlayer.TextColor = Color.Black;
            btn_SinglePlayer.Click += btn_SinglePlayer_Click;
            // 
            // btn_MultiPlayer
            // 
            btn_MultiPlayer.BackgroundColor = Color.FromArgb(224, 224, 224);
            btn_MultiPlayer.BorderColor = Color.SkyBlue;
            btn_MultiPlayer.BorderRadius = 20;
            btn_MultiPlayer.BorderSize = 2;
            btn_MultiPlayer.ButtonImage = null;
            btn_MultiPlayer.Cursor = Cursors.Hand;
            btn_MultiPlayer.EnableStripe = true;
            btn_MultiPlayer.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_MultiPlayer.ForeColor = Color.Yellow;
            btn_MultiPlayer.ImageSize = 24;
            btn_MultiPlayer.Location = new Point(370, 35);
            btn_MultiPlayer.Margin = new Padding(3, 2, 3, 2);
            btn_MultiPlayer.Name = "btn_MultiPlayer";
            btn_MultiPlayer.Size = new Size(250, 50);
            btn_MultiPlayer.StripeSpeed = 4;
            btn_MultiPlayer.TabIndex = 16;
            btn_MultiPlayer.Text = "Online mode";
            btn_MultiPlayer.TextAlign = ContentAlignment.MiddleCenter;
            btn_MultiPlayer.TextColor = Color.Black;
            btn_MultiPlayer.Click += btn_MultiPlayer_Click;
            // 
            // btn_SingleStats
            // 
            btn_SingleStats.BackColor = Color.White;
            btn_SingleStats.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_SingleStats.BorderColor = Color.FromArgb(153, 214, 214);
            btn_SingleStats.BorderRadius = 20;
            btn_SingleStats.BorderSize = 2;
            btn_SingleStats.ButtonImage = null;
            btn_SingleStats.Cursor = Cursors.Hand;
            btn_SingleStats.EnableStripe = true;
            btn_SingleStats.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn_SingleStats.ImageSize = 24;
            btn_SingleStats.Location = new Point(80, 105);
            btn_SingleStats.Margin = new Padding(3, 2, 3, 2);
            btn_SingleStats.Name = "btn_SingleStats";
            btn_SingleStats.Size = new Size(250, 50);
            btn_SingleStats.StripeSpeed = 3;
            btn_SingleStats.TabIndex = 19;
            btn_SingleStats.Text = "Offline Statistics";
            btn_SingleStats.TextAlign = ContentAlignment.MiddleCenter;
            btn_SingleStats.TextColor = Color.Black;
            btn_SingleStats.Click += btn_SingleStats_Click;
            // 
            // btn_MultiStats
            // 
            btn_MultiStats.BackgroundColor = Color.FromArgb(224, 224, 224);
            btn_MultiStats.BorderColor = Color.SkyBlue;
            btn_MultiStats.BorderRadius = 20;
            btn_MultiStats.BorderSize = 2;
            btn_MultiStats.ButtonImage = null;
            btn_MultiStats.Cursor = Cursors.Hand;
            btn_MultiStats.EnableStripe = true;
            btn_MultiStats.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_MultiStats.ForeColor = Color.Yellow;
            btn_MultiStats.ImageSize = 24;
            btn_MultiStats.Location = new Point(370, 105);
            btn_MultiStats.Margin = new Padding(3, 2, 3, 2);
            btn_MultiStats.Name = "btn_MultiStats";
            btn_MultiStats.Size = new Size(250, 50);
            btn_MultiStats.StripeSpeed = 4;
            btn_MultiStats.TabIndex = 18;
            btn_MultiStats.Text = "Online Statistics";
            btn_MultiStats.TextAlign = ContentAlignment.MiddleCenter;
            btn_MultiStats.TextColor = Color.Black;
            btn_MultiStats.Click += btn_MultiStats_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.BackgroundColor = Color.FromArgb(255, 116, 108);
            btn_Exit.BorderColor = Color.FromArgb(255, 116, 108);
            btn_Exit.BorderRadius = 20;
            btn_Exit.BorderSize = 2;
            btn_Exit.ButtonImage = null;
            btn_Exit.Cursor = Cursors.Hand;
            btn_Exit.EnableStripe = true;
            btn_Exit.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn_Exit.ImageSize = 24;
            btn_Exit.Location = new Point(75, 190);
            btn_Exit.Margin = new Padding(3, 2, 3, 2);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(549, 50);
            btn_Exit.StripeSpeed = 4;
            btn_Exit.TabIndex = 15;
            btn_Exit.Text = "Exit";
            btn_Exit.TextAlign = ContentAlignment.MiddleCenter;
            btn_Exit.TextColor = Color.Black;
            btn_Exit.Click += Exit_Click;
            // 
            // exit
            // 
            exit.boderGradientBottom1 = Color.White;
            exit.boderGradientTop1 = Color.White;
            exit.boderRadius1 = 40;
            exit.boderSize1 = 0;
            exit.gradientAngle1 = 90F;
            exit.Image = Properties.Resources.Exit;
            exit.Location = new Point(1071, 11);
            exit.Margin = new Padding(3, 2, 3, 2);
            exit.Name = "exit";
            exit.Size = new Size(27, 26);
            exit.SizeMode = PictureBoxSizeMode.StretchImage;
            exit.TabIndex = 15;
            exit.TabStop = false;
            exit.Click += Exit_Click;
            // 
            // customPictureBox1
            // 
            customPictureBox1.boderGradientBottom1 = Color.SlateBlue;
            customPictureBox1.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox1.boderRadius1 = 40;
            customPictureBox1.boderSize1 = 2;
            customPictureBox1.gradientAngle1 = 90F;
            customPictureBox1.Location = new Point(499, 317);
            customPictureBox1.Name = "customPictureBox1";
            customPictureBox1.Size = new Size(96, 86);
            customPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox1.TabIndex = 16;
            customPictureBox1.TabStop = false;
            customPictureBox1.Click += customPictureBox1_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1110, 709);
            Controls.Add(customPictureBox1);
            Controls.Add(exit);
            Controls.Add(customPanel1);
            Controls.Add(btn_DarkLight);
            Controls.Add(btn_Sound);
            Controls.Add(customLabel7);
            Controls.Add(customLabel5);
            Controls.Add(customLabel4);
            Controls.Add(customLabel3);
            Controls.Add(customLabel2);
            Controls.Add(customLabel10);
            Controls.Add(customLabel9);
            Controls.Add(customLabel8);
            Controls.Add(customLabel6);
            Controls.Add(customLabel1);
            Controls.Add(minimunsize);
            Cursor = Cursors.Hand;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainMenu";
            Load += MainMenu_Load;
            ((System.ComponentModel.ISupportInitialize)minimunsize).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_DarkLight).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Sound).EndInit();
            customPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private CustomPictureBox minimunsize;
        private CustomPictureBox btn_DarkLight;
        private CustomLabel customLabel1;
        private CustomLabel customLabel6;
        private CustomLabel customLabel8;
        private CustomLabel customLabel9;
        private CustomLabel customLabel7;
        private CustomLabel customLabel2;
        private CustomLabel customLabel3;
        private CustomLabel customLabel4;
        private CustomLabel customLabel5;
        private CustomLabel customLabel10;
        private CustomPictureBox btn_Sound;
        private CustomPanel customPanel1;
        private CustomButtonAnimation btn_MultiStats;
        private CustomButtonAnimation btn_SingleStats;
        private CustomButtonAnimation btn_Exit;
        private CustomButtonAnimation btn_MultiPlayer;
        private CustomButtonAnimation btn_SinglePlayer;
        private CustomPictureBox exit;
        private CustomPictureBox customPictureBox1;
    }
}