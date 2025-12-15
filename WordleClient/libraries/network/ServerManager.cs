using WordleClient.libraries.network;

namespace WordleClient.libraries.network
{
    public static class ServerManager
    {
        private static readonly ServerListener server = new();

        public static ServerListener Server => server;

        public static bool IsRunning { get; private set; }

        public static Task? ServerTask { get; private set; }

        public static void Start(int port)
        {
            if (IsRunning)
                return;

            IsRunning = true;
            ServerTask = server.StartAsync(port);
        }

        public static void Stop()
        {
            if (!IsRunning)
                return;

            server.Stop();
            IsRunning = false;
        }
    }
}
