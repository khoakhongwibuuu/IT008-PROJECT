using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WordleClient.CuttomControls
{
    [DefaultEvent("SelectedIndexChanged")]
    public class CustomComboBox : UserControl
    {
        // Fields;
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color boderColor = Color.MediumSlateBlue;
        private int boderSize = 1;
        // item;
        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;

        public Color BackColor1
        {
            get
            {
                return backColor;
            }
            set
            {
                cmbList.BackColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            }
        }
        public Color IconColor
        {   
            get
            {
                return iconColor;
            }
            set
            {
                iconColor = value;
                btnIcon.Invalidate();
            }
        }
        public Color ListBackColor
        {
            get
            {
                return listBackColor;
            }
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }
        public Color ListTextColor
        {
            get
            {
                return listTextColor;
            }
            set
            {
                listBackColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }
        public Color BoderColor
        {
            get
            {
                return boderColor;
            }
            set
            {
                boderColor = value;
                base.BackColor = boderColor;
            }
        }
        public int BoderSize
        {
            get
            {
                return boderSize;
            }
            set
            {
                boderSize = value;
                this.Padding = new Padding(boderSize);
            }
        }

        // Events
        public event EventHandler? OnSelectedIndexChanged;
        // Constructor
        public CustomComboBox()
        {
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            this.SuspendLayout();
            // ComboBox
            cmbList.BackColor = listBackColor;
            cmbList.Font = new Font(this.Font.Name, 10F);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);
            // Label: Text
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Font = new Font(this.Font.Name, 10F);
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Click += new EventHandler(Surface_Click);
            // Button: Icon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);
            // CustomComboBox
            this.Controls.Add(cmbList);
            this.Controls.Add(lblText);
            this.Controls.Add(btnIcon);
            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.Padding = new Padding(boderSize);
            this.ForeColor = Color.DimGray;
            base.BackColor = boderColor;
            this.ResumeLayout();
        }

        private void Icon_Paint(object? sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Surface_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Icon_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ComboBox_TextChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CmbList_TextChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
