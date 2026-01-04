namespace WordleClient.libraries.CustomControls
{
    partial class AlertBox
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
            lbl_Caption = new Label();
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
            customGroupBox1.Controls.Add(lbl_Caption);
            customGroupBox1.Controls.Add(customPictureBox1);
            customGroupBox1.Location = new Point(0, 0);
            customGroupBox1.Name = "customGroupBox1";
            customGroupBox1.Size = new Size(420, 80);
            customGroupBox1.TabIndex = 0;
            customGroupBox1.TabStop = false;
            customGroupBox1.TextColor = Color.Black;
            customGroupBox1.TitleAlign = ContentAlignment.TopLeft;
            customGroupBox1.TitlePadding = 10;
            // 
            // lbl_Content
            // 
            lbl_Content.AutoSize = true;
            lbl_Content.Font = new Font("Segoe UI", 14F);
            lbl_Content.ForeColor = Color.Black;
            lbl_Content.Location = new Point(68, 41);
            lbl_Content.Name = "lbl_Content";
            lbl_Content.Size = new Size(167, 25);
            lbl_Content.TabIndex = 3;
            lbl_Content.Text = "Content goes here";
            // 
            // lbl_Caption
            // 
            lbl_Caption.AutoSize = true;
            lbl_Caption.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl_Caption.ForeColor = Color.Black;
            lbl_Caption.Location = new Point(68, 9);
            lbl_Caption.Name = "lbl_Caption";
            lbl_Caption.Size = new Size(81, 30);
            lbl_Caption.TabIndex = 4;
            lbl_Caption.Text = "Notice";
            // 
            // customPictureBox1
            // 
            customPictureBox1.BackColor = Color.White;
            customPictureBox1.boderGradientBottom1 = Color.Transparent;
            customPictureBox1.boderGradientTop1 = Color.Transparent;
            customPictureBox1.boderRadius1 = 20;
            customPictureBox1.boderSize1 = 1;
            customPictureBox1.gradientAngle1 = 90F;
            customPictureBox1.Location = new Point(12, 16);
            customPictureBox1.Name = "customPictureBox1";
            customPictureBox1.Size = new Size(50, 50);
            customPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox1.TabIndex = 5;
            customPictureBox1.TabStop = false;
            // 
            // AlertBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 80);
            Controls.Add(customGroupBox1);
            Name = "AlertBox";
            customGroupBox1.ResumeLayout(false);
            customGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CustomGroupBox customGroupBox1;
        private Label lbl_Content;
        private Label lbl_Caption;
        private CustomPictureBox customPictureBox1;
    }
}
