using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.network
{
    public static class ServerManager
    {
        private static TcpListener? _listener;
        private static bool _running;

        // key = IP address
        private static readonly ConcurrentDictionary<string, PacketConnection>
            _clients = new();

        /* ============================================================
         * EVENTS (SERVER → UI)
         * ============================================================ */

        // Fired ONLY for UI-related server events
        public static event Action<Packet>? ServerPacketReceived;
        public static event Action<string>? ClientDisconnected;

        public static bool IsRunning => _running;

        /* ============================================================
         * START / STOP
         * ============================================================ */

        public static void Start(int port)
        {
            if (_running)
                throw new InvalidOperationException("Server already running");

            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();

            _running = true;
            Task.Run(AcceptLoop);
        }

        public static void Stop()
        {
            _running = false;

            foreach (var c in _clients.Values)
                c.Dispose();

            _clients.Clear();
            _listener?.Stop();
            _listener = null;

            GameRoom.Dispose();
        }

        /* ============================================================
         * ACCEPT LOOP
         * ============================================================ */

        private static async Task AcceptLoop()
        {
            while (_running)
            {
                TcpClient tcp = await _listener!.AcceptTcpClientAsync();
                string ip =
                    ((IPEndPoint)tcp.Client.RemoteEndPoint!).Address.ToString();

                var conn = new PacketConnection(tcp, ip);
                conn.PacketReceived += OnPacketReceived;
                conn.Disconnected += OnClientDisconnected;

                _clients[ip] = conn;
                conn.Start();
            }
        }

        /* ============================================================
         * PACKET DISPATCH (NETWORK → SERVER)
         * ============================================================ */

        private static void OnPacketReceived(
            PacketConnection conn,
            Packet packet)
        {
            switch (packet)
            {
                case JOIN_REQUEST_Packet join:
                    HandleJoinRequest(conn, join);
                    break;

                case JOIN_APPROVAL_RESPONSE_Packet approval:
                    HandleApprovalResponse(approval);
                    break;

                default:
                    // Forward game packets, chat, etc.
                    Broadcast(packet);
                    break;
            }
        }

        /* ============================================================
         * JOIN FLOW
         * ============================================================ */

        private static void HandleJoinRequest(
            PacketConnection conn,
            JOIN_REQUEST_Packet join)
        {
            // Room full → immediate reject
            if (!GameRoom.HasSpace)
            {
                _ = conn.SendAsync(
                    new JOIN_RESPONSE_Packet(
                        false,
                        "Server",
                        join.Sender));
                return;
            }

            // Build pending player
            Player pending = new Player(
                join.Username,
                conn.ConnectionId);

            // 🔥 IMPORTANT:
            // Notify SERVER UI directly (NOT over network)
            ServerPacketReceived?.Invoke(
                new JOIN_APPROVAL_REQUEST_Packet(
                    pending.Serialize(),
                    "Server"));
        }

        private static void HandleApprovalResponse(
            JOIN_APPROVAL_RESPONSE_Packet res)
        {
            Player player = Player.Parse(res.Username);

            if (res.Approved)
            {
                if (!GameRoom.AddClient(player))
                    return;
            }

            // Notify client of result
            SendTo(
                player.IPAddress,
                new JOIN_RESPONSE_Packet(
                    res.Approved,
                    "Server",
                    player.Username));

            BroadcastPlayerList();
        }

        /* ============================================================
         * PLAYER LIST SYNC
         * ============================================================ */

        public static void BroadcastPlayerList()
        {
            Broadcast(
                new PLAYER_LIST_SYNC_Packet(
                    GameRoom.SerializePlayers(),
                    "Server",
                    "All"));
        }

        /* ============================================================
         * DISCONNECT HANDLING
         * ============================================================ */

        private static void OnClientDisconnected(PacketConnection conn)
        {
            _clients.TryRemove(conn.ConnectionId, out _);

            Player? player = GameRoom.GetPlayerByIP(conn.ConnectionId);

            if (player != null)
                GameRoom.RemoveClient(player);

            // 🔥 notify UI
            ClientDisconnected?.Invoke(conn.ConnectionId);

            BroadcastPlayerList();
        }

        /* ============================================================
         * SEND HELPERS (SERVER → CLIENTS)
         * ============================================================ */

        public static void Broadcast(Packet packet)
        {
            foreach (var c in _clients.Values)
                _ = c.SendAsync(packet);
        }

        public static void SendTo(string ip, Packet packet)
        {
            if (_clients.TryGetValue(ip, out var conn))
                _ = conn.SendAsync(packet);
        }
    }
}
