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
            lbl_Streak = new Label();
            label6 = new Label();
            lbl_Hint2_Placeholder = new Label();
            label7 = new Label();
            lbl_Hint1_Placeholder = new Label();
            label5 = new Label();
            lbl_Tpc = new Label();
            lbl_HintRemaining = new Label();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            lbl_Diff = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            MasterPanel = new Panel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            MasterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // customButton1
            // 
            customButton1.BackgroundColor = Color.FromArgb(122, 178, 211);
            customButton1.BorderColor = Color.FromArgb(122, 178, 211);
            customButton1.BorderRadius = 20;
            customButton1.BorderSize = 2;
            customButton1.ButtonImage = null;
            customButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton1.ImageSize = 24;
            customButton1.Location = new Point(7, 936);
            customButton1.Margin = new Padding(3, 4, 3, 4);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(322, 60);
            customButton1.TabIndex = 0;
            customButton1.Text = "💡 Get Hint";
            customButton1.TextAlign = ContentAlignment.MiddleCenter;
            customButton1.TextColor = Color.White;
            customButton1.Click += GetHintBtn_Click;
            // 
            // customButton2
            // 
            customButton2.BackgroundColor = Color.FromArgb(255, 116, 108);
            customButton2.BorderColor = Color.FromArgb(255, 116, 108);
            customButton2.BorderRadius = 20;
            customButton2.BorderSize = 2;
            customButton2.ButtonImage = null;
            customButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton2.ImageSize = 24;
            customButton2.Location = new Point(7, 1004);
            customButton2.Margin = new Padding(3, 4, 3, 4);
            customButton2.Name = "customButton2";
            customButton2.Size = new Size(322, 60);
            customButton2.TabIndex = 0;
            customButton2.Text = "❌ Exit game";
            customButton2.TextAlign = ContentAlignment.MiddleCenter;
            customButton2.TextColor = Color.White;
            customButton2.Click += ExitBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbl_Streak);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lbl_Hint2_Placeholder);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(lbl_Hint1_Placeholder);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lbl_Tpc);
            panel1.Controls.Add(lbl_HintRemaining);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lbl_Diff);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(343, 1080);
            panel1.TabIndex = 2;
            // 
            // lbl_Streak
            // 
            lbl_Streak.AutoSize = true;
            lbl_Streak.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Streak.Location = new Point(94, 843);
            lbl_Streak.Margin = new Padding(1, 0, 1, 0);
            lbl_Streak.Name = "lbl_Streak";
            lbl_Streak.Size = new Size(24, 28);
            lbl_Streak.TabIndex = 15;
            lbl_Streak.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(14, 843);
            label6.Margin = new Padding(1, 0, 1, 0);
            label6.Name = "label6";
            label6.Size = new Size(78, 28);
            label6.TabIndex = 14;
            label6.Text = "Streak:";
            // 
            // lbl_Hint2_Placeholder
            // 
            lbl_Hint2_Placeholder.AutoSize = true;
            lbl_Hint2_Placeholder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Hint2_Placeholder.Location = new Point(14, 1032);
            lbl_Hint2_Placeholder.Name = "lbl_Hint2_Placeholder";
            lbl_Hint2_Placeholder.Size = new Size(101, 28);
            lbl_Hint2_Placeholder.TabIndex = 13;
            lbl_Hint2_Placeholder.Text = "Unknown";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(14, 1004);
            label7.Name = "label7";
            label7.Size = new Size(76, 28);
            label7.TabIndex = 12;
            label7.Text = "Hint 2:";
            // 
            // lbl_Hint1_Placeholder
            // 
            lbl_Hint1_Placeholder.AutoSize = true;
            lbl_Hint1_Placeholder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Hint1_Placeholder.Location = new Point(14, 964);
            lbl_Hint1_Placeholder.Name = "lbl_Hint1_Placeholder";
            lbl_Hint1_Placeholder.Size = new Size(101, 28);
            lbl_Hint1_Placeholder.TabIndex = 11;
            lbl_Hint1_Placeholder.Text = "Unknown";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(14, 936);
            label5.Name = "label5";
            label5.Size = new Size(76, 28);
            label5.TabIndex = 10;
            label5.Text = "Hint 1:";
            // 
            // lbl_Tpc
            // 
            lbl_Tpc.AutoSize = true;
            lbl_Tpc.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Tpc.Location = new Point(79, 27);
            lbl_Tpc.Margin = new Padding(1, 0, 1, 0);
            lbl_Tpc.Name = "lbl_Tpc";
            lbl_Tpc.Size = new Size(101, 28);
            lbl_Tpc.TabIndex = 5;
            lbl_Tpc.Text = "Unknown";
            // 
            // lbl_HintRemaining
            // 
            lbl_HintRemaining.AutoSize = true;
            lbl_HintRemaining.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_HintRemaining.Location = new Point(170, 885);
            lbl_HintRemaining.Name = "lbl_HintRemaining";
            lbl_HintRemaining.Size = new Size(24, 28);
            lbl_HintRemaining.TabIndex = 9;
            lbl_HintRemaining.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(14, 885);
            label2.Name = "label2";
            label2.Size = new Size(175, 28);
            label2.TabIndex = 8;
            label2.Text = "Hints remaining: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(21, 27);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 28);
            label3.TabIndex = 4;
            label3.Text = "Topic: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(21, 63);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 28);
            label1.TabIndex = 2;
            label1.Text = "CEFR Level:";
            // 
            // lbl_Diff
            // 
            lbl_Diff.AutoSize = true;
            lbl_Diff.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Diff.Location = new Point(141, 63);
            lbl_Diff.Margin = new Padding(1, 0, 1, 0);
            lbl_Diff.Name = "lbl_Diff";
            lbl_Diff.Size = new Size(101, 28);
            lbl_Diff.TabIndex = 3;
            lbl_Diff.Text = "Unknown";
            // 
            // panel2
            // 
            panel2.Location = new Point(343, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(549, 1080);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(customButton2);
            panel3.Controls.Add(customButton1);
            panel3.Location = new Point(891, 0);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(343, 1080);
            panel3.TabIndex = 2;
            // 
            // MasterPanel
            // 
            MasterPanel.Controls.Add(panel1);
            MasterPanel.Controls.Add(panel2);
            MasterPanel.Controls.Add(panel3);
            MasterPanel.Location = new Point(0, 0);
            MasterPanel.Margin = new Padding(3, 4, 3, 4);
            MasterPanel.Name = "MasterPanel";
            MasterPanel.Size = new Size(1234, 1080);
            MasterPanel.TabIndex = 0;
            // 
            // Playground
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1232, 1069);
            Controls.Add(MasterPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(1250, 1116);
            MinimumSize = new Size(1250, 1116);
            Name = "Playground";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Playground";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
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
        private Label label5;
        private Label lbl_Hint2_Placeholder;
        private Label label7;
        private Label lbl_Streak;
        private Label label6;
    }
}
