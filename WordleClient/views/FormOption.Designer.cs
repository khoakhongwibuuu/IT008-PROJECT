using WordleClient.libraries.CustomControl;
namespace WordleClient.views
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
            panel1 = new Panel();
            btn_StartGame = new RenewedButtons();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            trackbar_GuessCount = new TrackBar();
            cbb_Topic = new ComboBox();
            groupBox1 = new GroupBox();
            rad_Random = new RadioButton();
            rad_Hard = new RadioButton();
            rad_Easy = new RadioButton();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackbar_GuessCount).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(btn_StartGame);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(743, 750);
            panel1.TabIndex = 0;
            // 
            // btn_StartGame
            // 
            btn_StartGame.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_StartGame.BorderColor = Color.FromArgb(153, 214, 214);
            btn_StartGame.BorderRadius = 20;
            btn_StartGame.BorderSize = 2;
            btn_StartGame.ButtonImage = null;
            btn_StartGame.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_StartGame.ImageSize = 24;
            btn_StartGame.Location = new Point(208, 644);
            btn_StartGame.Name = "btn_StartGame";
            btn_StartGame.Size = new Size(365, 75);
            btn_StartGame.TabIndex = 2;
            btn_StartGame.Text = "StartGame";
            btn_StartGame.TextAlign = ContentAlignment.MiddleCenter;
            btn_StartGame.TextColor = Color.White;
            btn_StartGame.Click += btn_StartGame_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(trackbar_GuessCount);
            groupBox2.Controls.Add(cbb_Topic);
            groupBox2.Font = new Font("Segoe UI", 12F);
            groupBox2.Location = new Point(208, 342);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(365, 278);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chọn Topic and Số lượt đoán";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 214);
            label3.Name = "label3";
            label3.Size = new Size(23, 28);
            label3.TabIndex = 2;
            label3.Text = "8";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 214);
            label2.Name = "label2";
            label2.Size = new Size(23, 28);
            label2.TabIndex = 2;
            label2.Text = "7";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 214);
            label1.Name = "label1";
            label1.Size = new Size(23, 28);
            label1.TabIndex = 2;
            label1.Text = "6";
            // 
            // trackbar_GuessCount
            // 
            trackbar_GuessCount.Location = new Point(40, 176);
            trackbar_GuessCount.Maximum = 8;
            trackbar_GuessCount.Minimum = 6;
            trackbar_GuessCount.Name = "trackbar_GuessCount";
            trackbar_GuessCount.Size = new Size(296, 56);
            trackbar_GuessCount.TabIndex = 1;
            trackbar_GuessCount.Value = 6;
            // 
            // cbb_Topic
            // 
            cbb_Topic.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbb_Topic.FormattingEnabled = true;
            cbb_Topic.Location = new Point(49, 70);
            cbb_Topic.Name = "cbb_Topic";
            cbb_Topic.Size = new Size(287, 39);
            cbb_Topic.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rad_Random);
            groupBox1.Controls.Add(rad_Hard);
            groupBox1.Controls.Add(rad_Easy);
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(208, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(365, 291);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chọn LEVEL";
            // 
            // rad_Random
            // 
            rad_Random.AutoSize = true;
            rad_Random.Location = new Point(49, 218);
            rad_Random.Name = "rad_Random";
            rad_Random.Size = new Size(107, 32);
            rad_Random.TabIndex = 2;
            rad_Random.TabStop = true;
            rad_Random.Text = "Random";
            rad_Random.UseVisualStyleBackColor = true;
            // 
            // rad_Hard
            // 
            rad_Hard.AutoSize = true;
            rad_Hard.Location = new Point(49, 147);
            rad_Hard.Name = "rad_Hard";
            rad_Hard.Size = new Size(76, 32);
            rad_Hard.TabIndex = 1;
            rad_Hard.TabStop = true;
            rad_Hard.Text = "Hard";
            rad_Hard.UseVisualStyleBackColor = true;
            // 
            // rad_Easy
            // 
            rad_Easy.AutoSize = true;
            rad_Easy.Location = new Point(49, 75);
            rad_Easy.Name = "rad_Easy";
            rad_Easy.Size = new Size(71, 32);
            rad_Easy.TabIndex = 0;
            rad_Easy.TabStop = true;
            rad_Easy.Text = "Easy";
            rad_Easy.UseVisualStyleBackColor = true;
            // 
            // FormOption
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 750);
            Controls.Add(panel1);
            Name = "FormOption";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormOption";
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackbar_GuessCount).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private RenewedButtons btn_StartGame;
        private GroupBox groupBox2;
        private TrackBar trackbar_GuessCount;
        private ComboBox cbb_Topic;
        private GroupBox groupBox1;
        private RadioButton rad_Random;
        private RadioButton rad_Hard;
        private RadioButton rad_Easy;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}