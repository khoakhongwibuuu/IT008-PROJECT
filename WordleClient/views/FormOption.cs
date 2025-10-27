using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;
namespace WordleClient.views
{
    public partial class FormOption : Form
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
                cbb_Topic.Items.Add(topics[i]);
            }
            cbb_Topic.Items.Add("(random)");
            cbb_Topic.SelectedIndex = topics.Count();
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            int LengthGuess = trackbar_GuessCount.Value;
            Debug.WriteLine($"START_BTN_OUTPUT: Param1={selectedTopic}, Param2={selectedDifficulty}");

            WordDatabaseReader wdr = new WordDatabaseReader();
            WDBRecord? TheChosenRecord = wdr.ReadRandomWord(selectedTopic, selectedDifficulty);
            if (TheChosenRecord == null)
            {
                MessageBox.Show("No word found for the selected topic and difficulty. Please with another criteria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                Debug.WriteLine($"QUERY DATABASE DONE: Chosen word: {TheChosenRecord.TOKEN}, Topic: {TheChosenRecord.GROUP_NAME}, Difficulty: {TheChosenRecord.LEVEL}");
                var game = new GameInstance(TheChosenRecord, 6);
                game.StartGameForm(6);
            }
        }
        private void cbb_Topic_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTopicIndex = 0;
            if (cbb_Topic.SelectedIndex != topics.Count)
            {
                selectedTopicIndex = cbb_Topic.SelectedIndex;
                selectedTopic = topics[selectedTopicIndex];
            }
            else
            {
                selectedTopic = null;
            }
        }

        private void rad_Easy_CheckedChanged(object sender, EventArgs e)
        {
            selectedDifficulty = "EASY";
        }

        private void rad_Hard_CheckedChanged(object sender, EventArgs e)
        {
            selectedDifficulty = "HARD";
        }

        private void rad_Random_CheckedChanged(object sender, EventArgs e)
        {
            selectedDifficulty = null;
        }
    }
}
