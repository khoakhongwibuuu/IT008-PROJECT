namespace WordleClient.libraries.CustomControls
{
    partial class CustomMessageBoxYesNo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            customGroupBox1 = new CustomGroupBox();
            lbl_Content = new Label();
            customButtonNo = new CustomButton();
            customButtonYes = new CustomButton();
            customPictureBox1 = new CustomPictureBox();
            customGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // customGroupBox1
            // 
            customGroupBox1.BackColor = Color.Transparent;
            customGroupBox1.BackgroundColor = Color.White;
            customGroupBox1.BorderColor = Color.Black;
            customGroupBox1.BorderRadius = 15;
            customGroupBox1.BorderSize = 2;
            customGroupBox1.Controls.Add(lbl_Content);
            customGroupBox1.Controls.Add(customButtonNo);
            customGroupBox1.Controls.Add(customButtonYes);
            customGroupBox1.Controls.Add(customPictureBox1);
            customGroupBox1.Location = new Point(0, 0);
            customGroupBox1.Name = "customGroupBox1";
            customGroupBox1.Size = new Size(486, 300);
            customGroupBox1.TabIndex = 0;
            customGroupBox1.TabStop = false;
            customGroupBox1.TextColor = Color.Black;
            customGroupBox1.TitleAlign = ContentAlignment.TopLeft;
            customGroupBox1.TitlePadding = 10;
            // 
            // lbl_Content
            // 
            lbl_Content.BackColor = Color.White;
            lbl_Content.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl_Content.ForeColor = Color.Black;
            lbl_Content.Location = new Point(40, 110);
            lbl_Content.Name = "lbl_Content";
            lbl_Content.Size = new Size(406, 60);
            lbl_Content.TabIndex = 9;
            lbl_Content.Text = "Are you sure?";
            lbl_Content.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // customButtonNo
            // 
            customButtonNo.BackgroundColor = Color.White;
            customButtonNo.BorderColor = Color.Black;
            customButtonNo.BorderRadius = 14;
            customButtonNo.BorderSize = 1;
            customButtonNo.ButtonImage = null;
            customButtonNo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            customButtonNo.ImageSize = 24;
            customButtonNo.Location = new Point(287, 210);
            customButtonNo.Name = "customButtonNo";
            customButtonNo.Size = new Size(130, 50);
            customButtonNo.TabIndex = 10;
            customButtonNo.Text = "NO";
            customButtonNo.TextAlign = ContentAlignment.MiddleCenter;
            customButtonNo.TextColor = Color.Black;
            // 
            // customButtonYes
            // 
            customButtonYes.BackgroundColor = Color.Black;
            customButtonYes.BorderColor = Color.Black;
            customButtonYes.BorderRadius = 14;
            customButtonYes.BorderSize = 1;
            customButtonYes.ButtonImage = null;
            customButtonYes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            customButtonYes.ImageSize = 24;
            customButtonYes.Location = new Point(70, 210);
            customButtonYes.Name = "customButtonYes";
            customButtonYes.Size = new Size(130, 50);
            customButtonYes.TabIndex = 11;
            customButtonYes.Text = "YES";
            customButtonYes.TextAlign = ContentAlignment.MiddleCenter;
            customButtonYes.TextColor = Color.White;
            // 
            // customPictureBox1
            // 
            customPictureBox1.BackColor = Color.White;
            customPictureBox1.boderGradientBottom1 = Color.Transparent;
            customPictureBox1.boderGradientTop1 = Color.Transparent;
            customPictureBox1.boderRadius1 = 28;
            customPictureBox1.boderSize1 = 1;
            customPictureBox1.gradientAngle1 = 90F;
            customPictureBox1.Location = new Point(209, 36);
            customPictureBox1.Name = "customPictureBox1";
            customPictureBox1.Size = new Size(68, 68);
            customPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox1.TabIndex = 8;
            customPictureBox1.TabStop = false;
            // 
            // CustomMessageBoxYesNo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(486, 300);
            Controls.Add(customGroupBox1);
            Name = "CustomMessageBoxYesNo";
            Padding = new Padding(2);
            customGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CustomGroupBox customGroupBox1;
        private Label lbl_Content;
        private CustomButton customButtonNo;
        private CustomButton customButtonYes;
        private CustomPictureBox customPictureBox1;
    }
}
