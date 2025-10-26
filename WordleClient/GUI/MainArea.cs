using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordleClient.GUI
{
    public partial class MainArea : Form
    {
        private int wordLength;
        private int guessCount;
        private TableLayoutPanel? tableLayout;
        public MainArea(int wordLength, int guessCount)
        {
            InitializeComponent();
            this.wordLength = wordLength;
            this.guessCount = guessCount;
            this.WindowState = FormWindowState.Maximized;
         }

        private void MainArea_Load(object sender, EventArgs e)
        {
            SetupBoard();
            CreateBoard();
            this.Resize += (s, e) =>
            {
                Panel? panelBoard = this.Tag as Panel;
                if (panelBoard == null)
                {
                    return;
                }
                CenterBoard(panelBoard);
            };
        }
        private void SetupBoard()
        {
            Panel panelTable = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.DimGray,
            };
            this.Tag= panelTable;
            this.Controls.Add(panelTable);
        }
        private void CreateBoard()
        {
            Panel? panelTable = this.Tag as Panel;
            if (panelTable == null) return; 
            tableLayout = new TableLayoutPanel
            {               
                RowCount = guessCount,
                ColumnCount = wordLength,
                AutoSize = true,
                Dock = DockStyle.None,
                BackColor = Color.Transparent,
                Padding = new Padding(10),
            };
            for(int i=0; i< guessCount; i++)
            {
                tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            for(int i=0;i< wordLength; i++)
            {
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
            panelTable.Controls.Add(tableLayout);
            CenterBoard(panelTable);

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
