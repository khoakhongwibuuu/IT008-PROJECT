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
            customControl11 = new CustomControl1();
            panel1 = new Panel();
            btn_Multiplayer = new CustomControl1();
            btn_SinglePlayer = new CustomControl1();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // customControl11
            // 
            customControl11.BackColor = Color.White;
            customControl11.BackgroundColor = Color.White;
            customControl11.BackgroundImageLayout = ImageLayout.Stretch;
            customControl11.BorderColor = Color.White;
            customControl11.BorderRadius = 25;
            customControl11.BorderSize = 2;
            customControl11.ButtonImage = (Image)resources.GetObject("customControl11.ButtonImage");
            customControl11.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customControl11.ImageSize = 30;
            customControl11.Location = new Point(1125, 12);
            customControl11.Name = "customControl11";
            customControl11.Size = new Size(45, 50);
            customControl11.TabIndex = 0;
            customControl11.TextAlign = ContentAlignment.MiddleCenter;
            customControl11.TextColor = Color.White;
            customControl11.Click += customControl11_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Multiplayer);
            panel1.Controls.Add(btn_SinglePlayer);
            panel1.Location = new Point(191, 522);
            panel1.Name = "panel1";
            panel1.Size = new Size(830, 284);
            panel1.TabIndex = 1;
            // 
            // btn_Multiplayer
            // 
            btn_Multiplayer.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_Multiplayer.BorderColor = Color.FromArgb(153, 214, 214);
            btn_Multiplayer.BorderRadius = 20;
            btn_Multiplayer.BorderSize = 2;
            btn_Multiplayer.ButtonImage = null;
            btn_Multiplayer.Font = new Font("Segoe UI", 16.2F);
            btn_Multiplayer.ImageSize = 24;
            btn_Multiplayer.Location = new Point(202, 173);
            btn_Multiplayer.Name = "btn_Multiplayer";
            btn_Multiplayer.RightToLeft = RightToLeft.No;
            btn_Multiplayer.Size = new Size(397, 64);
            btn_Multiplayer.TabIndex = 3;
            btn_Multiplayer.Text = "MultiPlayer";
            btn_Multiplayer.TextAlign = ContentAlignment.MiddleCenter;
            btn_Multiplayer.TextColor = Color.White;
            // 
            // btn_SinglePlayer
            // 
            btn_SinglePlayer.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_SinglePlayer.BorderColor = Color.FromArgb(153, 214, 214);
            btn_SinglePlayer.BorderRadius = 20;
            btn_SinglePlayer.BorderSize = 2;
            btn_SinglePlayer.ButtonImage = null;
            btn_SinglePlayer.Font = new Font("Segoe UI", 16.2F);
            btn_SinglePlayer.ImageSize = 24;
            btn_SinglePlayer.Location = new Point(202, 62);
            btn_SinglePlayer.Name = "btn_SinglePlayer";
            btn_SinglePlayer.RightToLeft = RightToLeft.No;
            btn_SinglePlayer.Size = new Size(397, 64);
            btn_SinglePlayer.TabIndex = 2;
            btn_SinglePlayer.Text = "SinglePlayer";
            btn_SinglePlayer.TextAlign = ContentAlignment.MiddleCenter;
            btn_SinglePlayer.TextColor = Color.White;
            btn_SinglePlayer.Click += btn_SinglePlayer_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1191, 818);
            Controls.Add(panel1);
            Controls.Add(customControl11);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainMenu";
            Load += MainMenu_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomControl1 customControl11;
        private Panel panel1;
        private CustomControl1 btn_Multiplayer;
        private CustomControl1 btn_SinglePlayer;
    }
}