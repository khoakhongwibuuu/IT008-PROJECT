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
            btn_Client = new CustomButtonAnimation();
            btn_Server = new CustomButtonAnimation();
            btn_Stats = new CustomButtonAnimation();
            btn_Exit = new CustomButtonAnimation();
            exit = new CustomPictureBox();
            customPictureBox1 = new CustomPictureBox();
            btn_Guide = new CustomPictureBox();
            ((System.ComponentModel.ISupportInitialize)minimunsize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Sound).BeginInit();
            customPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Guide).BeginInit();
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
            customPanel1.Controls.Add(btn_Client);
            customPanel1.Controls.Add(btn_Server);
            customPanel1.Controls.Add(btn_Stats);
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
            // btn_Client
            // 
            btn_Client.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_Client.BorderColor = Color.FromArgb(153, 214, 214);
            btn_Client.BorderRadius = 20;
            btn_Client.BorderSize = 2;
            btn_Client.ButtonImage = null;
            btn_Client.Cursor = Cursors.Hand;
            btn_Client.EnableStripe = true;
            btn_Client.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Client.ForeColor = Color.Yellow;
            btn_Client.ImageSize = 24;
            btn_Client.Location = new Point(370, 35);
            btn_Client.Margin = new Padding(3, 2, 3, 2);
            btn_Client.Name = "btn_Client";
            btn_Client.Size = new Size(250, 50);
            btn_Client.StripeSpeed = 4;
            btn_Client.TabIndex = 16;
            btn_Client.Text = "Join other's server";
            btn_Client.TextAlign = ContentAlignment.MiddleCenter;
            btn_Client.TextColor = Color.Black;
            btn_Client.Click += btn_Client_Click;
            // 
            // btn_Server
            // 
            btn_Server.BackColor = Color.White;
            btn_Server.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_Server.BorderColor = Color.FromArgb(153, 214, 214);
            btn_Server.BorderRadius = 20;
            btn_Server.BorderSize = 2;
            btn_Server.ButtonImage = null;
            btn_Server.Cursor = Cursors.Hand;
            btn_Server.EnableStripe = true;
            btn_Server.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btn_Server.ImageSize = 24;
            btn_Server.Location = new Point(80, 105);
            btn_Server.Margin = new Padding(3, 2, 3, 2);
            btn_Server.Name = "btn_Server";
            btn_Server.Size = new Size(250, 50);
            btn_Server.StripeSpeed = 3;
            btn_Server.TabIndex = 19;
            btn_Server.Text = "Host my own server";
            btn_Server.TextAlign = ContentAlignment.MiddleCenter;
            btn_Server.TextColor = Color.Black;
            btn_Server.Click += btn_Server_Click;
            // 
            // btn_Stats
            // 
            btn_Stats.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_Stats.BorderColor = Color.FromArgb(153, 214, 214);
            btn_Stats.BorderRadius = 20;
            btn_Stats.BorderSize = 2;
            btn_Stats.ButtonImage = null;
            btn_Stats.Cursor = Cursors.Hand;
            btn_Stats.EnableStripe = true;
            btn_Stats.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Stats.ForeColor = Color.Yellow;
            btn_Stats.ImageSize = 24;
            btn_Stats.Location = new Point(370, 105);
            btn_Stats.Margin = new Padding(3, 2, 3, 2);
            btn_Stats.Name = "btn_Stats";
            btn_Stats.Size = new Size(250, 50);
            btn_Stats.StripeSpeed = 4;
            btn_Stats.TabIndex = 18;
            btn_Stats.Text = "Game stats";
            btn_Stats.TextAlign = ContentAlignment.MiddleCenter;
            btn_Stats.TextColor = Color.Black;
            btn_Stats.Click += btn_Stats_Click;
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
            // btn_Guide
            // 
            btn_Guide.boderGradientBottom1 = Color.White;
            btn_Guide.boderGradientTop1 = Color.White;
            btn_Guide.boderRadius1 = 40;
            btn_Guide.boderSize1 = 2;
            btn_Guide.Cursor = Cursors.Hand;
            btn_Guide.gradientAngle1 = 90F;
            btn_Guide.Image = Properties.Resources.question;
            btn_Guide.Location = new Point(1045, 576);
            btn_Guide.Margin = new Padding(3, 2, 3, 2);
            btn_Guide.Name = "btn_Guide";
            btn_Guide.Size = new Size(60, 60);
            btn_Guide.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Guide.TabIndex = 17;
            btn_Guide.TabStop = false;
            btn_Guide.Click += btn_Guide_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1110, 709);
            Controls.Add(btn_Guide);
            Controls.Add(customPictureBox1);
            Controls.Add(exit);
            Controls.Add(customPanel1);
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
            ((System.ComponentModel.ISupportInitialize)btn_Sound).EndInit();
            customPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Guide).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private CustomPictureBox minimunsize;
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
        private CustomButtonAnimation btn_Stats;
        private CustomButtonAnimation btn_Server;
        private CustomButtonAnimation btn_Exit;
        private CustomButtonAnimation btn_Client;
        private CustomButtonAnimation btn_SinglePlayer;
        private CustomPictureBox exit;
        private CustomPictureBox customPictureBox1;
        private CustomPictureBox btn_Guide;
    }
}