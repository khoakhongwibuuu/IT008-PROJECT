namespace WordleClient.views
{
    partial class Playground
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Playground));
            customButton1 = new WordleClient.libraries.CustomControls.CustomButton();
            customButton2 = new WordleClient.libraries.CustomControls.CustomButton();
            panel1 = new Panel();
            playerInfo = new WordleClient.libraries.CustomControls.CustomGroupBox();
            customPictureBox1 = new WordleClient.libraries.CustomControls.CustomPictureBox();
            label8 = new Label();
            flp_Hearts = new FlowLayoutPanel();
            revealedHints = new WordleClient.libraries.CustomControls.CustomGroupBox();
            label5 = new Label();
            lbl_Hint1_Placeholder = new Label();
            label7 = new Label();
            lbl_Hint2_Placeholder = new Label();
            gameStats = new WordleClient.libraries.CustomControls.CustomGroupBox();
            label6 = new Label();
            lbl_Streak = new Label();
            label2 = new Label();
            lbl_HintRemaining = new Label();
            lbl_Tpc = new Label();
            lbl_Diff = new Label();
            label3 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            customButton3 = new WordleClient.libraries.CustomControls.CustomButton();
            customButton4 = new WordleClient.libraries.CustomControls.CustomButton();
            btn_DarkLight = new WordleClient.libraries.CustomControls.CustomPictureBox();
            MasterPanel = new Panel();
            panel1.SuspendLayout();
            playerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).BeginInit();
            revealedHints.SuspendLayout();
            gameStats.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_DarkLight).BeginInit();
            MasterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // customButton1
            // 
            customButton1.BackColor = Color.White;
            customButton1.BackgroundColor = Color.White;
            customButton1.BorderColor = Color.Black;
            customButton1.BorderRadius = 20;
            customButton1.BorderSize = 2;
            customButton1.ButtonImage = null;
            customButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton1.ImageSize = 24;
            customButton1.Location = new Point(6, 651);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(282, 45);
            customButton1.TabIndex = 0;
            customButton1.Text = "💡 Get Hint";
            customButton1.TextAlign = ContentAlignment.MiddleCenter;
            customButton1.TextColor = Color.Black;
            customButton1.Click += GetHintBtn_Click;
            // 
            // customButton2
            // 
            customButton2.BackColor = Color.White;
            customButton2.BackgroundColor = Color.White;
            customButton2.BorderColor = Color.Black;
            customButton2.BorderRadius = 20;
            customButton2.BorderSize = 2;
            customButton2.ButtonImage = null;
            customButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton2.ImageSize = 24;
            customButton2.Location = new Point(6, 753);
            customButton2.Name = "customButton2";
            customButton2.Size = new Size(282, 45);
            customButton2.TabIndex = 0;
            customButton2.Text = "❌ Exit game";
            customButton2.TextAlign = ContentAlignment.MiddleCenter;
            customButton2.TextColor = Color.Black;
            customButton2.Click += ExitBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(playerInfo);
            panel1.Controls.Add(revealedHints);
            panel1.Controls.Add(gameStats);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 810);
            panel1.TabIndex = 2;
            // 
            // playerInfo
            // 
            playerInfo.BackColor = Color.Transparent;
            playerInfo.BackgroundColor = Color.White;
            playerInfo.BorderColor = Color.Black;
            playerInfo.BorderRadius = 15;
            playerInfo.BorderSize = 2;
            playerInfo.Controls.Add(customPictureBox1);
            playerInfo.Controls.Add(label8);
            playerInfo.Controls.Add(flp_Hearts);
            playerInfo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playerInfo.Location = new Point(3, 12);
            playerInfo.Name = "playerInfo";
            playerInfo.Size = new Size(294, 130);
            playerInfo.TabIndex = 20;
            playerInfo.TabStop = false;
            playerInfo.Text = "Player info";
            playerInfo.TextColor = Color.Black;
            playerInfo.TitleAlign = ContentAlignment.TopLeft;
            playerInfo.TitlePadding = 10;
            // 
            // customPictureBox1
            // 
            customPictureBox1.boderGradientBottom1 = Color.Black;
            customPictureBox1.boderGradientTop1 = Color.Black;
            customPictureBox1.boderRadius1 = 40;
            customPictureBox1.boderSize1 = 2;
            customPictureBox1.gradientAngle1 = 90F;
            customPictureBox1.Location = new Point(23, 50);
            customPictureBox1.Name = "customPictureBox1";
            customPictureBox1.Size = new Size(60, 60);
            customPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            customPictureBox1.TabIndex = 18;
            customPictureBox1.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.ImageAlign = ContentAlignment.BottomCenter;
            label8.Location = new Point(86, 51);
            label8.Margin = new Padding(1, 0, 1, 0);
            label8.Name = "label8";
            label8.Size = new Size(84, 21);
            label8.TabIndex = 17;
            label8.Text = "Unknown";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flp_Hearts
            // 
            flp_Hearts.Location = new Point(86, 75);
            flp_Hearts.Name = "flp_Hearts";
            flp_Hearts.Size = new Size(176, 35);
            flp_Hearts.TabIndex = 17;
            // 
            // revealedHints
            // 
            revealedHints.BackColor = Color.Transparent;
            revealedHints.BackgroundColor = Color.White;
            revealedHints.BorderColor = Color.Black;
            revealedHints.BorderRadius = 15;
            revealedHints.BorderSize = 2;
            revealedHints.Controls.Add(label5);
            revealedHints.Controls.Add(lbl_Hint1_Placeholder);
            revealedHints.Controls.Add(label7);
            revealedHints.Controls.Add(lbl_Hint2_Placeholder);
            revealedHints.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            revealedHints.Location = new Point(3, 648);
            revealedHints.Name = "revealedHints";
            revealedHints.Size = new Size(294, 159);
            revealedHints.TabIndex = 19;
            revealedHints.TabStop = false;
            revealedHints.Text = "Revealed hints";
            revealedHints.TextColor = Color.Black;
            revealedHints.TitleAlign = ContentAlignment.TopLeft;
            revealedHints.TitlePadding = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(9, 50);
            label5.Name = "label5";
            label5.Size = new Size(60, 21);
            label5.TabIndex = 10;
            label5.Text = "Hint 1:";
            // 
            // lbl_Hint1_Placeholder
            // 
            lbl_Hint1_Placeholder.AutoSize = true;
            lbl_Hint1_Placeholder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Hint1_Placeholder.Location = new Point(9, 71);
            lbl_Hint1_Placeholder.Name = "lbl_Hint1_Placeholder";
            lbl_Hint1_Placeholder.Size = new Size(84, 21);
            lbl_Hint1_Placeholder.TabIndex = 11;
            lbl_Hint1_Placeholder.Text = "Unknown";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(9, 101);
            label7.Name = "label7";
            label7.Size = new Size(60, 21);
            label7.TabIndex = 12;
            label7.Text = "Hint 2:";
            // 
            // lbl_Hint2_Placeholder
            // 
            lbl_Hint2_Placeholder.AutoSize = true;
            lbl_Hint2_Placeholder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Hint2_Placeholder.Location = new Point(9, 122);
            lbl_Hint2_Placeholder.Name = "lbl_Hint2_Placeholder";
            lbl_Hint2_Placeholder.Size = new Size(84, 21);
            lbl_Hint2_Placeholder.TabIndex = 13;
            lbl_Hint2_Placeholder.Text = "Unknown";
            // 
            // gameStats
            // 
            gameStats.BackColor = Color.Transparent;
            gameStats.BackgroundColor = Color.White;
            gameStats.BorderColor = Color.Black;
            gameStats.BorderRadius = 15;
            gameStats.BorderSize = 2;
            gameStats.Controls.Add(label6);
            gameStats.Controls.Add(lbl_Streak);
            gameStats.Controls.Add(label2);
            gameStats.Controls.Add(lbl_HintRemaining);
            gameStats.Controls.Add(lbl_Tpc);
            gameStats.Controls.Add(lbl_Diff);
            gameStats.Controls.Add(label3);
            gameStats.Controls.Add(label1);
            gameStats.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameStats.Location = new Point(3, 148);
            gameStats.Name = "gameStats";
            gameStats.Size = new Size(294, 148);
            gameStats.TabIndex = 18;
            gameStats.TabStop = false;
            gameStats.Text = "Game statistics";
            gameStats.TextColor = Color.Black;
            gameStats.TitleAlign = ContentAlignment.TopLeft;
            gameStats.TitlePadding = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(10, 90);
            label6.Name = "label6";
            label6.Size = new Size(63, 21);
            label6.TabIndex = 14;
            label6.Text = "Streak:";
            // 
            // lbl_Streak
            // 
            lbl_Streak.AutoSize = true;
            lbl_Streak.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Streak.Location = new Point(77, 90);
            lbl_Streak.Margin = new Padding(1, 0, 1, 0);
            lbl_Streak.Name = "lbl_Streak";
            lbl_Streak.Size = new Size(19, 21);
            lbl_Streak.TabIndex = 15;
            lbl_Streak.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(10, 111);
            label2.Name = "label2";
            label2.Size = new Size(141, 21);
            label2.TabIndex = 8;
            label2.Text = "Hints remaining: ";
            // 
            // lbl_HintRemaining
            // 
            lbl_HintRemaining.AutoSize = true;
            lbl_HintRemaining.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_HintRemaining.Location = new Point(157, 111);
            lbl_HintRemaining.Name = "lbl_HintRemaining";
            lbl_HintRemaining.Size = new Size(19, 21);
            lbl_HintRemaining.TabIndex = 9;
            lbl_HintRemaining.Text = "0";
            // 
            // lbl_Tpc
            // 
            lbl_Tpc.AutoSize = true;
            lbl_Tpc.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Tpc.Location = new Point(63, 48);
            lbl_Tpc.Margin = new Padding(1, 0, 1, 0);
            lbl_Tpc.Name = "lbl_Tpc";
            lbl_Tpc.Size = new Size(84, 21);
            lbl_Tpc.TabIndex = 5;
            lbl_Tpc.Text = "Unknown";
            // 
            // lbl_Diff
            // 
            lbl_Diff.AutoSize = true;
            lbl_Diff.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Diff.Location = new Point(107, 69);
            lbl_Diff.Margin = new Padding(1, 0, 1, 0);
            lbl_Diff.Name = "lbl_Diff";
            lbl_Diff.Size = new Size(84, 21);
            lbl_Diff.TabIndex = 3;
            lbl_Diff.Text = "Unknown";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(10, 48);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 21);
            label3.TabIndex = 4;
            label3.Text = "Topic: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(10, 69);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 2;
            label1.Text = "CEFR Level:";
            // 
            // panel2
            // 
            panel2.Location = new Point(300, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(480, 810);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(customButton3);
            panel3.Controls.Add(customButton4);
            panel3.Controls.Add(btn_DarkLight);
            panel3.Controls.Add(customButton2);
            panel3.Controls.Add(customButton1);
            panel3.Location = new Point(780, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 810);
            panel3.TabIndex = 2;
            // 
            // customButton3
            // 
            customButton3.BackColor = Color.White;
            customButton3.BackgroundColor = Color.White;
            customButton3.BorderColor = Color.Black;
            customButton3.BorderRadius = 20;
            customButton3.BorderSize = 2;
            customButton3.ButtonImage = null;
            customButton3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton3.ImageSize = 24;
            customButton3.Location = new Point(6, 702);
            customButton3.Name = "customButton3";
            customButton3.Size = new Size(138, 45);
            customButton3.TabIndex = 13;
            customButton3.Text = "← Backspace";
            customButton3.TextAlign = ContentAlignment.MiddleCenter;
            customButton3.TextColor = Color.Black;
            customButton3.Click += customButton3_Click;
            // 
            // customButton4
            // 
            customButton4.BackColor = Color.White;
            customButton4.BackgroundColor = Color.White;
            customButton4.BorderColor = Color.Black;
            customButton4.BorderRadius = 20;
            customButton4.BorderSize = 2;
            customButton4.ButtonImage = null;
            customButton4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton4.ImageSize = 24;
            customButton4.Location = new Point(150, 702);
            customButton4.Name = "customButton4";
            customButton4.Size = new Size(138, 45);
            customButton4.TabIndex = 14;
            customButton4.Text = "↵ Enter";
            customButton4.TextAlign = ContentAlignment.MiddleCenter;
            customButton4.TextColor = Color.Black;
            customButton4.Click += customButton4_Click;
            // 
            // btn_DarkLight
            // 
            btn_DarkLight.boderGradientBottom1 = Color.Gainsboro;
            btn_DarkLight.boderGradientTop1 = SystemColors.ButtonFace;
            btn_DarkLight.boderRadius1 = 40;
            btn_DarkLight.boderSize1 = 2;
            btn_DarkLight.Cursor = Cursors.Hand;
            btn_DarkLight.gradientAngle1 = 90F;
            btn_DarkLight.Image = Properties.Resources.Light;
            btn_DarkLight.Location = new Point(228, 586);
            btn_DarkLight.Margin = new Padding(3, 2, 3, 2);
            btn_DarkLight.Name = "btn_DarkLight";
            btn_DarkLight.Size = new Size(60, 60);
            btn_DarkLight.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_DarkLight.TabIndex = 12;
            btn_DarkLight.TabStop = false;
            btn_DarkLight.Click += btn_DarkLight_Click;
            // 
            // MasterPanel
            // 
            MasterPanel.Controls.Add(panel1);
            MasterPanel.Controls.Add(panel2);
            MasterPanel.Controls.Add(panel3);
            MasterPanel.Location = new Point(0, 0);
            MasterPanel.Name = "MasterPanel";
            MasterPanel.Size = new Size(1080, 810);
            MasterPanel.TabIndex = 0;
            // 
            // Playground
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1080, 810);
            Controls.Add(MasterPanel);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1096, 849);
            MinimumSize = new Size(1096, 849);
            Name = "Playground";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Playground";
            panel1.ResumeLayout(false);
            playerInfo.ResumeLayout(false);
            playerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)customPictureBox1).EndInit();
            revealedHints.ResumeLayout(false);
            revealedHints.PerformLayout();
            gameStats.ResumeLayout(false);
            gameStats.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_DarkLight).EndInit();
            MasterPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private libraries.CustomControls.CustomButton customButton1;
        private libraries.CustomControls.CustomButton customButton2;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel MasterPanel;
        private Label lbl_Tpc;
        private Label label3;
        private Label lbl_Diff;
        private Label label1;
        private Label lbl_HintRemaining;
        private Label label2;
        private Label lbl_Hint1_Placeholder;
        private Label lbl_Hint2_Placeholder;
        private Label label7;
        private Label lbl_Streak;
        private Label label6;
        private Label label8;
        private libraries.CustomControls.CustomPictureBox btn_DarkLight;
        private libraries.CustomControls.CustomGroupBox gameStats;
        private libraries.CustomControls.CustomGroupBox revealedHints;
        private Label label5;
        private libraries.CustomControls.CustomGroupBox playerInfo;
        private FlowLayoutPanel flp_Hearts;
        private libraries.CustomControls.CustomPictureBox customPictureBox1;
        private libraries.CustomControls.CustomButton customButton3;
        private libraries.CustomControls.CustomButton customButton4;
    }
}