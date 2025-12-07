namespace WordleClient.views
{
    partial class FormProfile
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
            customPanel1 = new WordleClient.libraries.CustomControls.CustomPanel();
            label1 = new Label();
            customPanel2 = new WordleClient.libraries.CustomControls.CustomPanel();
            customPictureBox1 = new WordleClient.libraries.CustomControls.CustomPictureBox();
            label2 = new Label();
            textBox1 = new TextBox();
            exit = new WordleClient.libraries.CustomControls.CustomPictureBox();
            label3 = new Label();
            panel_Avatar = new Panel();
            customPictureBox9 = new WordleClient.libraries.CustomControls.CustomPictureBox();
            customPictureBox5 = new WordleClient.libraries.CustomControls.CustomPictureBox();
            customPictureBox8 = new WordleClient.libraries.CustomControls.CustomPictureBox();
            customPictureBox7 = new WordleClient.libraries.CustomControls.CustomPictureBox();
            customPictureBox4 = new WordleClient.libraries.CustomControls.CustomPictureBox();
            customPictureBox6 = new WordleClient.libraries.CustomControls.CustomPictureBox();
            customPictureBox3 = new WordleClient.libraries.CustomControls.CustomPictureBox();
            customPictureBox2 = new WordleClient.libraries.CustomControls.CustomPictureBox();
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exit).BeginInit();
            panel_Avatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customPictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox2).BeginInit();
            SuspendLayout();
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderRadius = 30;
            customPanel1.ForeColor = Color.Black;
            customPanel1.GradientAngle = 90F;
            customPanel1.GradientBottomColor = Color.Gray;
            customPanel1.GradientTopColor = Color.Silver;
            customPanel1.Location = new Point(3, 3);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(461, 262);
            customPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Silver;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(98, 21);
            label1.Name = "label1";
            label1.Size = new Size(277, 50);
            label1.TabIndex = 1;
            label1.Text = "YOUR PROFILE";
            // 
            // customPanel2
            // 
            customPanel2.BackColor = Color.White;
            customPanel2.BorderRadius = 30;
            customPanel2.ForeColor = Color.Black;
            customPanel2.GradientAngle = 90F;
            customPanel2.GradientBottomColor = Color.CadetBlue;
            customPanel2.GradientTopColor = Color.DodgerBlue;
            customPanel2.Location = new Point(61, 111);
            customPanel2.Name = "customPanel2";
            customPanel2.Size = new Size(350, 130);
            customPanel2.TabIndex = 2;
            // 
            // customPictureBox1
            // 
            customPictureBox1.boderGradientBottom1 = Color.SlateBlue;
            customPictureBox1.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox1.boderRadius1 = 40;
            customPictureBox1.boderSize1 = 2;
            customPictureBox1.gradientAngle1 = 90F;
            customPictureBox1.Location = new Point(186, 74);
            customPictureBox1.Name = "customPictureBox1";
            customPictureBox1.Size = new Size(101, 84);
            customPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox1.TabIndex = 3;
            customPictureBox1.TabStop = false;
            customPictureBox1.Click += CustomPictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Silver;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(149, 268);
            label2.Name = "label2";
            label2.Size = new Size(173, 30);
            label2.TabIndex = 5;
            label2.Text = "Enter a nickname";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(61, 316);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(350, 35);
            textBox1.TabIndex = 6;
            textBox1.KeyDown += TextBox1_KeyDown;
            // 
            // exit
            // 
            exit.boderGradientBottom1 = Color.White;
            exit.boderGradientTop1 = Color.White;
            exit.boderRadius1 = 40;
            exit.boderSize1 = 0;
            exit.Cursor = Cursors.Hand;
            exit.gradientAngle1 = 90F;
            exit.Image = Properties.Resources.Exit;
            exit.Location = new Point(427, 11);
            exit.Margin = new Padding(3, 2, 3, 2);
            exit.Name = "exit";
            exit.Size = new Size(27, 26);
            exit.SizeMode = PictureBoxSizeMode.StretchImage;
            exit.TabIndex = 16;
            exit.TabStop = false;
            exit.Click += Exit_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.Silver;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(187, 177);
            label3.Name = "label3";
            label3.Size = new Size(100, 30);
            label3.TabIndex = 17;
            label3.Text = "Unknown";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Avatar
            // 
            panel_Avatar.BorderStyle = BorderStyle.Fixed3D;
            panel_Avatar.Controls.Add(customPictureBox9);
            panel_Avatar.Controls.Add(customPictureBox5);
            panel_Avatar.Controls.Add(customPictureBox8);
            panel_Avatar.Controls.Add(customPictureBox7);
            panel_Avatar.Controls.Add(customPictureBox4);
            panel_Avatar.Controls.Add(customPictureBox6);
            panel_Avatar.Controls.Add(customPictureBox3);
            panel_Avatar.Controls.Add(customPictureBox2);
            panel_Avatar.Location = new Point(3, 360);
            panel_Avatar.Margin = new Padding(6);
            panel_Avatar.Name = "panel_Avatar";
            panel_Avatar.Size = new Size(461, 295);
            panel_Avatar.TabIndex = 18;
            // 
            // customPictureBox9
            // 
            customPictureBox9.boderGradientBottom1 = Color.SlateBlue;
            customPictureBox9.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox9.boderRadius1 = 40;
            customPictureBox9.boderSize1 = 2;
            customPictureBox9.gradientAngle1 = 90F;
            customPictureBox9.Location = new Point(348, 173);
            customPictureBox9.Name = "customPictureBox9";
            customPictureBox9.Size = new Size(101, 84);
            customPictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox9.TabIndex = 7;
            customPictureBox9.TabStop = false;
            // 
            // customPictureBox5
            // 
            customPictureBox5.boderGradientBottom1 = Color.SlateBlue;
            customPictureBox5.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox5.boderRadius1 = 40;
            customPictureBox5.boderSize1 = 2;
            customPictureBox5.gradientAngle1 = 90F;
            customPictureBox5.Location = new Point(348, 31);
            customPictureBox5.Name = "customPictureBox5";
            customPictureBox5.Size = new Size(101, 84);
            customPictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox5.TabIndex = 7;
            customPictureBox5.TabStop = false;
            // 
            // customPictureBox8
            // 
            customPictureBox8.boderGradientBottom1 = Color.SlateBlue;
            customPictureBox8.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox8.boderRadius1 = 40;
            customPictureBox8.boderSize1 = 2;
            customPictureBox8.gradientAngle1 = 90F;
            customPictureBox8.Location = new Point(230, 173);
            customPictureBox8.Name = "customPictureBox8";
            customPictureBox8.Size = new Size(101, 84);
            customPictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox8.TabIndex = 6;
            customPictureBox8.TabStop = false;
            // 
            // customPictureBox7
            // 
            customPictureBox7.boderGradientBottom1 = Color.SlateBlue;
            customPictureBox7.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox7.boderRadius1 = 40;
            customPictureBox7.boderSize1 = 2;
            customPictureBox7.gradientAngle1 = 90F;
            customPictureBox7.Location = new Point(117, 173);
            customPictureBox7.Name = "customPictureBox7";
            customPictureBox7.Size = new Size(101, 84);
            customPictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox7.TabIndex = 5;
            customPictureBox7.TabStop = false;
            // 
            // customPictureBox4
            // 
            customPictureBox4.boderGradientBottom1 = Color.SlateBlue;
            customPictureBox4.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox4.boderRadius1 = 40;
            customPictureBox4.boderSize1 = 2;
            customPictureBox4.gradientAngle1 = 90F;
            customPictureBox4.Location = new Point(230, 31);
            customPictureBox4.Name = "customPictureBox4";
            customPictureBox4.Size = new Size(101, 84);
            customPictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox4.TabIndex = 6;
            customPictureBox4.TabStop = false;
            // 
            // customPictureBox6
            // 
            customPictureBox6.boderGradientBottom1 = Color.SlateBlue;
            customPictureBox6.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox6.boderRadius1 = 40;
            customPictureBox6.boderSize1 = 2;
            customPictureBox6.gradientAngle1 = 90F;
            customPictureBox6.Location = new Point(7, 173);
            customPictureBox6.Name = "customPictureBox6";
            customPictureBox6.Size = new Size(101, 84);
            customPictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox6.TabIndex = 4;
            customPictureBox6.TabStop = false;
            // 
            // customPictureBox3
            // 
            customPictureBox3.boderGradientBottom1 = Color.SlateBlue;
            customPictureBox3.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox3.boderRadius1 = 40;
            customPictureBox3.boderSize1 = 2;
            customPictureBox3.gradientAngle1 = 90F;
            customPictureBox3.Location = new Point(117, 31);
            customPictureBox3.Name = "customPictureBox3";
            customPictureBox3.Size = new Size(101, 84);
            customPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox3.TabIndex = 5;
            customPictureBox3.TabStop = false;
            // 
            // customPictureBox2
            // 
            customPictureBox2.boderGradientBottom1 = Color.SlateBlue;
            customPictureBox2.boderGradientTop1 = Color.MediumSlateBlue;
            customPictureBox2.boderRadius1 = 40;
            customPictureBox2.boderSize1 = 2;
            customPictureBox2.gradientAngle1 = 90F;
            customPictureBox2.Location = new Point(7, 31);
            customPictureBox2.Name = "customPictureBox2";
            customPictureBox2.Size = new Size(101, 84);
            customPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox2.TabIndex = 4;
            customPictureBox2.TabStop = false;
            // 
            // FormProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(466, 657);
            Controls.Add(panel_Avatar);
            Controls.Add(label3);
            Controls.Add(exit);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(customPictureBox1);
            Controls.Add(customPanel2);
            Controls.Add(label1);
            Controls.Add(customPanel1);
            Name = "FormProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormProfile";
            Load += FormProfile_Load;
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)exit).EndInit();
            panel_Avatar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)customPictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)customPictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private libraries.CustomControls.CustomPanel customPanel1;
        private Label label1;
        private libraries.CustomControls.CustomPanel customPanel2;
        private libraries.CustomControls.CustomPictureBox customPictureBox1;
        private Label label2;
        private TextBox textBox1;
        private libraries.CustomControls.CustomPictureBox exit;
        private Label label3;
        private Panel panel_Avatar;
        private libraries.CustomControls.CustomPictureBox customPictureBox9;
        private libraries.CustomControls.CustomPictureBox customPictureBox5;
        private libraries.CustomControls.CustomPictureBox customPictureBox8;
        private libraries.CustomControls.CustomPictureBox customPictureBox7;
        private libraries.CustomControls.CustomPictureBox customPictureBox4;
        private libraries.CustomControls.CustomPictureBox customPictureBox6;
        private libraries.CustomControls.CustomPictureBox customPictureBox3;
        private libraries.CustomControls.CustomPictureBox customPictureBox2;
    }
}