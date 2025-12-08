namespace WordleClient.views
{
    partial class fClient
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
            dgv_Client = new DataGridView();
            textBox1 = new TextBox();
            txt_SeverName = new TextBox();
            btn_JoinRoom = new WordleClient.libraries.CustomControls.CustomButton();
            btn_SeenInfo = new WordleClient.libraries.CustomControls.CustomButton();
            customPanel1 = new WordleClient.libraries.CustomControls.CustomPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Client).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(dgv_Client);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(txt_SeverName);
            panel1.Controls.Add(btn_JoinRoom);
            panel1.Controls.Add(btn_SeenInfo);
            panel1.Controls.Add(customPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(912, 551);
            panel1.TabIndex = 0;
            // 
            // dgv_Client
            // 
            dgv_Client.BackgroundColor = Color.White;
            dgv_Client.BorderStyle = BorderStyle.Fixed3D;
            dgv_Client.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Client.Location = new Point(12, 153);
            dgv_Client.Name = "dgv_Client";
            dgv_Client.RowHeadersWidth = 51;
            dgv_Client.Size = new Size(886, 384);
            dgv_Client.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(82, 94);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên Client";
            textBox1.Size = new Size(395, 41);
            textBox1.TabIndex = 10;
            // 
            // txt_SeverName
            // 
            txt_SeverName.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_SeverName.Location = new Point(82, 23);
            txt_SeverName.Name = "txt_SeverName";
            txt_SeverName.PlaceholderText = "Nhập IP Sever";
            txt_SeverName.Size = new Size(395, 41);
            txt_SeverName.TabIndex = 11;
            // 
            // btn_JoinRoom
            // 
            btn_JoinRoom.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_JoinRoom.BorderColor = Color.FromArgb(153, 214, 214);
            btn_JoinRoom.BorderRadius = 10;
            btn_JoinRoom.BorderSize = 2;
            btn_JoinRoom.ButtonImage = null;
            btn_JoinRoom.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btn_JoinRoom.ImageSize = 24;
            btn_JoinRoom.Location = new Point(641, 80);
            btn_JoinRoom.Name = "btn_JoinRoom";
            btn_JoinRoom.Size = new Size(213, 58);
            btn_JoinRoom.TabIndex = 8;
            btn_JoinRoom.Text = "Xin phép vào";
            btn_JoinRoom.TextAlign = ContentAlignment.MiddleCenter;
            btn_JoinRoom.TextColor = Color.White;
            // 
            // btn_SeenInfo
            // 
            btn_SeenInfo.BackgroundColor = Color.FromArgb(153, 214, 214);
            btn_SeenInfo.BorderColor = Color.FromArgb(153, 214, 214);
            btn_SeenInfo.BorderRadius = 10;
            btn_SeenInfo.BorderSize = 2;
            btn_SeenInfo.ButtonImage = null;
            btn_SeenInfo.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            btn_SeenInfo.ImageSize = 24;
            btn_SeenInfo.Location = new Point(643, 12);
            btn_SeenInfo.Name = "btn_SeenInfo";
            btn_SeenInfo.Size = new Size(213, 58);
            btn_SeenInfo.TabIndex = 9;
            btn_SeenInfo.Text = "Xem thông tin";
            btn_SeenInfo.TextAlign = ContentAlignment.MiddleCenter;
            btn_SeenInfo.TextColor = Color.White;
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
            customPanel1.TabIndex = 12;
            // 
            // fClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 551);
            Controls.Add(panel1);
            Name = "fClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Client).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgv_Client;
        private TextBox textBox1;
        private TextBox txt_SeverName;
        private libraries.CustomControls.CustomButton btn_JoinRoom;
        private libraries.CustomControls.CustomButton btn_SeenInfo;
        private libraries.CustomControls.CustomPanel customPanel1;
    }
}