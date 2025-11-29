namespace WordleClient.libraries.CustomControls
{
    partial class CustomDgv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomDgv));
            customPanel1 = new CustomPanel();
            Exit_1 = new CustomPictureBox();
            ((System.ComponentModel.ISupportInitialize)Exit_1).BeginInit();
            SuspendLayout();
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderRadius = 30;
            customPanel1.Dock = DockStyle.Fill;
            customPanel1.ForeColor = Color.FromArgb(100, 150, 200);
            customPanel1.GradientAngle = 90F;
            customPanel1.GradientBottomColor = Color.FromArgb(113, 92, 232);
            customPanel1.GradientTopColor = Color.FromArgb(113, 92, 232);
            customPanel1.Location = new Point(30, 30);
            customPanel1.Margin = new Padding(0);
            customPanel1.Name = "customPanel1";
            customPanel1.Padding = new Padding(4, 0, 4, 40);
            customPanel1.Size = new Size(1111, 693);
            customPanel1.TabIndex = 0;
            // 
            // Exit_1
            // 
            Exit_1.boderGradientBottom1 = Color.White;
            Exit_1.boderGradientTop1 = Color.White;
            Exit_1.boderRadius1 = 40;
            Exit_1.boderSize1 = 0;
            Exit_1.Cursor = Cursors.Hand;
            Exit_1.gradientAngle1 = 90F;
            Exit_1.Image = (Image)resources.GetObject("Exit_1.Image");
            Exit_1.Location = new Point(1136, 1);
            Exit_1.Name = "Exit_1";
            Exit_1.Size = new Size(34, 35);
            Exit_1.SizeMode = PictureBoxSizeMode.StretchImage;
            Exit_1.TabIndex = 7;
            Exit_1.TabStop = false;
            Exit_1.Click += Exit_1_Click;
            // 
            // CustomDgv
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 230, 255);
            ClientSize = new Size(1171, 743);
            Controls.Add(Exit_1);
            Controls.Add(customPanel1);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "CustomDgv";
            Padding = new Padding(30, 30, 30, 20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomDgv";
            ((System.ComponentModel.ISupportInitialize)Exit_1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CustomPanel customPanel1;
        private CustomPictureBox Exit_1;
    }
}