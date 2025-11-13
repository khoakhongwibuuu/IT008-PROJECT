using System;
using System.Drawing;
using System.Windows.Forms;
using WordleClient.libraries.ingame;

namespace WordleClient.views
{
    public partial class MatrixDemo : Form
    {
        private int rows;
        private int cols;
        private Panel matrixPanel;
        private const int boxSize = 45;
        private const int spacing = 5;

        public MatrixDemo(int m, int n)
        {
            rows = m;
            cols = n;

            InitializeComponent();
            InitializeMatrixPanel();
            CreateMatrix();
            CenterMatrix();

            this.Resize += (s, e) => CenterMatrix();
        }

        private void InitializeMatrixPanel()
        {
            matrixPanel = new Panel
            {
                BackColor = Color.Transparent,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            this.Controls.Add(matrixPanel);

            this.MinimumSize = new Size(300, 300);
        }

        private void CreateMatrix()
        {
            matrixPanel.Controls.Clear();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    CharBox box = new CharBox();
                    box.Size = new Size(boxSize, boxSize);
                    box.SetCharacter('-');
                    box.Location = new Point(
                        j * (boxSize + spacing),
                        i * (boxSize + spacing)
                    );
                    matrixPanel.Controls.Add(box);
                }
            }
        }


        private void CenterMatrix()
        {
            int panelWidth = cols * (boxSize + spacing);
            int panelHeight = rows * (boxSize + spacing);

            matrixPanel.Location = new Point(
                (this.ClientSize.Width - panelWidth) / 2,
                (this.ClientSize.Height - panelHeight) / 2
            );
        }
    }
}
