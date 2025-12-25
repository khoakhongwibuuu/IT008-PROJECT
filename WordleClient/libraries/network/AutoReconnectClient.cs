using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WordleClient.libraries.network
{
    public static class AutoReconnectClient
    {
        private static string _host;
        private static int _port;
        private static bool _enabled = true;

        public static async Task StartAsync(string host, int port)
        {
            _host = host;
            _port = port;
            await TryConnect();
        }
        private static async Task TryConnect()
        {
            while (_enabled)
            {
                try
                {
                    TcpClient client = new();
                    await client.ConnectAsync(_host, _port);
                    PacketConnectionManager.Attach(client);
                    return;
                }
                catch
                {
                    await Task.Delay(3000);
                }
            }
        }
    }
}
