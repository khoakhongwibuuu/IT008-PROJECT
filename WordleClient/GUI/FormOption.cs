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
    public partial class FormOption : Form
    {
        public FormOption()
        {
            InitializeComponent();
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            int LengthGuess = trackbar_GuessCount.Value;
            int wordLength = 5;
            this.Hide();
            MainArea mainArea = new MainArea (wordLength, LengthGuess);
            mainArea.ShowDialog();
            this.Show();
        }
    }
}
