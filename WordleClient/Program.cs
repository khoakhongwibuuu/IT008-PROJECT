using WordleClient.libraries;

namespace WordleClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            // Hello

            var states = new StateArray(5);

            states.SetAll(TriState.NOT_EXIST);

            states.Set(0, TriState.MATCH);
            states.Set(1, TriState.INVALID_ORDER);

            Console.WriteLine("Values:");
            foreach (var s in states)
                Console.Write($"{s} ");

            Console.WriteLine();
            Console.WriteLine($"Memory used: {states.RawData.Length} bytes");
        }
    }
}