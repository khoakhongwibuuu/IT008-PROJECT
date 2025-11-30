using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordleClient.libraries.StateFrom;

namespace WordleClient.libraries.CustomControls
{
    public partial class CustomDgv : Form
    {
        public CustomDgv()
        {
            InitializeComponent();
        }

        private void Exit_1_Click(object sender, EventArgs e)
        {
            CustomSound.PlayClick();
            this.Close();
        }
    }
}
