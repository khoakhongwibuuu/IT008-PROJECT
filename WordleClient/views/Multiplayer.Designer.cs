namespace WordleClient.views
{
    partial class Multiplayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Multiplayer));
            HostMyOwnBtn = new WordleClient.libraries.CustomControls.CustomButton();
            JoinOtherBtn = new WordleClient.libraries.CustomControls.CustomButton();
            btn_Exit = new WordleClient.libraries.CustomControls.CustomPictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)btn_Exit).BeginInit();
            SuspendLayout();
            // 
            // HostMyOwnBtn
            // 
            HostMyOwnBtn.BackgroundColor = Color.FromArgb(122, 178, 211);
            HostMyOwnBtn.BorderColor = Color.FromArgb(122, 178, 211);
            HostMyOwnBtn.BorderRadius = 20;
            HostMyOwnBtn.BorderSize = 2;
            HostMyOwnBtn.ButtonImage = null;
            HostMyOwnBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HostMyOwnBtn.ImageSize = 24;
            HostMyOwnBtn.Location = new Point(60, 71);
            HostMyOwnBtn.Name = "HostMyOwnBtn";
            HostMyOwnBtn.Size = new Size(300, 45);
            HostMyOwnBtn.TabIndex = 2;
            HostMyOwnBtn.Text = "\U0001f9d1‍💻 Host my own server";
            HostMyOwnBtn.TextAlign = ContentAlignment.MiddleCenter;
            HostMyOwnBtn.TextColor = Color.White;
            HostMyOwnBtn.Click += HostMyOwnBtn_Click;
            // 
            // JoinOtherBtn
            // 
            JoinOtherBtn.BackgroundColor = Color.FromArgb(255, 116, 108);
            JoinOtherBtn.BorderColor = Color.FromArgb(255, 116, 108);
            JoinOtherBtn.BorderRadius = 20;
            JoinOtherBtn.BorderSize = 2;
            JoinOtherBtn.ButtonImage = null;
            JoinOtherBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            JoinOtherBtn.ImageSize = 24;
            JoinOtherBtn.Location = new Point(60, 124);
            JoinOtherBtn.Name = "JoinOtherBtn";
            JoinOtherBtn.Size = new Size(300, 45);
            JoinOtherBtn.TabIndex = 3;
            JoinOtherBtn.Text = "💻 Join other's server";
            JoinOtherBtn.TextAlign = ContentAlignment.MiddleCenter;
            JoinOtherBtn.TextColor = Color.White;
            JoinOtherBtn.Click += JoinOtherBtn_Click;
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
            btn_Exit.Location = new Point(378, 11);
            btn_Exit.Margin = new Padding(3, 2, 3, 2);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(30, 30);
            btn_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Exit.TabIndex = 9;
            btn_Exit.TabStop = false;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(118, 11);
            label1.Name = "label1";
            label1.Size = new Size(184, 32);
            label1.TabIndex = 10;
            label1.Text = "Server selector";
            // 
            // Multiplayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(420, 240);
            Controls.Add(label1);
            Controls.Add(btn_Exit);
            Controls.Add(JoinOtherBtn);
            Controls.Add(HostMyOwnBtn);
            Name = "Multiplayer";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Multiplayer";
            ((System.ComponentModel.ISupportInitialize)btn_Exit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private libraries.CustomControls.CustomButton HostMyOwnBtn;
        private libraries.CustomControls.CustomButton JoinOtherBtn;
        private libraries.CustomControls.CustomPictureBox btn_Exit;
        private Label label1;
    }
}