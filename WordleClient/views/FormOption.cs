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
            cbbTopic.SelectedIndex = topics.Count();
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
            if (TheChosenOne == null)
            {
                MessageBox.Show("No word found for the selected topic and difficulty. Please with another criteria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                CustomSound.StopBackground();
                GameInstance game = new GameInstance(TheChosenOne, MaxGuessCount);
                game.StartGameForm(MaxGuessCount);
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
            selectedDifficulty = "EASY";
        }

        private void rd_Hard_CheckedChanged(object sender, EventArgs e)
        {
            selectedDifficulty = "HARD";
        }

        private void rd_Easy_CheckedChanged(object sender, EventArgs e)
        {
            selectedDifficulty = null;
        }
    }
}
