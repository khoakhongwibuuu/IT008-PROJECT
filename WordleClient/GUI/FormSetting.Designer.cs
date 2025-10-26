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
            customControl11 = new CustomControl1();
            panel1 = new Panel();
            btn_Sound = new CustomControl1();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // customControl11
            // 
            customControl11.BackgroundColor = Color.White;
            customControl11.BorderColor = Color.White;
            customControl11.BorderRadius = 20;
            customControl11.BorderSize = 0;
            customControl11.ButtonImage = (Image)resources.GetObject("customControl11.ButtonImage");
            customControl11.ImageSize = 40;
            customControl11.Location = new Point(479, 12);
            customControl11.Name = "customControl11";
            customControl11.Size = new Size(59, 51);
            customControl11.TabIndex = 1;
            customControl11.Text = "customControl11";
            customControl11.TextAlign = ContentAlignment.MiddleCenter;
            customControl11.TextColor = Color.White;
            customControl11.Click += customControl11_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(btn_Sound);
            panel1.Location = new Point(40, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 594);
            panel1.TabIndex = 2;
            // 
            // btn_Sound
            // 
            btn_Sound.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_Sound.BorderColor = Color.FromArgb(153, 214, 214);
            btn_Sound.BorderRadius = 20;
            btn_Sound.BorderSize = 2;
            btn_Sound.ButtonImage = (Image)resources.GetObject("btn_Sound.ButtonImage");
            btn_Sound.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Sound.ImageSize = 35;
            btn_Sound.Location = new Point(167, 52);
            btn_Sound.Name = "btn_Sound";
            btn_Sound.Size = new Size(116, 67);
            btn_Sound.TabIndex = 0;
            btn_Sound.Text = "ON";
            btn_Sound.TextAlign = ContentAlignment.MiddleCenter;
            btn_Sound.TextColor = Color.White;
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 718);
            Controls.Add(panel1);
            Controls.Add(customControl11);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSetting";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomControl1 customControl11;
        private Panel panel1;
        private CustomControl1 btn_Sound;
    }
}