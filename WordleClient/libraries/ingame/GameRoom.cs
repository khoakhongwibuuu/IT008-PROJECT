using WordleClient.libraries.lowlevel;
namespace WordleClient.libraries.ingame
{
    public static class GameRoom
    {
        private
        const int MaxPlayers = 4;
        private static Player? host;
        private static readonly List<Player> clients = new();
        public static bool HasSpace => host != null && clients.Count + 1 < MaxPlayers;
        public static Player? Host => host;
        public static void SetHost(Player player)
        {
            host = player;
        }
        public static bool AddClient(Player player)
        {
            if (!HasSpace) return false;
            clients.Add(player);
            return true;
        }
        public static bool RemoveClient(Player player)
        {
            return clients.Remove(player);
        }
        public static List<Player> AllPlayers
        {
            get
            {
                var list = new List<Player>();
                if (host != null) list.Add(host);
                list.AddRange(clients);
                return list;
            }
        }
        public static Player? GetPlayerByIP(string ip)
        {
            return AllPlayers.FirstOrDefault(p => p.IPAddress == ip);
        }
        public static Player? GetPlayerByUsername(string username)
        {
            return AllPlayers.FirstOrDefault(p => p.Username == username);
        }
        public static List<string> SerializePlayers()
        {
            return AllPlayers.Select(p => p.Serialize()).ToList();
        }
        public static void Dispose()
        {
            host = null;
            clients.Clear();
        }
    }
}