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
            customButtonAnimation1 = new WordleClient.libraries.CustomControls.CustomButtonAnimation();
            customButtonAnimation2 = new WordleClient.libraries.CustomControls.CustomButtonAnimation();
            customButton1 = new WordleClient.libraries.CustomControls.CustomButton();
            SuspendLayout();
            // 
            // customButtonAnimation1
            // 
            customButtonAnimation1.BackgroundColor = Color.Blue;
            customButtonAnimation1.BorderColor = Color.FromArgb(153, 214, 214);
            customButtonAnimation1.BorderRadius = 20;
            customButtonAnimation1.BorderSize = 2;
            customButtonAnimation1.ButtonImage = null;
            customButtonAnimation1.EnableStripe = true;
            customButtonAnimation1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            customButtonAnimation1.ImageSize = 24;
            customButtonAnimation1.Location = new Point(74, 68);
            customButtonAnimation1.Name = "customButtonAnimation1";
            customButtonAnimation1.Size = new Size(270, 71);
            customButtonAnimation1.StripeSpeed = 4;
            customButtonAnimation1.TabIndex = 0;
            customButtonAnimation1.Text = "Host my own game room";
            customButtonAnimation1.TextAlign = ContentAlignment.MiddleCenter;
            customButtonAnimation1.TextColor = Color.White;
            // 
            // customButtonAnimation2
            // 
            customButtonAnimation2.BackgroundColor = Color.Blue;
            customButtonAnimation2.BorderColor = Color.FromArgb(153, 214, 214);
            customButtonAnimation2.BorderRadius = 20;
            customButtonAnimation2.BorderSize = 2;
            customButtonAnimation2.ButtonImage = null;
            customButtonAnimation2.EnableStripe = true;
            customButtonAnimation2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            customButtonAnimation2.ImageSize = 24;
            customButtonAnimation2.Location = new Point(73, 162);
            customButtonAnimation2.Name = "customButtonAnimation2";
            customButtonAnimation2.Size = new Size(270, 71);
            customButtonAnimation2.StripeSpeed = 4;
            customButtonAnimation2.TabIndex = 0;
            customButtonAnimation2.Text = "Join other game room";
            customButtonAnimation2.TextAlign = ContentAlignment.MiddleCenter;
            customButtonAnimation2.TextColor = Color.White;
            // 
            // customButton1
            // 
            customButton1.BackgroundColor = Color.Blue;
            customButton1.BorderColor = Color.White;
            customButton1.BorderRadius = 20;
            customButton1.BorderSize = 2;
            customButton1.ButtonImage = null;
            customButton1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton1.ImageSize = 24;
            customButton1.Location = new Point(95, 338);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(204, 56);
            customButton1.TabIndex = 1;
            customButton1.Text = "THOÁT";
            customButton1.TextAlign = ContentAlignment.MiddleCenter;
            customButton1.TextColor = Color.White;
            customButton1.Click += customButton1_Click;
            // 
            // Multiplayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(410, 450);
            Controls.Add(customButton1);
            Controls.Add(customButtonAnimation2);
            Controls.Add(customButtonAnimation1);
            Name = "Multiplayer";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Multiplayer";
            ResumeLayout(false);
        }

        #endregion

        private libraries.CustomControls.CustomButtonAnimation customButtonAnimation1;
        private libraries.CustomControls.CustomButtonAnimation customButtonAnimation2;
        private libraries.CustomControls.CustomButton customButton1;
    }
}