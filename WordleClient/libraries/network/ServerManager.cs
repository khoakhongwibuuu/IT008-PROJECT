using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordleClient.libraries.ingame;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.network
{
    public static class ServerManager
    {
        private static TcpListener? _listener;
        private static bool _running;

        // Active client connections keyed by IP
        private static readonly ConcurrentDictionary<string, PacketConnection>
            _clients = new();

        /* ============================================================
         * EVENTS (SERVER -> UI)
         * ============================================================ */
        // Fired for packets that require UI or game logic handling
        public static event Action<PacketConnection, Packet>? ServerPacketReceived;
        // Fired when a client disconnects, used to update player list
        public static event Action<string>? ClientDisconnected;
        public static bool IsRunning => _running;

        /* ============================================================
         * LIFECYCLE
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
        // Accepts incoming TCP clients and attaches PacketConnections
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
         * PACKET DISPATCH (CLIENTS -> SERVER)
         * ============================================================ */
        // Central packet router for all incoming packets
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

                case SEND_HINT_REQUEST_Packet hint_req:
                case SEND_GUESS_Packet guess:
                    ServerPacketReceived?.Invoke(conn, packet);
                    break;

                case GAME_STATUS_UPDATE_REQUEST_Packet gamestatusupdate:
                    ServerPacketReceived?.Invoke(conn, packet);
                    break;

                default:
                    Broadcast(packet);
                    break;
            }
        }

        /* ============================================================
         * JOIN FLOW
         * ============================================================ */
        // Handles initial join request, the UI decides whether to approve or not
        private static void HandleJoinRequest(
            PacketConnection conn,
            JOIN_REQUEST_Packet join)
        {
            // Room full -> immediate reject
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
            Player pending = new(
                join.Username,
                conn.ConnectionId);

            // Notify SERVER UI directly (NOT over network)
            ServerPacketReceived?.Invoke(
                conn,
                new JOIN_APPROVAL_REQUEST_Packet(
                    pending.Serialize(),
                    "Server"));
        }
        // Finalises approval/denial and notifies client
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
        // Broadcasts the authoritative player list to all clients
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
        // Handles client disconnection
        private static void OnClientDisconnected(PacketConnection conn)
        {
            _clients.TryRemove(conn.ConnectionId, out _);

            Player? player = GameRoom.GetPlayerByIP(conn.ConnectionId);

            if (player != null)
                GameRoom.RemoveClient(player);

            // notify UI
            ClientDisconnected?.Invoke(conn.ConnectionId);

            BroadcastPlayerList();
        }

        /* ============================================================
         * SENDERS (SERVER -> CLIENTS)
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
        public static void SendTo(PacketConnection conn, Packet packet)
        {
            _ = conn.SendAsync(packet);
        }
    }
}
