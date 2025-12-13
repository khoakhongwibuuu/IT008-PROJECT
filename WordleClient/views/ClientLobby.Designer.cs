using WordleClient.libraries.CustomControls;

namespace WordleClient.views
{
    partial class ClientLobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientLobby));
            customPanel1 = new CustomPanel();
            customGroupBox1 = new CustomGroupBox();
            customGroupBox2 = new CustomGroupBox();
            btn_Exit = new CustomPictureBox();
            btn_StartGame = new CustomButton();
            btn_CloseServer = new CustomButton();
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
            // customGroupBox1
            // 
            customGroupBox1.BackColor = Color.Transparent;
            customGroupBox1.BackgroundColor = Color.White;
            customGroupBox1.BorderColor = Color.Teal;
            customGroupBox1.BorderRadius = 15;
            customGroupBox1.BorderSize = 2;
            customGroupBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            customGroupBox1.ForeColor = Color.White;
            customGroupBox1.Location = new Point(98, 25);
            customGroupBox1.Margin = new Padding(3, 2, 3, 2);
            customGroupBox1.Name = "customGroupBox1";
            customGroupBox1.Padding = new Padding(3, 2, 3, 2);
            customGroupBox1.Size = new Size(469, 329);
            customGroupBox1.TabIndex = 1;
            customGroupBox1.TabStop = false;
            customGroupBox1.Text = "Panel A";
            customGroupBox1.TextColor = Color.Black;
            customGroupBox1.TitleAlign = ContentAlignment.TopLeft;
            customGroupBox1.TitlePadding = 10;
            // 
            // customGroupBox2
            // 
            customGroupBox2.BackColor = Color.Transparent;
            customGroupBox2.BackgroundColor = Color.White;
            customGroupBox2.BorderColor = Color.Teal;
            customGroupBox2.BorderRadius = 15;
            customGroupBox2.BorderSize = 2;
            customGroupBox2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            customGroupBox2.ForeColor = Color.White;
            customGroupBox2.Location = new Point(100, 358);
            customGroupBox2.Margin = new Padding(3, 2, 3, 2);
            customGroupBox2.Name = "customGroupBox2";
            customGroupBox2.Padding = new Padding(3, 2, 3, 2);
            customGroupBox2.Size = new Size(467, 118);
            customGroupBox2.TabIndex = 3;
            customGroupBox2.TabStop = false;
            customGroupBox2.Text = "Panel B";
            customGroupBox2.TextColor = Color.Black;
            customGroupBox2.TitleAlign = ContentAlignment.TopLeft;
            customGroupBox2.TitlePadding = 10;
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
            btn_StartGame.Location = new Point(363, 496);
            btn_StartGame.Name = "btn_StartGame";
            btn_StartGame.Size = new Size(204, 65);
            btn_StartGame.TabIndex = 8;
            btn_StartGame.Text = "Request to join";
            btn_StartGame.TextAlign = ContentAlignment.MiddleCenter;
            btn_StartGame.TextColor = Color.White;
            btn_StartGame.Click += btn_StartGame_Click;
            // 
            // btn_CloseServer
            // 
            btn_CloseServer.BackgroundColor = Color.FromArgb(255, 116, 108);
            btn_CloseServer.BorderColor = Color.FromArgb(255, 116, 108);
            btn_CloseServer.BorderRadius = 20;
            btn_CloseServer.BorderSize = 2;
            btn_CloseServer.ButtonImage = null;
            btn_CloseServer.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btn_CloseServer.ImageSize = 24;
            btn_CloseServer.Location = new Point(100, 496);
            btn_CloseServer.Name = "btn_CloseServer";
            btn_CloseServer.Size = new Size(204, 65);
            btn_CloseServer.TabIndex = 9;
            btn_CloseServer.Text = "Exit";
            btn_CloseServer.TextAlign = ContentAlignment.MiddleCenter;
            btn_CloseServer.TextColor = Color.White;
            btn_CloseServer.Click += btn_CloseServer_Click;
            // 
            // ClientLobby
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 588);
            Controls.Add(btn_CloseServer);
            Controls.Add(btn_StartGame);
            Controls.Add(btn_Exit);
            Controls.Add(customGroupBox2);
            Controls.Add(customGroupBox1);
            Controls.Add(customPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ClientLobby";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ServerLobby";
            ((System.ComponentModel.ISupportInitialize)btn_Exit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CustomPanel customPanel1;
        private CustomGroupBox customGroupBox1;
        private CustomGroupBox customGroupBox2;
        private CustomPictureBox btn_Exit;
        private CustomButton btn_StartGame;
        private CustomButton btn_CloseServer;
    }
}