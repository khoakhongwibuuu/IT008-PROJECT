using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordleClient.CustomControls;
using WordleClient.StateFrom;
namespace WordleClient.GUI
{
    public partial class FormOption : CustomForm
    {
        public FormOption()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Close();
        }
        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            int wordLength = 7;
            int cntGuess = (int)trackBarGuess.Value;
            this.Hide();
            FormArea formArea = new FormArea(cntGuess, wordLength);
            formArea.ShowDialog();
            this.Show();
        }
        private void FormOption_Load(object sender, EventArgs e)
        {

        }
    }
}
