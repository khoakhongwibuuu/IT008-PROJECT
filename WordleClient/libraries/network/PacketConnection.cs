using System;
using System.Diagnostics;

//using System.Diagnostics;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.network
{
    public sealed class PacketConnection : IDisposable
    {
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;
        private readonly CancellationTokenSource _cts = new();
        private readonly CancellationTokenSource _heartbeatCts = new();

        private readonly TimeSpan _pingInterval = TimeSpan.FromSeconds(5);
        private DateTime _lastPong = DateTime.UtcNow;

        public string ConnectionId { get; }

        public event Action<PacketConnection, Packet>? PacketReceived;
        public event Action<PacketConnection>? Disconnected;

        public PacketConnection(TcpClient client, string id)
        {
            ConnectionId = id;
            _client = client;
            _stream = client.GetStream();
        }

        /* ================= SEND ================= */
        public async Task SendAsync(Packet packet)
        {
            try
            {
                string json = packet.ToJson();
                byte[] payload = Encoding.UTF8.GetBytes(json);
                byte[] len = BitConverter.GetBytes(payload.Length);

                await _stream.WriteAsync(len.AsMemory(0, 4));
                await _stream.WriteAsync(payload);
                await _stream.FlushAsync();
            }
            catch
            {
                Dispose();
            }
        }

        /* ================= LISTEN ================= */
        public void Start()
        {
            Task.Run(ListenLoop, _cts.Token);
            Task.Run(PingLoop, _heartbeatCts.Token);
        }
        private async Task ListenLoop()
        {
            Debug.WriteLine($"[LISTEN START] {ConnectionId}");

            try
            {
                while (!_cts.IsCancellationRequested)
                {
                    Packet? packet;

                    try
                    {
                        packet = await ReceiveAsync();
                    }
                    catch (OperationCanceledException)
                    {
                        Debug.WriteLine($"[LISTEN] {ConnectionId} canceled");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[LISTEN ERROR] {ConnectionId}");
                        Debug.WriteLine(ex);
                        break;
                    }

                    // 🔴 REAL disconnect: remote closed socket
                    if (packet == null)
                    {
                        Debug.WriteLine($"[LISTEN] {ConnectionId} stream closed");
                        break;
                    }

                    // ⚠️ Invalid / unparsed packet → ignore
                    if (packet.Type == PacketType.EMPTY)
                    {
                        Debug.WriteLine($"[LISTEN] {ConnectionId} ignored invalid packet");
                        continue;
                    }

                    // ==========================
                    // HEARTBEAT HANDLING
                    // ==========================
                    if (packet.Type == PacketType.PING)
                    {
                        Debug.WriteLine($"[LISTEN] {ConnectionId} ← PING");

                        try
                        {
                            await SendAsync(new PONG_Packet(
                                ((PING_Packet)packet).Timestamp,
                                ConnectionId,      // sender = this connection
                                packet.Sender));  // recipient = ping sender
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"[LISTEN] {ConnectionId} PONG send failed");
                            Debug.WriteLine(ex);
                            break;
                        }

                        continue;
                    }

                    if (packet.Type == PacketType.PONG)
                    {
                        Debug.WriteLine($"[LISTEN] {ConnectionId} ← PONG");
                        _lastPong = DateTime.UtcNow;
                        continue;
                    }

                    // ==========================
                    // NORMAL PACKET DISPATCH
                    // ==========================
                    try
                    {
                        PacketReceived?.Invoke(this, packet);
                    }
                    catch (Exception ex)
                    {
                        // Never kill the connection because of handler bugs
                        Debug.WriteLine($"[LISTEN] {ConnectionId} handler error");
                        Debug.WriteLine(ex);
                    }
                }
            }
            finally
            {
                Debug.WriteLine($"[LISTEN END → DISPOSE] {ConnectionId}");
                Dispose();
            }
        }
        private async Task PingLoop()
        {
            while (!_heartbeatCts.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(_pingInterval, _heartbeatCts.Token);

                    var delta = DateTime.UtcNow - _lastPong;

                    if (delta > _pingInterval * 6)
                    {
                        Debug.WriteLine($"[HEARTBEAT] {ConnectionId} timeout → disconnect");
                        Dispose();
                        return;
                    }

                    if (delta > _pingInterval * 3)
                    {
                        Debug.WriteLine($"[HEARTBEAT] {ConnectionId} delayed pong ({delta.TotalSeconds:F1}s)");
                        continue; // warn but do not disconnect
                    }

                    await SendAsync(new PING_Packet("Server", ConnectionId));
                }
                catch (OperationCanceledException)
                {
                    return;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[HEARTBEAT ERROR] {ConnectionId}: {ex}");
                    Dispose();
                    return;
                }
            }
        }
        private async Task<Packet?> ReceiveAsync()
        {
            try
            {
                byte[] lenBuf = new byte[4];
                int read = await ReadExact(lenBuf, 4);

                if (read == 0)
                {
                    Debug.WriteLine("[RECEIVE] ReadExact(len) returned 0 (remote closed)");
                    return null;
                }

                int size = BitConverter.ToInt32(lenBuf, 0);
                Debug.WriteLine($"[RECEIVE] size = {size}");

                byte[] buf = new byte[size];
                read = await ReadExact(buf, size);

                if (read == 0)
                {
                    Debug.WriteLine("[RECEIVE] ReadExact(payload) returned 0 (remote closed)");
                    return null;
                }

                string json = Encoding.UTF8.GetString(buf);
                Debug.WriteLine("[RECEIVE] json = " + json);

                if (!PacketFactory.TryParse(json, out Packet? packet, out string? error))
                {
                    Debug.WriteLine("[DROP PACKET] " + error);
                    return new EmptyPacket();
                }

                return packet;
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("[RECEIVE] OperationCanceledException");
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[RECEIVE] EXCEPTION: " + ex);
                throw;
            }
        }
        private async Task<int> ReadExact(byte[] buffer, int size)
        {
            int total = 0;
            while (total < size)
            {
                int r = await _stream.ReadAsync(buffer.AsMemory(total, size - total));
                if (r == 0) return 0;
                total += r;
            }
            return total;
        }
        public void Dispose()
        {
            Debug.WriteLine($"[SERVER DISPOSE] {ConnectionId}");

            if (_cts.IsCancellationRequested)
                return;

            _heartbeatCts.Cancel(); // stop heartbeat
            _cts.Cancel();          // stop listen loop

            _stream?.Close();
            _client?.Close();

            Disconnected?.Invoke(this);
        }
    }
}
