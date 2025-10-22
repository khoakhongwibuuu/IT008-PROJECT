using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SinglePlayer
{
    public partial class fSinglePlayer : Form
    {
        private int wordLength;
        private const int guessCount = 6;
        private TableLayoutPanel? tableLayout;
        public fSinglePlayer(int wordLength)
        {
            InitializeComponent();
            this.wordLength = wordLength;
        }
        private void fSinglePlayer_Load(object sender, EventArgs e)
        {
            SetupLayout();
            CreateBoard();
            this.Resize += (s, e) =>
            {
                Panel? panelBoard = this.Tag as Panel;
                if (panelBoard == null) {
                    return;
                }
                CenterBoard(panelBoard);
            };
        }
        private void SetupLayout()
        {
            Panel panelBoard = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.DimGray,
            };
            this.Tag = panelBoard;
            this.Controls.Add(panelBoard);  
        }
        private void CreateBoard()
        {
            Panel? panelBoard = this.Tag as Panel;
            if (panelBoard == null)
            {
                return;
            }
            tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.None,
                AutoSize = true,
                BackColor = Color.Transparent,
                RowCount = guessCount,
                ColumnCount = wordLength,
                Padding = new Padding(10)
            };
            for (int i = 0; i < guessCount; i++) {
                tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            for (int i = 0; i < wordLength; i++) { 
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); 
            }
            for (int i = 0; i < guessCount; i++)
            {
                for (int j = 0; j < wordLength; j++)
                {
                    Label wordGuess = new Label
                    {
                        Text = "",
                        Width = 100,
                        Height = 100,
                        Margin = new Padding(6),
                        BorderStyle = BorderStyle.FixedSingle,
                        Font = new Font("Segoe UI", 22, FontStyle.Bold),
                        BackColor = Color.LightGray,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Name = $"cell[{i},{j}]"
                    };
                    tableLayout.Controls.Add(wordGuess);
                }
            }
            panelBoard.Controls.Add(tableLayout);
            CenterBoard(panelBoard);
        }
        private void CenterBoard(Panel panelBoard)
        {
            if (tableLayout == null)
            {
                return;
            }
            int tableLayout_x = (panelBoard.Width - tableLayout.Width) / 2;
            int tableLayout_y = (panelBoard.Height - tableLayout.Height) / 2;
            tableLayout.Location = new Point(tableLayout_x, tableLayout_y);
        }
    }
}
