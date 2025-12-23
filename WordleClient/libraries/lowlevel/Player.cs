namespace WordleClient.libraries.lowlevel
{
    public class Player(string username, string ipAddress)
    {
        public string Username { get; set; } = username;
        public string IPAddress { get; set; } = ipAddress;

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
