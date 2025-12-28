using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.network
{
    public static class PacketConnectionManager
    {
        private static PacketConnection? _connection;

        /* ============================================================
         * EVENTS
         * ============================================================ */

        public static event Action<Packet>? PacketReceived;
        public static event Action<string>? ErrorOccurred;
        public static event Action? Disconnected;

        public static bool IsConnected => _connection != null;

        /* ============================================================
         * CLIENT CONNECT
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
         * ATTACH (CLIENT OR SERVER)
         * ============================================================ */
        public static void Attach(TcpClient client)
        {
            if (_connection != null)
                throw new InvalidOperationException("Connection already attached");

            string id = Guid.NewGuid().ToString();

            _connection = new PacketConnection(client, id);

            _connection.PacketReceived += OnPacketReceived;
            _connection.Disconnected += OnDisconnected;
            _connection.Start(); // ✅ correct method
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
