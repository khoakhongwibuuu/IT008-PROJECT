namespace WordleClient.views
{
    partial class fSever
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
            dgv_Sever = new DataGridView();
            txt_SeverName = new TextBox();
            btn_CreateRoom = new WordleClient.libraries.CustomControls.CustomButton();
            customPanel1 = new WordleClient.libraries.CustomControls.CustomPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Sever).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(dgv_Sever);
            panel1.Controls.Add(txt_SeverName);
            panel1.Controls.Add(btn_CreateRoom);
            panel1.Controls.Add(customPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(912, 551);
            panel1.TabIndex = 0;
            // 
            // dgv_Sever
            // 
            dgv_Sever.BackgroundColor = Color.White;
            dgv_Sever.BorderStyle = BorderStyle.Fixed3D;
            dgv_Sever.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Sever.Location = new Point(12, 98);
            dgv_Sever.Name = "dgv_Sever";
            dgv_Sever.RowHeadersWidth = 51;
            dgv_Sever.Size = new Size(886, 439);
            dgv_Sever.TabIndex = 7;
            // 
            // txt_SeverName
            // 
            txt_SeverName.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_SeverName.Location = new Point(84, 31);
            txt_SeverName.Name = "txt_SeverName";
            txt_SeverName.PlaceholderText = "Tên Sever";
            txt_SeverName.Size = new Size(404, 41);
            txt_SeverName.TabIndex = 5;
            // 
            // btn_CreateRoom
            // 
            btn_CreateRoom.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_CreateRoom.BorderColor = Color.FromArgb(153, 214, 214);
            btn_CreateRoom.BorderRadius = 10;
            btn_CreateRoom.BorderSize = 2;
            btn_CreateRoom.ButtonImage = null;
            btn_CreateRoom.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btn_CreateRoom.ImageSize = 24;
            btn_CreateRoom.Location = new Point(674, 15);
            btn_CreateRoom.Name = "btn_CreateRoom";
            btn_CreateRoom.Size = new Size(213, 65);
            btn_CreateRoom.TabIndex = 4;
            btn_CreateRoom.Text = "Tạo Phòng";
            btn_CreateRoom.TextAlign = ContentAlignment.MiddleCenter;
            btn_CreateRoom.TextColor = Color.White;
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderRadius = 30;
            customPanel1.Dock = DockStyle.Fill;
            customPanel1.ForeColor = Color.Black;
            customPanel1.GradientAngle = 90F;
            customPanel1.GradientBottomColor = Color.FromArgb(192, 192, 255);
            customPanel1.GradientTopColor = Color.FromArgb(128, 128, 255);
            customPanel1.Location = new Point(0, 0);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(908, 547);
            customPanel1.TabIndex = 6;
            // 
            // fSever
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 551);
            Controls.Add(panel1);
            Name = "fSever";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sever";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Sever).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgv_Sever;
        private TextBox txt_SeverName;
        private libraries.CustomControls.CustomButton btn_CreateRoom;
        private libraries.CustomControls.CustomPanel customPanel1;
    }
}