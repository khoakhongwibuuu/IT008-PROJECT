using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.network
{
    public sealed class PacketServerManager
    {
        private readonly TcpListener _listener;
        private readonly ConcurrentDictionary<string, PacketConnection> _clients = new();

        public event Action<PacketConnection, Packet>? PacketReceived;
        public event Action<PacketConnection>? ClientConnected;
        public event Action<PacketConnection>? ClientDisconnected;

        public PacketServerManager(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }
        public async Task StartAsync()
        {
            _listener.Start();

            while (true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                string id = Guid.NewGuid().ToString();

                var conn = new PacketConnection(client, id);
                conn.PacketReceived += OnPacket;
                conn.Disconnected += OnDisconnect;

                _clients[id] = conn;
                ClientConnected?.Invoke(conn);

                conn.Start();
            }
        }
        private void OnPacket(PacketConnection conn, Packet packet)
        {
            PacketReceived?.Invoke(conn, packet);
        }
        private void OnDisconnect(PacketConnection conn)
        {
            _clients.TryRemove(conn.ConnectionId, out _);
            ClientDisconnected?.Invoke(conn);
        }
        public Task BroadcastAsync(Packet packet)
        {
            foreach (var c in _clients.Values)
                _ = c.SendAsync(packet);

            return Task.CompletedTask;
        }
    }
}
