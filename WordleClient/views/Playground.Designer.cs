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
            customButton1 = new WordleClient.libraries.CustomControls.CustomButton();
            customButton2 = new WordleClient.libraries.CustomControls.CustomButton();
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
            customButton1.Location = new Point(12, 58);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(150, 40);
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
            customButton2.Location = new Point(12, 12);
            customButton2.Name = "customButton2";
            customButton2.Size = new Size(150, 40);
            customButton2.TabIndex = 1;
            customButton2.Text = "❌ Exit game";
            customButton2.TextAlign = ContentAlignment.MiddleCenter;
            customButton2.TextColor = Color.White;
            customButton2.Click += ExitBtn_Click;
            // 
            // Playground
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 680);
            Controls.Add(customButton2);
            Controls.Add(customButton1);
            Name = "Playground";
            Text = "Playground";
            ResumeLayout(false);
        }

        #endregion

        private libraries.CustomControls.CustomButton customButton1;
        private libraries.CustomControls.CustomButton customButton2;
    }
}
