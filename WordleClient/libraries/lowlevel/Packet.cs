
namespace WordleClient.libraries.lowlevel
{
    public enum PacketType
    {
        UNKNOWN = 0,
        JOIN_REQUEST = 1,
        JOIN_RESPONSE = 2,
        START_GAME = 3,
        SEND_GUESS = 4,
        GUESS_RESULT = 5,
        STATUS_UPDATE = 6,
        PLAYER_DISCONNECT = 7,
        SERVER_SHUTDOWN = 8
    }
    public class Packet
    {
        private PacketType type;
        private string sender;
        private string recipient;
        private string data;
        public Packet(PacketType type, string sender, string recipient, string data)
        {
            this.type = type;
            this.sender = sender;
            this.recipient = recipient;
            this.data = data;
        }
        public string GetData()
        {
            return data;
        }
        public string GetSender()
        {
            return sender;
        }
        public string GetRecipient()
        {
            return recipient;
        }
        public PacketType GetPacketType()
        {
            return type;
        }
        public string Serialize()
        {
            return $"{(int)type}|{sender}|{recipient}|{data}";
        }
        public Packet Parse(string data)
        {
            string[] parts = data.Split('|');
            PacketType type = (PacketType)int.Parse(parts[0]);
            string sender = parts[1];
            string recipient = parts[2];
            string packetData = parts[3];
            return new Packet(type, sender, recipient, packetData);
        }
    }
}
