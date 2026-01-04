using WordleClient.libraries.CustomControls;

namespace WordleClient.views
{
    partial class ServerLobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerLobby));
            customPanel1 = new CustomPanel();
            GB_PlayerWaitForApproval = new CustomGroupBox();
            GB_Settings = new CustomGroupBox();
            customLabel4 = new CustomLabel();
            customLabel3 = new CustomLabel();
            customLabel2 = new CustomLabel();
            customLabel1 = new CustomLabel();
            trackBarGuess = new TrackBar();
            btn_Exit = new CustomPictureBox();
            btn_StartGame = new CustomButton();
            GB_PlayerApproved = new CustomGroupBox();
            GB_Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarGuess).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Exit).BeginInit();
            SuspendLayout();
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderRadius = 30;
            customPanel1.Dock = DockStyle.Fill;
            customPanel1.ForeColor = Color.Black;
            customPanel1.GradientAngle = 90F;
            customPanel1.GradientBottomColor = Color.FromArgb(253, 205, 159);
            customPanel1.GradientTopColor = Color.FromArgb(248, 232, 212);
            customPanel1.Location = new Point(0, 0);
            customPanel1.Margin = new Padding(3, 2, 3, 2);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(665, 588);
            customPanel1.TabIndex = 0;
            // 
            // GB_PlayerWaitForApproval
            // 
            GB_PlayerWaitForApproval.BackColor = Color.Transparent;
            GB_PlayerWaitForApproval.BackgroundColor = Color.White;
            GB_PlayerWaitForApproval.BorderColor = Color.Teal;
            GB_PlayerWaitForApproval.BorderRadius = 15;
            GB_PlayerWaitForApproval.BorderSize = 2;
            GB_PlayerWaitForApproval.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            GB_PlayerWaitForApproval.ForeColor = Color.White;
            GB_PlayerWaitForApproval.Location = new Point(98, 25);
            GB_PlayerWaitForApproval.Margin = new Padding(3, 2, 3, 2);
            GB_PlayerWaitForApproval.Name = "GB_PlayerWaitForApproval";
            GB_PlayerWaitForApproval.Padding = new Padding(3, 2, 3, 2);
            GB_PlayerWaitForApproval.Size = new Size(469, 163);
            GB_PlayerWaitForApproval.TabIndex = 1;
            GB_PlayerWaitForApproval.TabStop = false;
            GB_PlayerWaitForApproval.Text = "Manage pending requests";
            GB_PlayerWaitForApproval.TextColor = Color.Black;
            GB_PlayerWaitForApproval.TitleAlign = ContentAlignment.TopLeft;
            GB_PlayerWaitForApproval.TitlePadding = 10;
            // 
            // GB_Settings
            // 
            GB_Settings.BackColor = Color.Transparent;
            GB_Settings.BackgroundColor = Color.White;
            GB_Settings.BorderColor = Color.Teal;
            GB_Settings.BorderRadius = 15;
            GB_Settings.BorderSize = 2;
            GB_Settings.Controls.Add(customLabel4);
            GB_Settings.Controls.Add(customLabel3);
            GB_Settings.Controls.Add(customLabel2);
            GB_Settings.Controls.Add(customLabel1);
            GB_Settings.Controls.Add(trackBarGuess);
            GB_Settings.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            GB_Settings.ForeColor = Color.White;
            GB_Settings.Location = new Point(98, 359);
            GB_Settings.Margin = new Padding(3, 2, 3, 2);
            GB_Settings.Name = "GB_Settings";
            GB_Settings.Padding = new Padding(3, 2, 3, 2);
            GB_Settings.Size = new Size(469, 118);
            GB_Settings.TabIndex = 3;
            GB_Settings.TabStop = false;
            GB_Settings.Text = "Select maximum attempts for all players";
            GB_Settings.TextColor = Color.Black;
            GB_Settings.TitleAlign = ContentAlignment.TopLeft;
            GB_Settings.TitlePadding = 10;
            // 
            // customLabel4
            // 
            customLabel4.BoderRadius = 3F;
            customLabel4.BorderColor = Color.White;
            customLabel4.Cursor = Cursors.Hand;
            customLabel4.EndColor = Color.MediumPurple;
            customLabel4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            customLabel4.ForeColor = Color.White;
            customLabel4.Location = new Point(352, 75);
            customLabel4.Margin = new Padding(3, 2, 3, 2);
            customLabel4.Name = "customLabel4";
            customLabel4.ShadowOffset = 4;
            customLabel4.Size = new Size(30, 39);
            customLabel4.StartColor = Color.MediumSlateBlue;
            customLabel4.TabIndex = 7;
            customLabel4.Text = "9";
            // 
            // customLabel3
            // 
            customLabel3.BoderRadius = 3F;
            customLabel3.BorderColor = Color.White;
            customLabel3.Cursor = Cursors.Hand;
            customLabel3.EndColor = Color.MediumPurple;
            customLabel3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            customLabel3.ForeColor = Color.White;
            customLabel3.Location = new Point(174, 75);
            customLabel3.Margin = new Padding(3, 2, 3, 2);
            customLabel3.Name = "customLabel3";
            customLabel3.ShadowOffset = 4;
            customLabel3.Size = new Size(30, 39);
            customLabel3.StartColor = Color.MediumSlateBlue;
            customLabel3.TabIndex = 4;
            customLabel3.Text = "7";
            // 
            // customLabel2
            // 
            customLabel2.BoderRadius = 3F;
            customLabel2.BorderColor = Color.White;
            customLabel2.Cursor = Cursors.Hand;
            customLabel2.EndColor = Color.MediumPurple;
            customLabel2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            customLabel2.ForeColor = Color.White;
            customLabel2.Location = new Point(263, 75);
            customLabel2.Margin = new Padding(3, 2, 3, 2);
            customLabel2.Name = "customLabel2";
            customLabel2.ShadowOffset = 4;
            customLabel2.Size = new Size(30, 39);
            customLabel2.StartColor = Color.MediumSlateBlue;
            customLabel2.TabIndex = 5;
            customLabel2.Text = "8";
            // 
            // customLabel1
            // 
            customLabel1.BoderRadius = 3F;
            customLabel1.BorderColor = Color.White;
            customLabel1.Cursor = Cursors.Hand;
            customLabel1.EndColor = Color.MediumPurple;
            customLabel1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            customLabel1.ForeColor = Color.White;
            customLabel1.Location = new Point(85, 75);
            customLabel1.Margin = new Padding(3, 2, 3, 2);
            customLabel1.Name = "customLabel1";
            customLabel1.ShadowOffset = 4;
            customLabel1.Size = new Size(30, 39);
            customLabel1.StartColor = Color.MediumSlateBlue;
            customLabel1.TabIndex = 6;
            customLabel1.Text = "6";
            // 
            // trackBarGuess
            // 
            trackBarGuess.Location = new Point(86, 40);
            trackBarGuess.Margin = new Padding(3, 2, 3, 2);
            trackBarGuess.Maximum = 9;
            trackBarGuess.Minimum = 6;
            trackBarGuess.Name = "trackBarGuess";
            trackBarGuess.Size = new Size(296, 45);
            trackBarGuess.TabIndex = 1;
            trackBarGuess.Value = 6;
            // 
            // btn_Exit
            // 
            btn_Exit.boderGradientBottom1 = Color.White;
            btn_Exit.boderGradientTop1 = Color.White;
            btn_Exit.boderRadius1 = 40;
            btn_Exit.boderSize1 = 0;
            btn_Exit.Cursor = Cursors.Hand;
            btn_Exit.gradientAngle1 = 90F;
            btn_Exit.Image = (Image)resources.GetObject("btn_Exit.Image");
            btn_Exit.Location = new Point(623, 11);
            btn_Exit.Margin = new Padding(3, 2, 3, 2);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(30, 30);
            btn_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Exit.TabIndex = 7;
            btn_Exit.TabStop = false;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // btn_StartGame
            // 
            btn_StartGame.BackgroundColor = Color.FromArgb(87, 162, 62);
            btn_StartGame.BorderColor = Color.FromArgb(87, 162, 62);
            btn_StartGame.BorderRadius = 20;
            btn_StartGame.BorderSize = 2;
            btn_StartGame.ButtonImage = null;
            btn_StartGame.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btn_StartGame.ImageSize = 24;
            btn_StartGame.Location = new Point(98, 496);
            btn_StartGame.Name = "btn_StartGame";
            btn_StartGame.Size = new Size(469, 65);
            btn_StartGame.TabIndex = 8;
            btn_StartGame.TextAlign = ContentAlignment.MiddleCenter;
            btn_StartGame.TextColor = Color.White;
            btn_StartGame.Click += btn_StartGame_Click;
            // 
            // GB_PlayerApproved
            // 
            GB_PlayerApproved.BackColor = Color.Transparent;
            GB_PlayerApproved.BackgroundColor = Color.White;
            GB_PlayerApproved.BorderColor = Color.Teal;
            GB_PlayerApproved.BorderRadius = 15;
            GB_PlayerApproved.BorderSize = 2;
            GB_PlayerApproved.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            GB_PlayerApproved.ForeColor = Color.White;
            GB_PlayerApproved.Location = new Point(98, 192);
            GB_PlayerApproved.Margin = new Padding(3, 2, 3, 2);
            GB_PlayerApproved.Name = "GB_PlayerApproved";
            GB_PlayerApproved.Padding = new Padding(3, 2, 3, 2);
            GB_PlayerApproved.Size = new Size(469, 163);
            GB_PlayerApproved.TabIndex = 2;
            GB_PlayerApproved.TabStop = false;
            GB_PlayerApproved.Text = "Manage in room players";
            GB_PlayerApproved.TextColor = Color.Black;
            GB_PlayerApproved.TitleAlign = ContentAlignment.TopLeft;
            GB_PlayerApproved.TitlePadding = 10;
            // 
            // ServerLobby
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 588);
            Controls.Add(GB_PlayerApproved);
            Controls.Add(btn_StartGame);
            Controls.Add(btn_Exit);
            Controls.Add(GB_Settings);
            Controls.Add(GB_PlayerWaitForApproval);
            Controls.Add(customPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ServerLobby";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server Lobby";
            Load += ServerLobby_Load;
            GB_Settings.ResumeLayout(false);
            GB_Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarGuess).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Exit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CustomPanel customPanel1;
        private CustomGroupBox GB_PlayerWaitForApproval;
        private CustomGroupBox GB_Settings;
        private TrackBar trackBarGuess;
        private CustomPictureBox btn_Exit;
        private CustomButton btn_StartGame;
        private CustomLabel customLabel4;
        private CustomLabel customLabel3;
        private CustomLabel customLabel2;
        private CustomLabel customLabel1;
        private CustomGroupBox GB_PlayerApproved;
    }
}