namespace WordleClient.GUI
{
    partial class FormSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            customPanel1 = new WordleClient.CuttomControls.CustomPanel();
            btn_Exit = new WordleClient.CustomControls.CustomPictureBox();
            btn_Sound = new WordleClient.CustomControls.CustomPictureBox();
            btn_DarkLight = new CustomCheckboxToggle();
            groupBox1 = new GroupBox();
            customButtonTwoText2 = new CustomButtonTwoText();
            customButtonTwoText1 = new CustomButtonTwoText();
            ((System.ComponentModel.ISupportInitialize)btn_Exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Sound).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderRadius = 30;
            customPanel1.ForeColor = Color.Black;
            customPanel1.GradientAngle = 90F;
            customPanel1.GradientBottomColor = Color.SkyBlue;
            customPanel1.GradientTopColor = Color.FromArgb(192, 255, 255);
            customPanel1.Location = new Point(67, 45);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(614, 615);
            customPanel1.TabIndex = 1;
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
            btn_Exit.Location = new Point(713, 0);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(34, 35);
            btn_Exit.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Exit.TabIndex = 8;
            btn_Exit.TabStop = false;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // btn_Sound
            // 
            btn_Sound.boderGradientBottom1 = Color.FromArgb(192, 255, 255);
            btn_Sound.boderGradientTop1 = Color.Cyan;
            btn_Sound.boderRadius1 = 40;
            btn_Sound.boderSize1 = 2;
            btn_Sound.Cursor = Cursors.Hand;
            btn_Sound.gradientAngle1 = 90F;
            btn_Sound.Image = Properties.Resources.SoundONicon;
            btn_Sound.Location = new Point(34, 58);
            btn_Sound.Name = "btn_Sound";
            btn_Sound.Size = new Size(70, 70);
            btn_Sound.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Sound.TabIndex = 9;
            btn_Sound.TabStop = false;
            btn_Sound.Click += btn_Sound_Click;
            // 
            // btn_DarkLight
            // 
            btn_DarkLight.BackColor = Color.White;
            btn_DarkLight.BackColorChecked = Color.FromArgb(255, 255, 128);
            btn_DarkLight.BackColorUnchecked = Color.Black;
            btn_DarkLight.Checked = false;
            btn_DarkLight.CircleImage = Properties.Resources.Dark;
            btn_DarkLight.Cursor = Cursors.Hand;
            btn_DarkLight.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_DarkLight.ForeColor = Color.Red;
            btn_DarkLight.Location = new Point(34, 165);
            btn_DarkLight.Name = "btn_DarkLight";
            btn_DarkLight.Size = new Size(161, 74);
            btn_DarkLight.TabIndex = 10;
            btn_DarkLight.TextLabel = "Dark";
            btn_DarkLight.Click += btn_DarkLight_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(customButtonTwoText2);
            groupBox1.Controls.Add(customButtonTwoText1);
            groupBox1.Controls.Add(btn_Sound);
            groupBox1.Controls.Add(btn_DarkLight);
            groupBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(113, 84);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(524, 540);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Setting";
            // 
            // customButtonTwoText2
            // 
            customButtonTwoText2.BorderColor = Color.DarkSlateBlue;
            customButtonTwoText2.BorderRadius = 20;
            customButtonTwoText2.BorderSize = 2;
            customButtonTwoText2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButtonTwoText2.LeftBackColor = Color.MediumSlateBlue;
            customButtonTwoText2.LeftText = "Dark";
            customButtonTwoText2.Location = new Point(242, 170);
            customButtonTwoText2.Name = "customButtonTwoText2";
            customButtonTwoText2.RightBackColor = Color.SlateBlue;
            customButtonTwoText2.RightText = "Light";
            customButtonTwoText2.Size = new Size(194, 69);
            customButtonTwoText2.TabIndex = 11;
            customButtonTwoText2.Text = "customButtonTwoText1";
            // 
            // customButtonTwoText1
            // 
            customButtonTwoText1.BorderColor = Color.DarkSlateBlue;
            customButtonTwoText1.BorderRadius = 20;
            customButtonTwoText1.BorderSize = 2;
            customButtonTwoText1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButtonTwoText1.LeftBackColor = Color.MediumSlateBlue;
            customButtonTwoText1.LeftText = "ON";
            customButtonTwoText1.Location = new Point(242, 59);
            customButtonTwoText1.Name = "customButtonTwoText1";
            customButtonTwoText1.RightBackColor = Color.SlateBlue;
            customButtonTwoText1.RightText = "OFF";
            customButtonTwoText1.Size = new Size(194, 69);
            customButtonTwoText1.TabIndex = 11;
            customButtonTwoText1.Text = "customButtonTwoText1";
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 710);
            Controls.Add(groupBox1);
            Controls.Add(btn_Exit);
            Controls.Add(customPanel1);
            Name = "FormSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSetting";
            Load += FormSetting_Load;
            ((System.ComponentModel.ISupportInitialize)btn_Exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Sound).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CuttomControls.CustomPanel customPanel1;
        private CustomControls.CustomPictureBox btn_Exit;
        private CustomControls.CustomPictureBox btn_Sound;
        private CustomCheckboxToggle btn_DarkLight;
        private GroupBox groupBox1;
        private CustomButtonTwoText customButtonTwoText2;
        private CustomButtonTwoText customButtonTwoText1;
    }
}