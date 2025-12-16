namespace WordleClient.views
{
    partial class Statistic
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 79);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Total game plays";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 94);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 1;
            label2.Text = "Total game wins";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(87, 109);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 2;
            label3.Text = "Current streak";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(87, 124);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 3;
            label4.Text = "Max streak";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(87, 139);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 7;
            label5.Text = "Win rate";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(87, 154);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 6;
            label6.Text = "Average attempts";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(288, 79);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 5;
            label7.Text = "label7";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(288, 94);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 4;
            label8.Text = "label8";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(288, 109);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 11;
            label9.Text = "label9";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(288, 124);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 10;
            label10.Text = "label10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(288, 139);
            label11.Name = "label11";
            label11.Size = new Size(44, 15);
            label11.TabIndex = 9;
            label11.Text = "label11";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(288, 154);
            label12.Name = "label12";
            label12.Size = new Size(44, 15);
            label12.TabIndex = 8;
            label12.Text = "label12";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(87, 203);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(283, 23);
            comboBox1.TabIndex = 12;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Statistic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Statistic";
            Text = "Statistic";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private ComboBox comboBox1;
    }
}