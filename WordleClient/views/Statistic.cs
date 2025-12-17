using System;
using System.Collections.Generic;
using System.ComponentModel;
using WordleClient.libraries.math;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.ingame;
using WordleClient.libraries.CustomControls;
using WordleClient.libraries.StateFrom;

namespace WordleClient.views
{
    public partial class Statistic : CustomForm
    {
        private string? selectedGroup = null;
        SingleplayerLogger spl = new();

        public Statistic()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                selectedGroup = null;
            }
            else
            {
                if (comboBox1.SelectedItem != null)
                    selectedGroup = comboBox1.SelectedItem.ToString();
            }

            UpdateStats();
        }
        private void UpdateStats()
        {
            var logs = spl.LoadFromDatabase(selectedGroup);
            var stats = MathHelper.AnalyseSingleResult(logs);

            customLabel3.Text = $"{stats.playCount}";
            customLabel4.Text = $"{stats.winCount}";
            customLabel2.Text = $"{stats.currentStreak}";
            customLabel1.Text = $"{stats.maxStreak}";
            customLabel5.Text = $"{stats.winRate:P2}";
            customLabel6.Text = $"{stats.averageAttempts:F2}";

            customLabel3.Refresh();
            customLabel4.Refresh();
            customLabel2.Refresh();
            customLabel1.Refresh();
            customLabel5.Refresh();
            customLabel6.Refresh();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            spl.Close();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Close();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            List<String> groups = spl.LoadAllGroups();
            if (groups.Count > 0)
            {
                comboBox1.Items.Add("All Games");
                foreach (var group in groups)
                {
                    comboBox1.Items.Add(group);
                }
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No game logs found. Play some games to see statistics!", "No Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
