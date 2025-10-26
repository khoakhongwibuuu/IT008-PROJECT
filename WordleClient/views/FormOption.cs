using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordleClient.views
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
            //panel1.Controls.Clear();
            //panel1.Controls.Add(new MatrixDemo(LengthGuess, 5));
            this.Hide();
            using (var f = new MatrixDemo(LengthGuess, 5))
            {
                f.ShowDialog(this);
            }
            //this.Show();
        }
    }
}
