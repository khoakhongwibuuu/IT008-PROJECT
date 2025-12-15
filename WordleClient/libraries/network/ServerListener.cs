using System.Net;
using System.Net.Sockets;
using System.Text;
using WordleClient.libraries.lowlevel;
using System.Collections.Concurrent;

namespace WordleClient.libraries.network
{
    public class ServerListener
    {
        private TcpListener? listener;
        private CancellationTokenSource? cts;
        private readonly ConcurrentDictionary<TcpClient, string> clients = new();

        public async Task StartAsync(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            cts = new CancellationTokenSource();

            while (!cts.IsCancellationRequested)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                _ = HandleClientAsync(client, cts.Token);
            }
        }

        public void Stop()
        {
            cts?.Cancel();
            listener?.Stop();

            foreach (var client in clients.Keys)
                client.Close();

            clients.Clear();
        }

        private async Task HandleClientAsync(TcpClient client, CancellationToken token)
        {
            clients.TryAdd(client, "unknown");

            try
            {
                using var stream = client.GetStream();
                using var reader = new StreamReader(stream, Encoding.UTF8);
                using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                while (!token.IsCancellationRequested)
                {
                    string? line = await reader.ReadLineAsync();
                    if (line == null) break;

                    if (PacketFactory.TryParse(line, out Packet? packet, out _))
                    {
                        Packet response = HandlePacket(packet!);
                        await writer.WriteLineAsync(response.ToJson());
                    }
                }
            }
            catch
            {
                // client disconnected
            }
            finally
            {
                clients.TryRemove(client, out _);
                client.Close();
            }
        }

        private Packet HandlePacket(Packet packet)
        {
            return packet switch
            {
                JOIN_REQUEST_Packet join =>
                    new JOIN_RESPONSE_Packet(
                        success: true,
                        sender: "server",
                        recipient: join.Sender),

                _ => new GENERAL_MESSAGE_Packet(
                        "Unknown packet",
                        "server",
                        packet.Sender)
            };
        }
    }
}
