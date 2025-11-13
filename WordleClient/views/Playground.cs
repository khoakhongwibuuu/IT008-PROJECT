using System.Diagnostics;
using System.Text;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;

namespace WordleClient.views
{
    public partial class Playground : Form
    {
        // Matrix dimensions
        private readonly int rows;
        private readonly int cols;
        private readonly Panel matrixPanel;

        // Size constants
        private const int boxSize = 45;
        private const int spacing = 5;

        // Tracks the current string being built in the current row
        private string currentString = string.Empty;

        // Tracks the current position where typed letters will go (next free column)
        private int currentRow = 0;
        private int currentCol = 0;

        // Whether the current row is fully filled (when true, only Enter and Backspace are handled)
        private bool rowCompleted = false;

        // Game Instance
        private GameInstance gameInstance;

        public Playground(WDBRecord TheChosenOne, int MaxGuessCount)
        {
            this.rows = MaxGuessCount;
            this.cols = TheChosenOne.TOKEN.Length;
            this.WindowState = FormWindowState.Maximized;
            this.gameInstance = new GameInstance(TheChosenOne, MaxGuessCount);

            InitializeComponent();
            this.matrixPanel = new Panel
            {
                BackColor = Color.Transparent,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            this.Controls.Add(matrixPanel);
            this.MinimumSize = new Size(300, 300);

            CreateMatrix();
            CenterMatrix();

            // Ensure form receives key events before controls
            this.KeyPreview = true;
            this.KeyPress += Playground_KeyPress;

            this.Resize += (s, e) => CenterMatrix();
        }

        private void CreateMatrix()
        {
            matrixPanel.Controls.Clear();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // capture loop variables for the click handler
                    int row = i;
                    int col = j;

                    CharBox box = new CharBox();
                    box.Size = new Size(boxSize, boxSize);
                    box.SetCharacter('-');
                    box.Location = new Point(
                        j * (boxSize + spacing),
                        i * (boxSize + spacing)
                    );

                    // Allow user to click a box to change the current input position
                    box.Click += (s, e) =>
                    {
                        currentRow = row;
                        // next free column should be the clicked box index
                        currentCol = col;
                        // recompute whether the row is completed
                        rowCompleted = IsRowFilled(currentRow);
                        // update currentString to reflect the clicked row
                        currentString = GetRowString(currentRow);
                        Debug.WriteLine(currentString);
                    };

                    matrixPanel.Controls.Add(box);
                }
            }

            // reset cursor state after creating matrix
            currentRow = 0;
            currentCol = 0;
            rowCompleted = IsRowFilled(0);
            currentString = GetRowString(0);
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

        private void Playground_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // ENTER: only handled when current row is filled
            if (e.KeyChar == '\r')
            {
                if (IsRowFilled(currentRow) && currentRow < rows - 1)
                {
                    rowCompleted = IsRowFilled(currentRow);
                    currentString = GetRowString(currentRow);
                    if (gameInstance.isFoundInDictionary(currentString) || true)
                    {
                        currentRow++;
                        currentCol = 0;
                        Debug.WriteLine($"Submitted word: {currentString}");
                        var result = gameInstance.EvaluateGuess(currentString);

                        for (int c = 0; c < cols; c++)
                        {
                            var box = GetBox(currentRow - 1, c);
                            if (box != null)
                            {
                                switch (result.Get(c))
                                {
                                    case TriState.MATCH:
                                        box.SetBackgroundColor(Color.FromArgb(255, 0x53, 0x8D, 0x4E));
                                        break;
                                    case TriState.INVALID_ORDER:
                                        box.SetBackgroundColor(Color.FromArgb(255, 0xB5, 0x9F, 0x3B));
                                        break;
                                    case TriState.NOT_EXIST:
                                        box.SetBackgroundColor(Color.FromArgb(255, 0x3A, 0x3A, 0x3C));
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "The entered word is not in the dictionary.",
                            "Invalid Word", MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );
                    }
                    Debug.WriteLine(currentString);
                    e.Handled = true;
                }
                return;
            }

            // BACKSPACE: always allowed; if row was completed, backspace should un-complete it
            if (e.KeyChar == '\b')
            {
                // If the row is completed (cursor effectively at cols), delete last cell
                if (IsRowFilled(currentRow))
                {
                    int lastIdx = cols - 1;
                    var lastBox = GetBox(currentRow, lastIdx);
                    if (lastBox != null)
                    {
                        lastBox.SetCharacter('-');
                        currentCol = lastIdx;
                        rowCompleted = false;
                        currentString = GetRowString(currentRow);
                        Debug.WriteLine(currentString);
                        e.Handled = true;
                    }
                    return;
                }

                // If there are typed chars, move back and clear
                if (currentCol > 0)
                {
                    currentCol--;
                    var box = GetBox(currentRow, currentCol);
                    if (box != null)
                    {
                        box.SetCharacter('-');
                        rowCompleted = IsRowFilled(currentRow);
                        currentString = GetRowString(currentRow);
                        Debug.WriteLine(currentString);
                        e.Handled = true;
                    }
                    return;
                }

                // If at column 0 but that box contains a character, clear it
                var firstBox = GetBox(currentRow, 0);
                if (firstBox != null && !IsBoxEmpty(firstBox))
                {
                    firstBox.SetCharacter('-');
                    rowCompleted = IsRowFilled(currentRow);
                    currentString = GetRowString(currentRow);
                    Debug.WriteLine(currentString);
                    e.Handled = true;
                }

                return;
            }

            // If the row is already filled, ignore alphabet input (only Enter/Backspace allowed)
            if (IsRowFilled(currentRow))
            {
                return;
            }

            // Alphabet character handling (only when row not filled)
            if (char.IsLetter(e.KeyChar))
            {
                char ch = char.ToUpperInvariant(e.KeyChar);

                // Guard: ensure currentCol is a valid index for the next box
                if (currentCol >= 0 && currentCol < cols)
                {
                    var box = GetBox(currentRow, currentCol);
                    if (box == null)
                        return;

                    box.SetCharacter(ch);
                    currentCol++; // advance to next free column

                    // Rebuild currentString from the row (handles clicks/edits in any position)
                    currentString = GetRowString(currentRow);
                    Debug.WriteLine(currentString);

                    // If we've filled the row, mark it completed
                    if (IsRowFilled(currentRow))
                        rowCompleted = true;

                    // prevent system beep
                    e.Handled = true;
                }
            }
        }
        private bool IsRowFilled(int row)
        {
            if (row < 0 || row >= rows)
                return false;

            for (int c = 0; c < cols; c++)
            {
                var b = GetBox(row, c);
                if (b == null || IsBoxEmpty(b))
                    return false;
            }
            return true;
        }

        private bool IsBoxEmpty(CharBox box)
        {
            if (box == null)
                return true;

            var ch = box.Character;
            if (string.IsNullOrEmpty(ch))
                return true;
            if (ch == "-" || ch == "\0" || ch == "\u0000")
                return true;
            return false;
        }

        private string GetRowString(int row)
        {
            if (row < 0 || row >= rows)
                return string.Empty;

            var sb = new StringBuilder();
            for (int c = 0; c < cols; c++)
            {
                var b = GetBox(row, c);
                if (b == null)
                    continue;

                var ch = b.Character;
                if (string.IsNullOrEmpty(ch))
                    continue;
                if (ch == "-" || ch == "\0" || ch == "\u0000")
                    continue;

                // CharBox.Character is a string; append its first character
                sb.Append(ch[0]);
            }

            return sb.ToString();
        }

        private CharBox? GetBox(int r, int c)
        {
            if (r < 0 || c < 0 || r >= rows || c >= cols || matrixPanel == null)
                return null;

            int index = r * cols + c;
            if (index < 0 || index >= matrixPanel.Controls.Count)
                return null;

            return matrixPanel.Controls[index] as CharBox;
        }
    }
}