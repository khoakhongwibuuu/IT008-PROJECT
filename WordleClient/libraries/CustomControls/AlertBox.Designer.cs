namespace WordleClient.libraries.CustomControls
{
    partial class AlertBox
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
            lbl_Caption = new Label();
            lbl_Content = new Label();
            customPanel1 = new CustomPanel();
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // customPictureBox1
            // 
            customPictureBox1.boderGradientBottom1 = Color.FromArgb(128, 255, 255);
            customPictureBox1.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox1.boderRadius1 = 40;
            customPictureBox1.boderSize1 = 2;
            customPictureBox1.gradientAngle1 = 90F;
            customPictureBox1.Image = Properties.Resources.tickSuccess;
            customPictureBox1.Location = new Point(31, 7);
            customPictureBox1.Name = "customPictureBox1";
            customPictureBox1.Size = new Size(63, 59);
            customPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox1.TabIndex = 0;
            customPictureBox1.TabStop = false;
            // 
            // lbl_Caption
            // 
            lbl_Caption.AutoSize = true;
            lbl_Caption.BackColor = Color.FromArgb(224, 224, 224);
            lbl_Caption.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Caption.Location = new Point(128, 9);
            lbl_Caption.Name = "lbl_Caption";
            lbl_Caption.Size = new Size(124, 25);
            lbl_Caption.TabIndex = 1;
            lbl_Caption.Text = "Caption Here";
            // 
            // lbl_Content
            // 
            lbl_Content.AutoSize = true;
            lbl_Content.BackColor = Color.White;
            lbl_Content.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_Content.ForeColor = Color.Black;
            lbl_Content.Location = new Point(128, 41);
            lbl_Content.Name = "lbl_Content";
            lbl_Content.Size = new Size(136, 28);
            lbl_Content.TabIndex = 1;
            lbl_Content.Text = "Content Here";
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderRadius = 30;
            customPanel1.Dock = DockStyle.Fill;
            customPanel1.ForeColor = Color.Black;
            customPanel1.GradientAngle = 90F;
            customPanel1.GradientBottomColor = Color.FromArgb(192, 255, 192);
            customPanel1.GradientTopColor = Color.FromArgb(128, 255, 255);
            customPanel1.Location = new Point(0, 0);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(675, 75);
            customPanel1.TabIndex = 2;
            // 
            // AlertBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderRadius = 30;
            ClientSize = new Size(675, 75);
            Controls.Add(lbl_Content);
            Controls.Add(lbl_Caption);
            Controls.Add(customPictureBox1);
            Controls.Add(customPanel1);
            Name = "AlertBox";
            Text = "AlertBox";
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomPictureBox customPictureBox1;
        private Label lbl_Caption;
        private Label lbl_Content;
        private CustomPanel customPanel1;
    }
}