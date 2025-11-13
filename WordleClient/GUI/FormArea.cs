using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WordleClient.StateFrom;
namespace WordleClient.GUI
{
    public partial class FormArea : Form
    {
        string targetWord = "";
        string currentInput = "";
        int currentRow = 0;
        int maxRows; //Lấy từ FormOption
        int wordlength;// lấy từ FormOption
        int score = 0;
        int seconds = 0;
        TableLayoutPanel? TablePlay;
        Label? lblScore;
        Label? lblTimer;
        Label? lblSetting;
        PictureBox? picHint;
        System.Windows.Forms.Timer? gameTimer;
        public FormArea(int cntGuess,int wordlength)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.maxRows = cntGuess;
            this.wordlength = wordlength;
            this.KeyDown += FormArea_KeyDown;
        }
        private void FormArea_Load(object? sender, EventArgs e)
        {
            targetWord = "";
            currentInput = "";
            currentRow = 0;
            seconds = 0;
            lblTimer.Text = "⏱ 0s";
            CreateBoard(wordlength);
            CenterBoard();
            gameTimer.Start();
        }
        private void CreateBoard(int cols)
        {
            if (TablePlay == null) {
                return;
            }
            TablePlay.Controls.Clear();
            TablePlay.ColumnCount = cols;
            TablePlay.RowCount = maxRows;
            TablePlay.ColumnStyles.Clear();
            TablePlay.RowStyles.Clear();
            for (int i = 0; i < cols; i++)
            {
                TablePlay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));

            }
            for (int r = 0; r < maxRows; r++)
            {
                TablePlay.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / maxRows));

            }
            for (int r = 0; r < maxRows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Label lbl = new Label();
                    lbl.Text = "-";
                    lbl.Dock = DockStyle.Fill;
                    lbl.Font = new Font("Segoe UI", 36, FontStyle.Bold); 
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.BackColor = Color.White;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    TablePlay.Controls.Add(lbl, c, r);
                }
            }
        }
        private void FormArea_KeyDown(object? sender, KeyEventArgs e)
        {
            if (currentRow >= maxRows) return;
            int maxLength = wordlength;
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                if (currentInput.Length < maxLength)
                {
                    currentInput += e.KeyCode.ToString();
                    UpdateRowDisplay();
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (currentInput.Length > 0)
                {
                    currentInput = currentInput.Substring(0, currentInput.Length - 1);
                    UpdateRowDisplay();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (currentInput.Length == maxLength)
                {
                    CheckWord();
                }
            }
        }
        private void CheckWord()
        {
            MessageBox.Show("Xử lý word ở đây!");
        }
        private void UpdateRowDisplay()
        {
            for (int i = 0; i < wordlength; i++)
            {             
                Label lbl = (Label)TablePlay.GetControlFromPosition(i, currentRow);
                lbl.Text = i < currentInput.Length ? currentInput[i].ToString() : "-";
            }
        }
        private void gameTimer_Tick(object? sender, EventArgs e)
        {
            if(lblTimer == null)
            {
                return;
            }
            seconds++;
            lblTimer.Text = $"⏱ {seconds}s";
        }
        private void InitializeComponent()
        {
            this.Text = "🎯Wordle Game";
            this.BackColor = Color.WhiteSmoke;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ClientSize = new Size(950, 1000);
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += gameTimer_Tick;
            // Score
            lblScore = new Label();
            lblScore.Text = "⭐ Score: 0";
            lblScore.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblScore.ForeColor = Color.DarkGreen;
            lblScore.Location = new Point(80, 40);
            lblScore.AutoSize = true;
            this.Controls.Add(lblScore);
            // Timer
            lblTimer = new Label();
            lblTimer.Text = "⏱ 0s";
            lblTimer.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTimer.ForeColor = Color.DarkBlue;
            lblTimer.Location = new Point(400, 40);
            lblTimer.AutoSize = true;
            this.Controls.Add(lblTimer);
            // Hint
            picHint = new PictureBox();
            picHint.Image = Properties.Resources.Hint;
            picHint.SizeMode = PictureBoxSizeMode.Zoom;
            picHint.Size = new Size(60, 60);
            picHint.Location = new Point(650, 35);
            picHint.Cursor = Cursors.Hand;
            picHint.Click += PicHint_Click;
            this.Controls.Add(picHint);
            //Setting
            PictureBox picSetting = new PictureBox();
            picSetting.Image = Properties.Resources.user_setting; 
            picSetting.SizeMode = PictureBoxSizeMode.Zoom;
            picSetting.Size = new Size(60, 60); // bằng Hint
            picSetting.Location = new Point(picHint.Right + 100, picHint.Top); 
            picSetting.Cursor = Cursors.Hand;
            picSetting.Click += PicSetting_Click;
            this.Controls.Add(picSetting);
            // Table Play
            TablePlay = new TableLayoutPanel();
            TablePlay.BackColor = Color.White;
            TablePlay.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TablePlay.Size = new Size(700, 750);
            TablePlay.Location = new Point((this.ClientSize.Width - TablePlay.Width) / 2, 150);
            this.Controls.Add(TablePlay);
            this.Load += FormArea_Load;
        }

        private void PicSetting_Click(object? sender, EventArgs e)
        {
            CustomSound.PlayClick();
            FormSetting settingForm = new FormSetting();
            settingForm.ShowDialog();
        }

        private void PicHint_Click(object? sender, EventArgs e)
        {
            CustomSound.PlayClick();
        }
        private void CenterBoard()
        {
            if(TablePlay == null)
            {
                return;
            }
            TablePlay.Location = new Point(
                (this.ClientSize.Width - TablePlay.Width) / 2,
                (this.ClientSize.Height - TablePlay.Height) / 2 + 20
            );
        }
    }
}
