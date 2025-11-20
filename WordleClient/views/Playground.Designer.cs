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
            lbl_HintRemaining = new Label();
            label2 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            lbl_Tpc = new Label();
            label3 = new Label();
            lbl_Diff = new Label();
            label1 = new Label();
            MasterPanel = new Panel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            MasterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // customButton1
            // 
            customButton1.BackgroundColor = Color.FromArgb(179, 235, 242);
            customButton1.BorderColor = Color.FromArgb(179, 235, 242);
            customButton1.BorderRadius = 20;
            customButton1.BorderSize = 2;
            customButton1.ButtonImage = null;
            customButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton1.ImageSize = 24;
            customButton1.Location = new Point(21, 82);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(135, 45);
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
            customButton2.Location = new Point(21, 12);
            customButton2.Name = "customButton2";
            customButton2.Size = new Size(135, 45);
            customButton2.TabIndex = 0;
            customButton2.Text = "❌ Exit game";
            customButton2.TextAlign = ContentAlignment.MiddleCenter;
            customButton2.TextColor = Color.White;
            customButton2.Click += ExitBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbl_HintRemaining);
            panel1.Controls.Add(customButton2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(customButton1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 810);
            panel1.TabIndex = 2;
            // 
            // lbl_HintRemaining
            // 
            lbl_HintRemaining.AutoSize = true;
            lbl_HintRemaining.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_HintRemaining.Location = new Point(149, 780);
            lbl_HintRemaining.Name = "lbl_HintRemaining";
            lbl_HintRemaining.Size = new Size(19, 21);
            lbl_HintRemaining.TabIndex = 9;
            lbl_HintRemaining.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(12, 780);
            label2.Name = "label2";
            label2.Size = new Size(141, 21);
            label2.TabIndex = 8;
            label2.Text = "Hints remaining: ";
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
            panel3.Controls.Add(lbl_Tpc);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(lbl_Diff);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(780, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 810);
            panel3.TabIndex = 2;
            // 
            // lbl_Tpc
            // 
            lbl_Tpc.AutoSize = true;
            lbl_Tpc.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Tpc.Location = new Point(91, 9);
            lbl_Tpc.Margin = new Padding(1, 0, 1, 0);
            lbl_Tpc.Name = "lbl_Tpc";
            lbl_Tpc.Size = new Size(84, 21);
            lbl_Tpc.TabIndex = 5;
            lbl_Tpc.Text = "Unknown";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(40, 9);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 21);
            label3.TabIndex = 4;
            label3.Text = "Topic: ";
            // 
            // lbl_Diff
            // 
            lbl_Diff.AutoSize = true;
            lbl_Diff.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_Diff.Location = new Point(137, 36);
            lbl_Diff.Margin = new Padding(1, 0, 1, 0);
            lbl_Diff.Name = "lbl_Diff";
            lbl_Diff.Size = new Size(84, 21);
            lbl_Diff.TabIndex = 3;
            lbl_Diff.Text = "Unknown";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(40, 36);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 2;
            label1.Text = "CEFR Level:";
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
            ClientSize = new Size(1080, 810);
            Controls.Add(MasterPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1096, 849);
            MinimumSize = new Size(1096, 849);
            Name = "Playground";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Playground";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
    }
}
