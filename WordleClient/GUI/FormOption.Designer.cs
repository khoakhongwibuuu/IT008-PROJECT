namespace WordleClient.GUI
{
    partial class FormOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOption));
            customPanel1 = new WordleClient.CuttomControls.CustomPanel();
            customGroupBox1 = new WordleClient.CuttomControls.CustomGroupBox();
            rd_Easy = new WordleClient.CustomControls.CustomRadioButton();
            rd_Hard = new WordleClient.CustomControls.CustomRadioButton();
            rd_Random = new WordleClient.CustomControls.CustomRadioButton();
            btn_StartGame = new CustomButtonAnimation();
            customGroupBox2 = new WordleClient.CuttomControls.CustomGroupBox();
            customLabel3 = new WordleClient.CustomControls.CustomLabel();
            customLabel2 = new WordleClient.CustomControls.CustomLabel();
            customLabel1 = new WordleClient.CustomControls.CustomLabel();
            trackBarGuess = new TrackBar();
            cbbTopic = new ComboBox();
            btn_Exit = new WordleClient.CustomControls.CustomPictureBox();
            customGroupBox1.SuspendLayout();
            customGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarGuess).BeginInit();
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
            customPanel1.GradientBottomColor = Color.SkyBlue;
            customPanel1.GradientTopColor = Color.FromArgb(192, 255, 255);
            customPanel1.Location = new Point(0, 0);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(760, 784);
            customPanel1.TabIndex = 0;
            // 
            // customGroupBox1
            // 
            customGroupBox1.BackColor = Color.Transparent;
            customGroupBox1.BackgroundColor = Color.White;
            customGroupBox1.BorderColor = Color.Teal;
            customGroupBox1.BorderRadius = 15;
            customGroupBox1.BorderSize = 2;
            customGroupBox1.Controls.Add(rd_Easy);
            customGroupBox1.Controls.Add(rd_Hard);
            customGroupBox1.Controls.Add(rd_Random);
            customGroupBox1.Font = new Font("Segoe UI", 12F);
            customGroupBox1.ForeColor = Color.White;
            customGroupBox1.Location = new Point(187, 37);
            customGroupBox1.Name = "customGroupBox1";
            customGroupBox1.Size = new Size(394, 291);
            customGroupBox1.TabIndex = 1;
            customGroupBox1.TabStop = false;
            customGroupBox1.Text = "Chọn Level";
            customGroupBox1.TextColor = Color.Black;
            customGroupBox1.TitleAlign = ContentAlignment.TopLeft;
            customGroupBox1.TitlePadding = 10;
            // 
            // rd_Easy
            // 
            rd_Easy.AutoSize = true;
            rd_Easy.BackColor = Color.White;
            rd_Easy.CheckedColor = Color.MediumSlateBlue;
            rd_Easy.Font = new Font("Segoe UI", 13.8F);
            rd_Easy.ForeColor = Color.Black;
            rd_Easy.Location = new Point(23, 215);
            rd_Easy.MinimumSize = new Size(0, 21);
            rd_Easy.Name = "rd_Easy";
            rd_Easy.Padding = new Padding(10, 0, 0, 0);
            rd_Easy.Size = new Size(90, 35);
            rd_Easy.TabIndex = 2;
            rd_Easy.TabStop = true;
            rd_Easy.Text = "Easy";
            rd_Easy.UnCheckedColor = Color.Gray;
            rd_Easy.UseVisualStyleBackColor = false;
            // 
            // rd_Hard
            // 
            rd_Hard.AutoSize = true;
            rd_Hard.BackColor = Color.White;
            rd_Hard.CheckedColor = Color.MediumSlateBlue;
            rd_Hard.Font = new Font("Segoe UI", 13.8F);
            rd_Hard.ForeColor = Color.Black;
            rd_Hard.Location = new Point(23, 135);
            rd_Hard.MinimumSize = new Size(0, 21);
            rd_Hard.Name = "rd_Hard";
            rd_Hard.Padding = new Padding(10, 0, 0, 0);
            rd_Hard.Size = new Size(95, 35);
            rd_Hard.TabIndex = 1;
            rd_Hard.TabStop = true;
            rd_Hard.Text = "Hard";
            rd_Hard.UnCheckedColor = Color.Gray;
            rd_Hard.UseVisualStyleBackColor = false;
            // 
            // rd_Random
            // 
            rd_Random.AutoSize = true;
            rd_Random.BackColor = Color.White;
            rd_Random.CheckedColor = Color.MediumSlateBlue;
            rd_Random.Font = new Font("Segoe UI", 13.8F);
            rd_Random.ForeColor = Color.Black;
            rd_Random.Location = new Point(23, 61);
            rd_Random.MinimumSize = new Size(0, 21);
            rd_Random.Name = "rd_Random";
            rd_Random.Padding = new Padding(10, 0, 0, 0);
            rd_Random.Size = new Size(131, 35);
            rd_Random.TabIndex = 0;
            rd_Random.TabStop = true;
            rd_Random.Text = "Random";
            rd_Random.UnCheckedColor = Color.Gray;
            rd_Random.UseVisualStyleBackColor = false;
            // 
            // btn_StartGame
            // 
            btn_StartGame.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_StartGame.BorderColor = Color.FromArgb(153, 214, 214);
            btn_StartGame.BorderRadius = 20;
            btn_StartGame.BorderSize = 2;
            btn_StartGame.ButtonImage = null;
            btn_StartGame.EnableStripe = true;
            btn_StartGame.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_StartGame.ImageSize = 24;
            btn_StartGame.Location = new Point(187, 660);
            btn_StartGame.Name = "btn_StartGame";
            btn_StartGame.Size = new Size(394, 84);
            btn_StartGame.StripeSpeed = 4;
            btn_StartGame.TabIndex = 2;
            btn_StartGame.Text = "StartGame";
            btn_StartGame.TextAlign = ContentAlignment.MiddleCenter;
            btn_StartGame.TextColor = Color.White;
            btn_StartGame.Click += btn_StartGame_Click;
            // 
            // customGroupBox2
            // 
            customGroupBox2.BackColor = Color.Transparent;
            customGroupBox2.BackgroundColor = Color.White;
            customGroupBox2.BorderColor = Color.Teal;
            customGroupBox2.BorderRadius = 15;
            customGroupBox2.BorderSize = 2;
            customGroupBox2.Controls.Add(customLabel3);
            customGroupBox2.Controls.Add(customLabel2);
            customGroupBox2.Controls.Add(customLabel1);
            customGroupBox2.Controls.Add(trackBarGuess);
            customGroupBox2.Controls.Add(cbbTopic);
            customGroupBox2.Font = new Font("Segoe UI", 12F);
            customGroupBox2.ForeColor = Color.White;
            customGroupBox2.Location = new Point(187, 366);
            customGroupBox2.Name = "customGroupBox2";
            customGroupBox2.Size = new Size(394, 263);
            customGroupBox2.TabIndex = 3;
            customGroupBox2.TabStop = false;
            customGroupBox2.Text = "Chọn Topic và cơ hội đoán";
            customGroupBox2.TextColor = Color.Black;
            customGroupBox2.TitleAlign = ContentAlignment.TopLeft;
            customGroupBox2.TitlePadding = 10;
            // 
            // customLabel3
            // 
            customLabel3.BoderRadius = 3F;
            customLabel3.BorderColor = Color.White;
            customLabel3.EndColor = Color.MediumPurple;
            customLabel3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            customLabel3.ForeColor = Color.White;
            customLabel3.Location = new Point(187, 169);
            customLabel3.Name = "customLabel3";
            customLabel3.ShadowOffset = 4;
            customLabel3.Size = new Size(34, 52);
            customLabel3.StartColor = Color.MediumSlateBlue;
            customLabel3.TabIndex = 2;
            customLabel3.Text = "7";
            // 
            // customLabel2
            // 
            customLabel2.BoderRadius = 3F;
            customLabel2.BorderColor = Color.White;
            customLabel2.EndColor = Color.MediumPurple;
            customLabel2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            customLabel2.ForeColor = Color.White;
            customLabel2.Location = new Point(292, 169);
            customLabel2.Name = "customLabel2";
            customLabel2.ShadowOffset = 4;
            customLabel2.Size = new Size(34, 52);
            customLabel2.StartColor = Color.MediumSlateBlue;
            customLabel2.TabIndex = 2;
            customLabel2.Text = "8";
            // 
            // customLabel1
            // 
            customLabel1.BoderRadius = 3F;
            customLabel1.BorderColor = Color.White;
            customLabel1.EndColor = Color.MediumPurple;
            customLabel1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            customLabel1.ForeColor = Color.White;
            customLabel1.Location = new Point(84, 169);
            customLabel1.Name = "customLabel1";
            customLabel1.ShadowOffset = 4;
            customLabel1.Size = new Size(34, 52);
            customLabel1.StartColor = Color.MediumSlateBlue;
            customLabel1.TabIndex = 2;
            customLabel1.Text = "6";
            // 
            // trackBarGuess
            // 
            trackBarGuess.Location = new Point(81, 144);
            trackBarGuess.Maximum = 8;
            trackBarGuess.Minimum = 6;
            trackBarGuess.Name = "trackBarGuess";
            trackBarGuess.Size = new Size(245, 56);
            trackBarGuess.TabIndex = 1;
            trackBarGuess.Value = 6;
            // 
            // cbbTopic
            // 
            cbbTopic.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbbTopic.FormattingEnabled = true;
            cbbTopic.Location = new Point(81, 64);
            cbbTopic.Name = "cbbTopic";
            cbbTopic.Size = new Size(245, 39);
            cbbTopic.TabIndex = 0;
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
            btn_Exit.Location = new Point(726, 0);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(34, 35);
            btn_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Exit.TabIndex = 7;
            btn_Exit.TabStop = false;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // FormOption
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 784);
            Controls.Add(btn_Exit);
            Controls.Add(customGroupBox2);
            Controls.Add(btn_StartGame);
            Controls.Add(customGroupBox1);
            Controls.Add(customPanel1);
            Name = "FormOption";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormOption";
            Load += FormOption_Load;
            customGroupBox1.ResumeLayout(false);
            customGroupBox1.PerformLayout();
            customGroupBox2.ResumeLayout(false);
            customGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarGuess).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Exit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CuttomControls.CustomPanel customPanel1;
        private CuttomControls.CustomGroupBox customGroupBox1;
        private CustomControls.CustomRadioButton rd_Random;
        private CustomButtonAnimation btn_StartGame;
        private CustomControls.CustomRadioButton rd_Easy;
        private CustomControls.CustomRadioButton rd_Hard;
        private CuttomControls.CustomGroupBox customGroupBox2;
        private TrackBar trackBarGuess;
        private ComboBox cbbTopic;
        private CustomControls.CustomPictureBox btn_Exit;
        private CustomControls.CustomLabel customLabel3;
        private CustomControls.CustomLabel customLabel2;
        private CustomControls.CustomLabel customLabel1;
    }
}