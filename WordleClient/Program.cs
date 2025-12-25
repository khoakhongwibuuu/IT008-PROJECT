namespace WordleClient
{
    internal static class Program
    {
        private static Mutex? _mutex;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new MainMenu());

            const string mutexName = "WordleGame_SingleInstance_Mutex";

            bool createdNew;
            _mutex = new Mutex(true, mutexName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show(
                    "The application is already running. Creating another instance of this app may lead to unexpected behaviour.",
                    "Potential bug ahead!!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new MainMenu());

            // Release on clean exit
            _mutex.ReleaseMutex();
            _mutex.Dispose();
        }
    }
}