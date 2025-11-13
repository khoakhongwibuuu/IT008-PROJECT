using WordleClient.libraries.CustomControls;
using WordleClient.libraries.StateFrom;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;
using System.Diagnostics;

namespace WordleClient.views
{
    public partial class FormOption : CustomForm
    {
        private List<string> topics = new List<string>();
        private string? selectedTopic;
        private string? selectedDifficulty;

        // When true MainMenu should be shown when this form closes.
        // When false (e.g. we opened Playground) MainMenu will be shown by Playground's closed handler.
        public bool ReturnToMainOnClose { get; set; } = true;

        public FormOption()
        {
            InitializeComponent();
            WordDatabaseReader wdr = new WordDatabaseReader();
            topics = wdr.loadGroups();
            for (int i = 0; i < topics.Count; i++)
            {
                cbbTopic.Items.Add(topics[i]);
            }
            cbbTopic.Items.Add("(Random)");

            // choose Random topic by default
            cbbTopic.SelectedIndex = topics.Count();
            int itemHeight = cbbTopic.ItemHeight;
            int visibleItems = 7;
            cbbTopic.DropDownHeight = itemHeight * visibleItems;
            cbbTopic.IntegralHeight = false;


            customGroupBox1.TabIndex = 0;
            selectedDifficulty = null;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Close();
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            int MaxGuessCount = trackBarGuess.Value;
            Debug.WriteLine($"START_BTN_OUTPUT: Param1={selectedTopic}, Param2={selectedDifficulty}");

            WordDatabaseReader wdr = new WordDatabaseReader();
            WDBRecord? TheChosenOne = wdr.ReadRandomWord(selectedTopic, selectedDifficulty);
            Debug.WriteLine($"START_BTN_OUTPUT: ChosenWord='{TheChosenOne?.TOKEN}', Topic='{TheChosenOne?.GROUP_NAME}'");
            if (TheChosenOne == null)
            {
                MessageBox.Show(
                    "No word found for the selected topic and difficulty. Please with another criteria.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
            else
            {
                // Create playground and ensure MainMenu will be shown when playground closes.
                Playground pg = new Playground(TheChosenOne, MaxGuessCount);
                pg.FormClosed += (s, ev) =>
                {
                    var main = Application.OpenForms.OfType<MainMenu>().FirstOrDefault();
                    if (main != null)
                    {
                        main.Show();
                        CustomSound.PlayBackgroundLoop();
                    }    
                };

                // Indicate that closing this FormOption should NOT return to MainMenu
                this.ReturnToMainOnClose = false;

                // Close this options form and show playground
                this.Close();

                CustomSound.StopBackground();
                pg.Show();
            }
        }

        private void cbbTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTopicIdx = 0;
            if (cbbTopic.SelectedIndex != topics.Count)
            {
                selectedTopicIdx = cbbTopic.SelectedIndex;
                selectedTopic = topics[selectedTopicIdx];
            }
            else
            {
                selectedTopic = null;
            }
        }

        private void rd_Random_CheckedChanged(object sender, EventArgs e)
        {
            selectedDifficulty = null;

        }

        private void rd_Hard_CheckedChanged(object sender, EventArgs e)
        {
            selectedDifficulty = "HARD";
        }

        private void rd_Easy_CheckedChanged(object sender, EventArgs e)
        {
            selectedDifficulty = "EASY";
        }
    }
}
