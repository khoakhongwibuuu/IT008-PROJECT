using System.Diagnostics;
using System.Text;
using WordleClient.libraries.CustomControls;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.StateFrom;

namespace WordleClient.views
{
    public partial class Playground : Form
    {
        // Matrix dimensions
        private readonly int rows;
        private readonly int cols;
        private readonly Panel matrixPanel;

        // Size constants
        private const int boxSize = 60;
        private const int spacing = 6;

        // Tracks the current string being built in the current row
        private string currentString = string.Empty;

        // Game flags
        private bool HasCompletedString = false;
        private bool GameEnded = false;
        private int HintRemaining;
        private readonly int GameSeed;

        // Tracks the current position where typed letters will go (next free column)
        private int currentRow = 0;
        private int currentCol = 0;

        // Whether the current row is fully filled (when true, only Enter and Backspace are handled)
        // private bool rowCompleted = false;

        // Game Instance
        private GameInstance gameInstance;
        
        // Dictionary Checker
        private DictionaryChecker dictionaryChecker;

        // Game logger
        //private SingleplayerLogger gameLogger;

        public Playground(WDBRecord TheChosenOne, int MaxGuessCount)
        {
            Random rd = new();
            this.rows = MaxGuessCount;
            this.cols = TheChosenOne.TOKEN.Length;
            this.gameInstance = new GameInstance(TheChosenOne);
            this.dictionaryChecker = new DictionaryChecker(TheChosenOne.TOKEN.Length);
            //this.gameLogger = new SingleplayerLogger();
            this.GameSeed = rd.Next(0, 1);
            this.HintRemaining = 2;
            InitializeComponent();

            // Dynamic matrix panel setup
            this.matrixPanel = new Panel
            {
                BackColor = Color.Transparent,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                TabIndex = 3
            };
            this.panel2.Controls.Add(matrixPanel);

            // Set value to display labels
            lbl_Diff.Text = TheChosenOne.LEVEL;
            lbl_Tpc.Text = TheChosenOne.GROUP_NAME.Replace("&", "And");
            lbl_HintRemaining.Text = HintRemaining.ToString();

            // Matrix setup and centering
            CreateMatrix();
            CenterMatrix();

            // Ensure form receives key events before controls
            this.KeyPreview = true;
            this.KeyPress += Playground_KeyPress;

            // Resize event to re-center matrix
            this.Resize += (s, e) => CenterMatrix();
            this.panel2.Resize += (s, e) => CenterMatrix();

            // Warning on exit if game not ended
            this.FormClosing += Playground_FormClosing;
        }

        private void Playground_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (GameEnded) return;
            else
            {
                if (
                    MessageBox.Show(
                    "Are you sure you want to exit? This game will not be saved.",
                    "Exit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No
                )
                {
                    e.Cancel = true;
                }
            }
        }

        private void CreateMatrix()
        {
            matrixPanel.Controls.Clear();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    CharBox box = new()
                    {
                        Size = new Size(boxSize, boxSize),
                        Location = new Point(
                            j * (boxSize + spacing),
                            i * (boxSize + spacing)
                        )
                    };
                    box.SetCharacter('-');
                    matrixPanel.Controls.Add(box);
                }
            }

            currentRow = 0;
            currentCol = 0;
            currentString = GetRowString(0);
        }

        private void CenterMatrix()
        {
            int panelWidth = cols * (boxSize + spacing) - spacing;
            int panelHeight = rows * (boxSize + spacing) - spacing;

            matrixPanel.Location = new Point(
                (this.panel2.Width - panelWidth) / 2,
                (this.panel2.Height - panelHeight) / 2
            );
        }
        private void KeyIsDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void Playground_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // If game has ended, do not handle
            if (GameEnded) return;

            // ENTER: only handled when current row is filled
            if (e.KeyChar == '\r')
            {
                if (IsRowFilled(currentRow))
                {
                    currentString = GetRowString(currentRow);
                    if (dictionaryChecker.TokenExists(currentString))
                    {

                        Debug.WriteLine($"Submitted word: {currentString}");
                        var result = gameInstance.EvaluateGuess(currentString);

                        for (int c = 0; c < cols; c++)
                        {
                            var box = GetBox(currentRow, c);
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

                        if (result.IsFullValue(TriState.MATCH))
                        {
                            HasCompletedString = true;
                            GameEnded = true;
                            MessageBox.Show("Congrats. You have found the hidden word.");

                        }
                        if (currentRow < rows - 1)
                        {
                            currentRow++;
                            currentCol = 0;
                        }
                        else
                        {
                            // The player has used all of their attempts
                            if (!HasCompletedString)
                            {
                                MessageBox.Show($"You have failed. The hidden word is {gameInstance.GetToken()}");
                                GameEnded = true;
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
                    currentString = GetRowString(currentRow);
                    Debug.WriteLine(currentString);
                    e.Handled = true;
                }

                return;
            }

            // If the row is already filled, ignore alphabet input (only Enter/Backspace allowed)
            if (IsRowFilled(currentRow)) return;

            // Alphabet character handling (only when row not filled)
            if (char.IsLetter(e.KeyChar))
            {
                char ch = char.ToUpperInvariant(e.KeyChar);

                // Guard: ensure currentCol is a valid index for the next box
                if (currentCol >= 0 && currentCol < cols)
                {
                    CharBox? box = GetBox(currentRow, currentCol);
                    if (box == null) return;

                    box.SetCharacter(ch);
                    currentCol++; // advance to next free column

                    // Rebuild currentString from the row (handles clicks/edits in any position)
                    currentString = GetRowString(currentRow);
                    Debug.WriteLine(currentString);

                    // prevent system beep
                    e.Handled = true;
                }
            }
        }
        private bool IsRowFilled(int row)
        {
            if (row < 0 || row >= rows)
                return false;
            if (row < currentRow)
                return true;
            if (row > currentRow)
                return false;
            if (currentCol >= cols)
                return true;
            for (int c = 0; c < cols; c++)
            {
                var b = GetBox(row, c);
                if (b == null || IsBoxEmpty(b))
                    return false;
            }

            return true;
        }
        private static bool IsBoxEmpty(CharBox box)
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
        private void GetHintBtn_Click(object sender, EventArgs e)
        {
            if (HintRemaining > 0 && !GameEnded)
            {
                CustomSound.PlayClick();
                string hint = gameInstance.GetHint(HintRemaining + GameSeed);
                MessageBox.Show($"Hint: {hint}", "Get Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HintRemaining--;
                if (HintRemaining == 1)
                {
                    lbl_Hint1_Placeholder.Text = hint;
                }
                else
                {
                    lbl_Hint2_Placeholder.Text = hint;
                }

                lbl_HintRemaining.Text = HintRemaining.ToString();

                if (HintRemaining == 0)
                    customButton1.Visible = false;
            }
            else if (GameEnded)
            {
                MessageBox.Show("The game has ended.", "Get Hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("No hints remaining.", "Get Hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Close();
        }
    }
}