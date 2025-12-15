using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WordleClient.libraries.lowlevel
{
    /* ============================================================
     * ENUMS
     * ============================================================ */

    public enum PacketType
    {
        UNKNOWN = 0,
        JOIN_REQUEST = 1,
        JOIN_RESPONSE = 2,
        START_GAME = 3,
        SEND_GUESS = 4,
        GUESS_RESULT = 5,
        SEND_HINT_REQUEST = 6,
        HINT_RESPONSE = 7,
        GENERAL_MESSAGE = 8,
        PLAYER_DISCONNECT = 9,
        SERVER_SHUTDOWN = 10
    }

    /* ============================================================
     * BASE PACKET
     * ============================================================ */

    public abstract class Packet
    {
        public PacketType Type { get; init; }
        public string Sender { get; init; }
        public string Recipient { get; init; }

        protected Packet(PacketType type, string sender, string recipient)
        {
            Type = type;
            Sender = sender;
            Recipient = recipient;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, GetType());
        }
    }

    /* ============================================================
     * PACKETS
     * ============================================================ */

    public sealed class JOIN_REQUEST_Packet : Packet
    {
        public string Username { get; init; }

        public JOIN_REQUEST_Packet(string username, string sender, string recipient)
            : base(PacketType.JOIN_REQUEST, sender, recipient)
        {
            Username = username;
        }
    }

    public sealed class JOIN_RESPONSE_Packet : Packet
    {
        public bool Success { get; init; }

        public JOIN_RESPONSE_Packet(bool success, string sender, string recipient)
            : base(PacketType.JOIN_RESPONSE, sender, recipient)
        {
            Success = success;
        }
    }

    public sealed class START_GAME_Packet : Packet
    {
        public int WordLength { get; init; }
        public string Topic { get; init; }
        public string Level { get; init; }
        public int MaxAttempts { get; init; }

        public START_GAME_Packet(
            int wordLength, string topic, string level, int maxAttempts,
            string sender, string recipient)
            : base(PacketType.START_GAME, sender, recipient)
        {
            WordLength = wordLength;
            Topic = topic;
            Level = level;
            MaxAttempts = maxAttempts;
        }
    }

    public sealed class SEND_GUESS_Packet : Packet
    {
        public string Guess { get; init; }

        public SEND_GUESS_Packet(string guess, string sender, string recipient)
            : base(PacketType.SEND_GUESS, sender, recipient)
        {
            Guess = guess;
        }
    }

    public sealed class SEND_HINT_REQUEST_Packet : Packet
    {
        public string PlayerName { get; init; }
        public int Seed { get; init; }

        public SEND_HINT_REQUEST_Packet(string playerName, int seed,
            string sender, string recipient)
            : base(PacketType.SEND_HINT_REQUEST, sender, recipient)
        {
            PlayerName = playerName;
            Seed = seed;
        }
    }

    public sealed class HINT_RESPONSE_Packet : Packet
    {
        public Hint Hint { get; init; }

        public HINT_RESPONSE_Packet(Hint hint, string sender, string recipient)
            : base(PacketType.HINT_RESPONSE, sender, recipient)
        {
            Hint = hint;
        }
    }

    public sealed class GENERAL_MESSAGE_Packet : Packet
    {
        public string Message { get; init; }

        public GENERAL_MESSAGE_Packet(string message, string sender, string recipient)
            : base(PacketType.GENERAL_MESSAGE, sender, recipient)
        {
            Message = message;
        }
    }

    public sealed class PLAYER_DISCONNECT_Packet : Packet
    {
        public string PlayerName { get; init; }

        public PLAYER_DISCONNECT_Packet(string playerName, string sender, string recipient)
            : base(PacketType.PLAYER_DISCONNECT, sender, recipient)
        {
            PlayerName = playerName;
        }
    }

    public sealed class SERVER_SHUTDOWN_Packet : Packet
    {
        public SERVER_SHUTDOWN_Packet(string sender, string recipient)
            : base(PacketType.SERVER_SHUTDOWN, sender, recipient)
        {
        }
    }

    /* ============================================================
     * PACKET FACTORY (SAFE)
     * ============================================================ */

    public static class PacketFactory
    {
        public static bool TryParse(
            string json,
            out Packet? packet,
            out string? error)
        {
            packet = null;
            error = null;

            try
            {
                using JsonDocument doc = JsonDocument.Parse(json);

                if (!doc.RootElement.TryGetProperty("Type", out var typeProp))
                {
                    error = "Missing packet type";
                    return false;
                }

                PacketType type = (PacketType)typeProp.GetInt32();

                packet = type switch
                {
                    PacketType.JOIN_REQUEST =>
                        JsonSerializer.Deserialize<JOIN_REQUEST_Packet>(json),

                    PacketType.JOIN_RESPONSE =>
                        JsonSerializer.Deserialize<JOIN_RESPONSE_Packet>(json),

                    PacketType.START_GAME =>
                        JsonSerializer.Deserialize<START_GAME_Packet>(json),

                    PacketType.SEND_GUESS =>
                        JsonSerializer.Deserialize<SEND_GUESS_Packet>(json),

                    PacketType.SEND_HINT_REQUEST =>
                        JsonSerializer.Deserialize<SEND_HINT_REQUEST_Packet>(json),

                    PacketType.HINT_RESPONSE =>
                        JsonSerializer.Deserialize<HINT_RESPONSE_Packet>(json),

                    PacketType.GENERAL_MESSAGE =>
                        JsonSerializer.Deserialize<GENERAL_MESSAGE_Packet>(json),

                    PacketType.PLAYER_DISCONNECT =>
                        JsonSerializer.Deserialize<PLAYER_DISCONNECT_Packet>(json),

                    PacketType.SERVER_SHUTDOWN =>
                        JsonSerializer.Deserialize<SERVER_SHUTDOWN_Packet>(json),

                    _ => null
                };

                if (packet is null)
                {
                    error = $"Unsupported or invalid packet type: {type}";
                    return false;
                }

                return true;
            }
            catch (JsonException ex)
            {
                error = "Invalid JSON: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                error = "Packet error: " + ex.Message;
                return false;
            }
        }
    }
}
