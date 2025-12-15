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
            lblStatus = new Label();
            btn_search = new Button();
            textBox1 = new TextBox();
            btn_Exit = new CustomPictureBox();
            btn_JoinRequest = new CustomButton();
            customGroupBox2.SuspendLayout();
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
            customGroupBox2.Controls.Add(lblStatus);
            customGroupBox2.Controls.Add(btn_search);
            customGroupBox2.Controls.Add(textBox1);
            customGroupBox2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            customGroupBox2.ForeColor = Color.White;
            customGroupBox2.Location = new Point(100, 358);
            customGroupBox2.Margin = new Padding(3, 2, 3, 2);
            customGroupBox2.Name = "customGroupBox2";
            customGroupBox2.Padding = new Padding(3, 2, 3, 2);
            customGroupBox2.Size = new Size(467, 133);
            customGroupBox2.TabIndex = 3;
            customGroupBox2.TabStop = false;
            customGroupBox2.Text = "Panel B";
            customGroupBox2.TextColor = Color.Black;
            customGroupBox2.TitleAlign = ContentAlignment.TopLeft;
            customGroupBox2.TitlePadding = 10;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(29, 86);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(81, 25);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Standby";
            // 
            // btn_search
            // 
            btn_search.ForeColor = Color.Black;
            btn_search.Location = new Point(352, 23);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(88, 58);
            btn_search.TabIndex = 1;
            btn_search.Text = "Search";
            btn_search.UseVisualStyleBackColor = true;
            btn_search.Click += btn_search_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 37);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Enter Server IP address here";
            textBox1.Size = new Size(317, 32);
            textBox1.TabIndex = 0;
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
            // btn_JoinRequest
            // 
            btn_JoinRequest.BackgroundColor = Color.FromArgb(87, 162, 62);
            btn_JoinRequest.BorderColor = Color.FromArgb(87, 162, 62);
            btn_JoinRequest.BorderRadius = 20;
            btn_JoinRequest.BorderSize = 2;
            btn_JoinRequest.ButtonImage = null;
            btn_JoinRequest.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btn_JoinRequest.ImageSize = 24;
            btn_JoinRequest.Location = new Point(98, 496);
            btn_JoinRequest.Name = "btn_JoinRequest";
            btn_JoinRequest.Size = new Size(469, 65);
            btn_JoinRequest.TabIndex = 8;
            btn_JoinRequest.Text = "Request to join";
            btn_JoinRequest.TextAlign = ContentAlignment.MiddleCenter;
            btn_JoinRequest.TextColor = Color.White;
            btn_JoinRequest.Visible = false;
            btn_JoinRequest.Click += btn_JoinRequest_Click;
            // 
            // ClientLobby
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 588);
            Controls.Add(btn_JoinRequest);
            Controls.Add(btn_Exit);
            Controls.Add(customGroupBox2);
            Controls.Add(customGroupBox1);
            Controls.Add(customPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ClientLobby";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client Lobby";
            customGroupBox2.ResumeLayout(false);
            customGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btn_Exit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CustomPanel customPanel1;
        private CustomGroupBox customGroupBox1;
        private CustomGroupBox customGroupBox2;
        private CustomPictureBox btn_Exit;
        private CustomButton btn_JoinRequest;
        private TextBox textBox1;
        private Button btn_search;
        private Label lblStatus;
    }
}