using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.network
{
    public static class ConnectionManager
    {
        private static readonly ClientConnection connection = new();

        public static ClientConnection Connection => connection;

        public static bool IsConnected => connection.IsConnected;
    }
}
