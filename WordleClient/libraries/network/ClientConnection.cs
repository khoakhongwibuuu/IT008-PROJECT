using System.Net.Sockets;
using System.Text;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.network
{
    public class ClientConnection
    {
        private TcpClient? client;
        private StreamReader? reader;
        private StreamWriter? writer;
        private CancellationTokenSource? cts;

        public bool IsConnected => client?.Connected == true;

        public event Action<Packet>? PacketReceived;
        public event Action? Disconnected;

        public async Task ConnectAsync(string ip, int port)
        {
            Disconnect();

            client = new TcpClient();
            await client.ConnectAsync(ip, port);

            NetworkStream stream = client.GetStream();
            reader = new StreamReader(stream, Encoding.UTF8);
            writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

            cts = new CancellationTokenSource();
            _ = ListenLoopAsync(cts.Token);
        }

        public async Task SendAsync(Packet packet)
        {
            if (writer == null)
                throw new InvalidOperationException("Not connected");

            await writer.WriteLineAsync(packet.ToJson());
        }

        public void Disconnect()
        {
            try
            {
                cts?.Cancel();
                client?.Close();
            }
            finally
            {
                client = null;
                reader = null;
                writer = null;
                cts = null;
                Disconnected?.Invoke();
            }
        }

        private async Task ListenLoopAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    string? line = await reader!.ReadLineAsync();
                    if (line == null) break;

                    if (PacketFactory.TryParse(line, out Packet? packet, out _))
                    {
                        PacketReceived?.Invoke(packet!);
                    }
                }
            }
            catch
            {
                // ignored (disconnect)
            }
            finally
            {
                Disconnect();
            }
        }
        public async Task<bool> TryConnectAsync(string ip, int port, int timeoutMs = 1500)
        {
            using var probe = new TcpClient();

            var connectTask = probe.ConnectAsync(ip, port);
            var timeoutTask = Task.Delay(timeoutMs);

            var completed = await Task.WhenAny(connectTask, timeoutTask);

            return completed == connectTask && probe.Connected;
        }

    }
}
