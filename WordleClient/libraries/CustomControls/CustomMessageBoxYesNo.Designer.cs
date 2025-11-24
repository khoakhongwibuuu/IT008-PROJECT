namespace WordleClient.libraries.CustomControls
{
    partial class CustomMessageBoxYesNo
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
            customPictureBox1 = new CustomPictureBox();
            customButton1 = new CustomButton();
            customButton2 = new CustomButton();
            lbl_Content = new Label();
            customPanel1 = new CustomPanel();
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // customPictureBox1
            // 
            customPictureBox1.boderGradientBottom1 = Color.SlateBlue;
            customPictureBox1.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox1.boderRadius1 = 40;
            customPictureBox1.boderSize1 = 2;
            customPictureBox1.gradientAngle1 = 90F;
            customPictureBox1.Location = new Point(209, 12);
            customPictureBox1.Name = "customPictureBox1";
            customPictureBox1.Size = new Size(68, 59);
            customPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox1.TabIndex = 0;
            customPictureBox1.TabStop = false;
            // 
            // customButton1
            // 
            customButton1.BackgroundColor = Color.White;
            customButton1.BorderColor = Color.FromArgb(153, 214, 214);
            customButton1.BorderRadius = 20;
            customButton1.BorderSize = 2;
            customButton1.ButtonImage = null;
            customButton1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic);
            customButton1.ImageSize = 24;
            customButton1.Location = new Point(43, 217);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(126, 60);
            customButton1.TabIndex = 1;
            customButton1.Text = "Yes";
            customButton1.TextAlign = ContentAlignment.MiddleCenter;
            customButton1.TextColor = Color.Black;
            // 
            // customButton2
            // 
            customButton2.BackgroundColor = Color.White;
            customButton2.BorderColor = Color.FromArgb(153, 214, 214);
            customButton2.BorderRadius = 20;
            customButton2.BorderSize = 2;
            customButton2.ButtonImage = null;
            customButton2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic);
            customButton2.ImageSize = 24;
            customButton2.Location = new Point(312, 217);
            customButton2.Name = "customButton2";
            customButton2.Size = new Size(126, 60);
            customButton2.TabIndex = 1;
            customButton2.Text = "No";
            customButton2.TextAlign = ContentAlignment.MiddleCenter;
            customButton2.TextColor = Color.Black;
            // 
            // lbl_Content
            // 
            lbl_Content.Anchor = AnchorStyles.None;
            lbl_Content.AutoSize = true;
            lbl_Content.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic);
            lbl_Content.Location = new Point(196, 125);
            lbl_Content.Name = "lbl_Content";
            lbl_Content.Size = new Size(81, 31);
            lbl_Content.TabIndex = 2;
            lbl_Content.Text = "label1";
            lbl_Content.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderRadius = 30;
            customPanel1.Dock = DockStyle.Fill;
            customPanel1.ForeColor = Color.Black;
            customPanel1.GradientAngle = 90F;
            customPanel1.GradientBottomColor = Color.FromArgb(192, 255, 255);
            customPanel1.GradientTopColor = Color.Red;
            customPanel1.Location = new Point(0, 0);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(486, 305);
            customPanel1.TabIndex = 3;
            // 
            // CustomMessageBoxYesNo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 305);
            Controls.Add(lbl_Content);
            Controls.Add(customButton2);
            Controls.Add(customButton1);
            Controls.Add(customPictureBox1);
            Controls.Add(customPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomMessageBoxYesNo";
            Text = "CustomMessageBoxYesNo";
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomPictureBox customPictureBox1;
        private CustomButton customButton1;
        private CustomButton customButton2;
        private Label lbl_Content;
        private CustomPanel customPanel1;
    }
}