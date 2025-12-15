namespace WordleClient.libraries.lowlevel
{
    public class Player
    {
        public string Username { get; set; }
        public string IPAddress { get; set; }
        public Player(string username, string ipAddress)
        {
            Username = username;
            IPAddress = ipAddress;
        }
        public string Serialize()
        {
            return $"{Username}|{IPAddress}";
        }
        public static Player Parse(string data)
        {
            string[] parts = data.Split('|');
            return new Player(parts[0], parts[1]);
        }
    }
}

