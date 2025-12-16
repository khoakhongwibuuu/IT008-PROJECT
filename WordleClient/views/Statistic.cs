using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordleClient.libraries.math;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.ingame;

namespace WordleClient.views
{
    public partial class Statistic : Form
    {
        private string? selectedGroup = null;
        SingleplayerLogger spl = new();

        public Statistic()
        {
            InitializeComponent();
            SingleplayerLogger spl = new();
            var groups = spl.LoadAllGroups();
            comboBox1.Items.Add("All Groups");
            comboBox1.SelectedIndex = 0;
            foreach (var group in groups)
            {
                comboBox1.Items.Add(group);
            }
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

            label7.Text = $"{stats.playCount}";
            label8.Text = $"{stats.winCount}";
            label9.Text = $"{stats.currentStreak}";
            label10.Text = $"{stats.maxStreak}";
            label11.Text = $"{stats.winRate:P2}";
            label12.Text = $"{stats.averageAttempts:F2}";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            spl.Close();
        }
    }
}
