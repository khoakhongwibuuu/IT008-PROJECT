using System;
using System.Media;
using System.Windows.Forms;
using WordleClient.GUI;

namespace WordleClient
{
    public partial class MainMenu : Form
    {

        public MainMenu()
        {
            InitializeComponent();

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }


        private void btn_SinglePlayer_Click(object sender, EventArgs e)
        {
            FormOption formOption = new FormOption();
            formOption.ShowDialog();
        }

        private void customControl11_Click(object sender, EventArgs e)
        {
            FormSetting formSetting = new FormSetting();
            formSetting.ShowDialog();
        }
    }
}
