using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.network
{
    public static class PacketConnectionManager
    {
        private static PacketConnection? _connection;
        public static bool IsConnected => _connection != null;

        /* ============================================================
         * EVENTS
         * ============================================================ */
        // Fires when received a packet from the server
        public static event Action<Packet>? PacketReceived;
        // Fires when the server disconnects
        public static event Action? Disconnected;

        /* ============================================================
         * CONNECTS TO A SERVER ASYNCHRONOUSLY
         * ============================================================ */
        public static async Task ConnectAsync(string host, int port)
        {
            if (_connection != null)
                throw new InvalidOperationException("Already connected");

            TcpClient client = new();
            await client.ConnectAsync(host, port);

            Attach(client);
        }

        /* ============================================================
         * ATTACHES AN EXISTING TcpClient TO PacketConnection
         * ============================================================ */
        public static void Attach(TcpClient client)
        {
            if (_connection != null)
                throw new InvalidOperationException("Connection already attached");

            string id = Guid.NewGuid().ToString();

            _connection = new PacketConnection(client, id);

            _connection.PacketReceived += OnPacketReceived;
            _connection.Disconnected += OnDisconnected;
            _connection.Start();
        }

        /* ============================================================
         * SEND
         * ============================================================ */
        public static Task SendAsync(Packet packet)
        {
            if (_connection == null)
                throw new InvalidOperationException("Not connected");

            return _connection.SendAsync(packet);
        }

        /* ============================================================
         * INTERNAL HANDLERS
         * ============================================================ */
        private static void OnPacketReceived(PacketConnection _, Packet packet)
        {
            PacketReceived?.Invoke(packet);
        }
        private static void OnDisconnected(PacketConnection _)
        {
            _connection = null;
            Disconnected?.Invoke();
        }

        /* ============================================================
         * DISCONNECT
         * ============================================================ */
        public static void Disconnect()
        {
            _connection?.Dispose();
            _connection = null;
        }
    }
}
