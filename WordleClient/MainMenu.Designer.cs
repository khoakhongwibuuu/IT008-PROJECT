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
            btn_SinglePlayer = new CustomButtonAnimation();
            btn_MultiPlayer = new CustomButtonAnimation();
            btn_Exit = new CustomButtonAnimation();
            cuttomPanel1 = new CustomPanel();
            btn_Setting = new CustomPictureBox();
            maximumsize = new CustomPictureBox();
            minimunsize = new CustomPictureBox();
            Exit = new CustomPictureBox();
            customLabel1 = new CustomLabel();
            customLabel2 = new CustomLabel();
            customLabel3 = new CustomLabel();
            customLabel4 = new CustomLabel();
            customLabel5 = new CustomLabel();
            customLabel7 = new CustomLabel();
            customLabel6 = new CustomLabel();
            customLabel8 = new CustomLabel();
            customLabel9 = new CustomLabel();
            customLabel10 = new CustomLabel();
            ((System.ComponentModel.ISupportInitialize)btn_Setting).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maximumsize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimunsize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Exit).BeginInit();
            SuspendLayout();
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
            btn_SinglePlayer.Location = new Point(483, 525);
            btn_SinglePlayer.Name = "btn_SinglePlayer";
            btn_SinglePlayer.Size = new Size(317, 69);
            btn_SinglePlayer.StripeSpeed = 3;
            btn_SinglePlayer.TabIndex = 2;
            btn_SinglePlayer.Text = "SinglePlayer";
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
            btn_MultiPlayer.Location = new Point(483, 620);
            btn_MultiPlayer.Name = "btn_MultiPlayer";
            btn_MultiPlayer.Size = new Size(317, 69);
            btn_MultiPlayer.StripeSpeed = 4;
            btn_MultiPlayer.TabIndex = 2;
            btn_MultiPlayer.Text = "MultiPlayer";
            btn_MultiPlayer.TextAlign = ContentAlignment.MiddleCenter;
            btn_MultiPlayer.TextColor = Color.Black;
            btn_MultiPlayer.Click += btn_MultiPlayer_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_Exit.BorderColor = Color.FromArgb(153, 214, 214);
            btn_Exit.BorderRadius = 20;
            btn_Exit.BorderSize = 2;
            btn_Exit.ButtonImage = null;
            btn_Exit.Cursor = Cursors.Hand;
            btn_Exit.EnableStripe = true;
            btn_Exit.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn_Exit.ImageSize = 24;
            btn_Exit.Location = new Point(483, 714);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(317, 69);
            btn_Exit.StripeSpeed = 4;
            btn_Exit.TabIndex = 2;
            btn_Exit.Text = "Exit";
            btn_Exit.TextAlign = ContentAlignment.MiddleCenter;
            btn_Exit.TextColor = Color.Black;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // cuttomPanel1
            // 
            cuttomPanel1.BackColor = Color.White;
            cuttomPanel1.BackgroundImage = (Image)resources.GetObject("cuttomPanel1.BackgroundImage");
            cuttomPanel1.BackgroundImageLayout = ImageLayout.Stretch;
            cuttomPanel1.BorderRadius = 35;
            cuttomPanel1.ForeColor = Color.Black;
            cuttomPanel1.GradientAngle = 90F;
            cuttomPanel1.GradientBottomColor = Color.Cyan;
            cuttomPanel1.GradientTopColor = Color.MediumBlue;
            cuttomPanel1.Location = new Point(274, 498);
            cuttomPanel1.Name = "cuttomPanel1";
            cuttomPanel1.Size = new Size(726, 308);
            cuttomPanel1.TabIndex = 3;
            // 
            // btn_Setting
            // 
            btn_Setting.boderGradientBottom1 = Color.White;
            btn_Setting.boderGradientTop1 = Color.White;
            btn_Setting.boderRadius1 = 40;
            btn_Setting.boderSize1 = 0;
            btn_Setting.gradientAngle1 = 90F;
            btn_Setting.Image = Properties.Resources.iconSetting;
            btn_Setting.Location = new Point(12, 0);
            btn_Setting.Name = "btn_Setting";
            btn_Setting.Size = new Size(57, 52);
            btn_Setting.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Setting.TabIndex = 4;
            btn_Setting.TabStop = false;
            btn_Setting.Click += btn_Setting_Click_1;
            // 
            // maximumsize
            // 
            maximumsize.boderGradientBottom1 = Color.White;
            maximumsize.boderGradientTop1 = Color.White;
            maximumsize.boderRadius1 = 40;
            maximumsize.boderSize1 = 0;
            maximumsize.gradientAngle1 = 90F;
            maximumsize.Image = (Image)resources.GetObject("maximumsize.Image");
            maximumsize.Location = new Point(1194, 0);
            maximumsize.Name = "maximumsize";
            maximumsize.Size = new Size(34, 35);
            maximumsize.SizeMode = PictureBoxSizeMode.StretchImage;
            maximumsize.TabIndex = 5;
            maximumsize.TabStop = false;
            // 
            // minimunsize
            // 
            minimunsize.boderGradientBottom1 = Color.White;
            minimunsize.boderGradientTop1 = Color.White;
            minimunsize.boderRadius1 = 40;
            minimunsize.boderSize1 = 0;
            minimunsize.gradientAngle1 = 90F;
            minimunsize.Image = (Image)resources.GetObject("minimunsize.Image");
            minimunsize.Location = new Point(1154, 0);
            minimunsize.Name = "minimunsize";
            minimunsize.Size = new Size(31, 35);
            minimunsize.SizeMode = PictureBoxSizeMode.StretchImage;
            minimunsize.TabIndex = 5;
            minimunsize.TabStop = false;
            minimunsize.Click += minimunsize_Click;
            // 
            // Exit
            // 
            Exit.boderGradientBottom1 = Color.White;
            Exit.boderGradientTop1 = Color.White;
            Exit.boderRadius1 = 40;
            Exit.boderSize1 = 0;
            Exit.Cursor = Cursors.Hand;
            Exit.gradientAngle1 = 90F;
            Exit.Image = (Image)resources.GetObject("Exit.Image");
            Exit.Location = new Point(1234, 0);
            Exit.Name = "Exit";
            Exit.Size = new Size(34, 35);
            Exit.SizeMode = PictureBoxSizeMode.StretchImage;
            Exit.TabIndex = 6;
            Exit.TabStop = false;
            Exit.Click += Exit_Click;
            // 
            // customLabel1
            // 
            customLabel1.BoderRadius = 3F;
            customLabel1.BorderColor = Color.White;
            customLabel1.EndColor = Color.Blue;
            customLabel1.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel1.ForeColor = Color.White;
            customLabel1.Location = new Point(231, 115);
            customLabel1.Name = "customLabel1";
            customLabel1.ShadowOffset = 4;
            customLabel1.Size = new Size(147, 113);
            customLabel1.StartColor = Color.FromArgb(128, 255, 255);
            customLabel1.TabIndex = 7;
            customLabel1.Text = "W";
            // 
            // customLabel2
            // 
            customLabel2.BoderRadius = 3F;
            customLabel2.BorderColor = Color.White;
            customLabel2.EndColor = Color.Red;
            customLabel2.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel2.ForeColor = Color.White;
            customLabel2.Location = new Point(372, 167);
            customLabel2.Name = "customLabel2";
            customLabel2.ShadowOffset = 4;
            customLabel2.Size = new Size(119, 104);
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
            customLabel3.Location = new Point(509, 119);
            customLabel3.Name = "customLabel3";
            customLabel3.ShadowOffset = 4;
            customLabel3.Size = new Size(117, 109);
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
            customLabel4.Location = new Point(758, 120);
            customLabel4.Name = "customLabel4";
            customLabel4.ShadowOffset = 4;
            customLabel4.Size = new Size(115, 108);
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
            customLabel5.Location = new Point(888, 163);
            customLabel5.Name = "customLabel5";
            customLabel5.ShadowOffset = 4;
            customLabel5.Size = new Size(112, 108);
            customLabel5.StartColor = Color.Red;
            customLabel5.TabIndex = 7;
            customLabel5.Text = "E";
            // 
            // customLabel7
            // 
            customLabel7.BoderRadius = 3F;
            customLabel7.BorderColor = Color.White;
            customLabel7.EndColor = Color.Blue;
            customLabel7.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel7.ForeColor = Color.White;
            customLabel7.Location = new Point(632, 163);
            customLabel7.Name = "customLabel7";
            customLabel7.ShadowOffset = 4;
            customLabel7.Size = new Size(120, 108);
            customLabel7.StartColor = Color.MediumSlateBlue;
            customLabel7.TabIndex = 7;
            customLabel7.Text = "D";
            // 
            // customLabel6
            // 
            customLabel6.BoderRadius = 3F;
            customLabel6.BorderColor = Color.White;
            customLabel6.EndColor = Color.Blue;
            customLabel6.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel6.ForeColor = Color.White;
            customLabel6.Location = new Point(262, 288);
            customLabel6.Name = "customLabel6";
            customLabel6.ShadowOffset = 5;
            customLabel6.Size = new Size(147, 113);
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
            customLabel8.Location = new Point(447, 288);
            customLabel8.Name = "customLabel8";
            customLabel8.ShadowOffset = 4;
            customLabel8.Size = new Size(147, 113);
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
            customLabel9.Location = new Point(632, 288);
            customLabel9.Name = "customLabel9";
            customLabel9.ShadowOffset = 4;
            customLabel9.Size = new Size(147, 113);
            customLabel9.StartColor = Color.MediumSlateBlue;
            customLabel9.TabIndex = 7;
            customLabel9.Text = "A";
            // 
            // customLabel10
            // 
            customLabel10.BoderRadius = 3F;
            customLabel10.BorderColor = Color.White;
            customLabel10.EndColor = Color.Blue;
            customLabel10.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic);
            customLabel10.ForeColor = Color.White;
            customLabel10.Location = new Point(819, 288);
            customLabel10.Name = "customLabel10";
            customLabel10.ShadowOffset = 4;
            customLabel10.Size = new Size(147, 113);
            customLabel10.StartColor = Color.MediumSlateBlue;
            customLabel10.TabIndex = 7;
            customLabel10.Text = "Y";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1260, 945);
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
            Controls.Add(Exit);
            Controls.Add(minimunsize);
            Controls.Add(maximumsize);
            Controls.Add(btn_Setting);
            Controls.Add(btn_Exit);
            Controls.Add(btn_MultiPlayer);
            Controls.Add(btn_SinglePlayer);
            Controls.Add(cuttomPanel1);
            Cursor = Cursors.Hand;
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainMenu";
            Load += MainMenu_Load;
            ((System.ComponentModel.ISupportInitialize)btn_Setting).EndInit();
            ((System.ComponentModel.ISupportInitialize)maximumsize).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimunsize).EndInit();
            ((System.ComponentModel.ISupportInitialize)Exit).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private CustomButtonAnimation btn_SinglePlayer;
        private CustomButtonAnimation btn_MultiPlayer;
        private CustomButtonAnimation btn_Exit;
        private CustomPanel cuttomPanel1;
        private CustomPictureBox btn_Setting;
        private CustomPictureBox maximumsize;
        private CustomPictureBox minimunsize;
        private CustomPictureBox Exit;
        private CustomLabel customLabel1;
        private CustomLabel customLabel2;
        private CustomLabel customLabel3;
        private CustomLabel customLabel4;
        private CustomLabel customLabel5;
        private CustomLabel customLabel7;
        private CustomLabel customLabel6;
        private CustomLabel customLabel8;
        private CustomLabel customLabel9;
        private CustomLabel customLabel10;
    }
}