using WordleClient.libraries.CustomControls;

namespace WordleClient.views
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
            btn_Exit = new CustomPictureBox();
            btn_Sound = new CustomPictureBox();
            btn_DarkLight = new CustomCheckboxToggle();
            ((System.ComponentModel.ISupportInitialize)btn_Exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Sound).BeginInit();
            SuspendLayout();
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
            btn_Sound.Image = Properties.Resources.UnMute;
            btn_Sound.Location = new Point(12, 76);
            btn_Sound.Margin = new Padding(3, 2, 3, 2);
            btn_Sound.Name = "btn_Sound";
            btn_Sound.Size = new Size(60, 60);
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
            btn_DarkLight.Location = new Point(12, 140);
            btn_DarkLight.Margin = new Padding(3, 2, 3, 2);
            btn_DarkLight.Name = "btn_DarkLight";
            btn_DarkLight.Size = new Size(141, 56);
            btn_DarkLight.TabIndex = 10;
            btn_DarkLight.TextLabel = "Dark";
            btn_DarkLight.Click += btn_DarkLight_Click;
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 240);
            Controls.Add(btn_Exit);
            Controls.Add(btn_DarkLight);
            Controls.Add(btn_Sound);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSetting";
            Load += FormSetting_Load;
            ((System.ComponentModel.ISupportInitialize)btn_Exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Sound).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private CustomPictureBox btn_Exit;
        private CustomPictureBox btn_Sound;
        private CustomCheckboxToggle btn_DarkLight;
    }
}