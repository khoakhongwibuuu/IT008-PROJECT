namespace WordleClient
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int wordlength = 5;
            MainArea fWordleClient = new MainArea(wordlength);
            fWordleClient.ShowDialog();
        }
    }
}
