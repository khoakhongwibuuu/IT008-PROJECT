using System;
using System.Diagnostics;

//using System.Diagnostics;
using System.Net.Sockets;
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
            Task.Run(PingLoop, _cts.Token);
        }
        //private async Task ListenLoop()
        //{
        //    try
        //    {
        //        while (!_cts.IsCancellationRequested)
        //        {
        //            Packet? packet = await ReceiveAsync();
        //            if (packet == null) break;

        //            if (packet.Type == PacketType.PING)
        //            {
        //                var ping = (PING_Packet)packet;
        //                await SendAsync(new PONG_Packet(
        //                    ping.Timestamp, "Server", packet.Sender));
        //                continue;
        //            }

        //            if (packet.Type == PacketType.PONG)
        //            {
        //                _lastPong = DateTime.UtcNow;
        //                continue;
        //            }

        //            PacketReceived?.Invoke(this, packet);
        //        }
        //    }
        //    finally
        //    {
        //        Dispose();
        //    }
        //}
        private async Task ListenLoop()
        {
            try
            {
                while (!_cts.IsCancellationRequested)
                {
                    Packet? packet = await ReceiveAsync();

                    if (packet == null)
                    {
                        Debug.WriteLine("[LISTEN] packet == null → breaking loop");
                        break;
                    }

                    if (packet.Type == PacketType.UNKNOWN)
                    {
                        continue; // skip invalid / unparsed packet
                    }

                    if (packet.Type == PacketType.PING)
                    {
                        var ping = (PING_Packet)packet;
                        await SendAsync(new PONG_Packet(
                            ping.Timestamp, "Server", packet.Sender));
                        continue;
                    }

                    if (packet.Type == PacketType.PONG)
                    {
                        _lastPong = DateTime.UtcNow;
                        continue;
                    }

                    PacketReceived?.Invoke(this, packet);
                }
            }
            finally
            {
                Dispose();
            }
        }

        private async Task PingLoop()
        {
            while (!_cts.IsCancellationRequested)
            {
                await Task.Delay(_pingInterval, _cts.Token);

                if (DateTime.UtcNow - _lastPong > _pingInterval * 3)
                {
                    Dispose();
                    return;
                }

                await SendAsync(new PING_Packet("Server", ConnectionId));
            }
        }
        //private async Task<Packet?> ReceiveAsync()
        //{
        //    byte[] lenBuf = new byte[4];
        //    int read = await ReadExact(lenBuf, 4);
        //    if (read == 0) return null;

        //    int size = BitConverter.ToInt32(lenBuf, 0);
        //    byte[] buf = new byte[size];
        //    await ReadExact(buf, size);

        //    string json = Encoding.UTF8.GetString(buf);

        //    if (!PacketFactory.TryParse(json, out Packet? packet, out string? error))
        //    {
        //        return null;
        //    }

        //    return packet;
        //}
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
            if (_cts.IsCancellationRequested) return;

            _cts.Cancel();
            _stream?.Close();
            _client?.Close();
            Disconnected?.Invoke(this);
        }
    }
}
