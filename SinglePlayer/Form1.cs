namespace SinglePlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int wordlength = 5;
            fSinglePlayer fSinglePlayer = new fSinglePlayer(wordlength);
            fSinglePlayer.ShowDialog();
        }
    }
}
