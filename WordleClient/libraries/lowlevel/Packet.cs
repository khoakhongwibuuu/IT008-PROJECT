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
        SERVER_SHUTDOWN = 10,
        PING = 11,
        PONG = 12,
        PLAYER_LIST_SYNC = 13,
        JOIN_APPROVAL_REQUEST = 14,
        JOIN_APPROVAL_RESPONSE = 15,

        // Clients send this packet to server when they finished their game (for both win and lose)
        GAME_STATUS_UPDATE_REQUEST = 16,

        // Server broadcasts this packets to all clients
        GAME_STATUS_UPDATE_RESPONSE = 17
    }

    /* ============================================================
     * BASE PACKET
     * ============================================================ */

    public abstract class Packet(PacketType type, string sender, string recipient)
    {
        public PacketType Type { get; init; } = type;
        public string Sender { get; init; } = sender;
        public string Recipient { get; init; } = recipient;

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, GetType());
        }
    }

    /* ============================================================
     * PACKETS POLYMORPHISM
     * ============================================================ */
    public sealed class JOIN_REQUEST_Packet(
        string username, string sender, string recipient)
        : Packet(PacketType.JOIN_REQUEST, sender, recipient)
    {
        public string Username { get; init; } = username;
    }
    public sealed class JOIN_RESPONSE_Packet(
        bool success, string sender, string recipient)
        : Packet(PacketType.JOIN_RESPONSE, sender, recipient)
    {
        public bool Success { get; init; } = success;
    }
    public sealed class START_GAME_Packet(
        int wordLength, string topic, string level,
        int maxAttempts, int gameSeed, int numPlayers,
        string sender, string recipient)
        : Packet(PacketType.START_GAME, sender, recipient)
    {
        public int WordLength { get; init; } = wordLength;
        public string Topic { get; init; } = topic;
        public string Level { get; init; } = level;
        public int MaxAttempts { get; init; } = maxAttempts;
        public int GameSeed { get; init; } = gameSeed;
        public int NumPlayers { get; init; } = numPlayers;
    }
    public sealed class SEND_GUESS_Packet(
        string guess, string sender, string recipient)
        : Packet(PacketType.SEND_GUESS, sender, recipient)
    {
        public string Guess { get; init; } = guess;
    }
    public sealed class SEND_HINT_REQUEST_Packet(
        string playerName, int seed,
        string sender, string recipient)
        : Packet(PacketType.SEND_HINT_REQUEST, sender, recipient)
    {
        public string PlayerName { get; init; } = playerName;
        public int Seed { get; init; } = seed;
    }
    public sealed class HINT_RESPONSE_Packet(
        Hint hint, string sender, string recipient)
        : Packet(PacketType.HINT_RESPONSE, sender, recipient)
    {
        public Hint Hint { get; init; } = hint;
    }
    public sealed class GUESS_RESULT_Packet(
        StateArray sa, string sender, string recipient)
        : Packet(PacketType.GUESS_RESULT, sender, recipient)
    {
        public StateArray SA { get; init; } = sa;
    }
    public sealed class GENERAL_MESSAGE_Packet(
        string message, string sender, string recipient)
        : Packet(PacketType.GENERAL_MESSAGE, sender, recipient)
    {
        public string Message { get; init; } = message;
    }
    public sealed class PLAYER_DISCONNECT_Packet(
        string playerName, string sender, string recipient)
        : Packet(PacketType.PLAYER_DISCONNECT, sender, recipient)
    {
        public string PlayerName { get; init; } = playerName;
    }
    public sealed class SERVER_SHUTDOWN_Packet(
        string sender, string recipient)
        : Packet(PacketType.SERVER_SHUTDOWN, sender, recipient)
    {
    }
    public sealed class PING_Packet(
        string sender, string recipient)
        : Packet(PacketType.PING, sender, recipient)
    {
        public long Timestamp { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
    public sealed class PONG_Packet(
        long timestamp, string sender, string recipient)
        : Packet(PacketType.PONG, sender, recipient)
    {
        public long Timestamp { get; init; } = timestamp;
    }
    public sealed class PLAYER_LIST_SYNC_Packet(
        List<string> players, string sender, string recipient)
        : Packet(PacketType.PLAYER_LIST_SYNC, sender, recipient)
    {
        public List<string> Players { get; init; } = players;
    }
    public sealed class JOIN_APPROVAL_REQUEST_Packet(
        string username, string sender)
        : Packet(PacketType.JOIN_APPROVAL_REQUEST, sender, "Server")
    {
        public string Username { get; init; } = username;
    }
    public sealed class JOIN_APPROVAL_RESPONSE_Packet(
        string username, bool approved, string sender)
        : Packet(PacketType.JOIN_APPROVAL_RESPONSE, sender, username)
    {
        public string Username { get; init; } = username;
        public bool Approved { get; init; } = approved;
    }
    public sealed class GAME_STATUS_UPDATE_REQUEST_Packet(
        string sender, bool iswin)
        : Packet(PacketType.GAME_STATUS_UPDATE_REQUEST, sender, "Server")
    {
        public string Username { get; init; } = sender;
        public bool Iswin { get; init; } = iswin;
    }
    public sealed class GAME_STATUS_UPDATE_RESPONSE_Packet(
        string sender, string recipient)
        : Packet(PacketType.GAME_STATUS_UPDATE_RESPONSE, sender, recipient)
    {
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

                    PacketType.GUESS_RESULT =>
                        JsonSerializer.Deserialize<GUESS_RESULT_Packet>(json),

                    PacketType.GENERAL_MESSAGE =>
                        JsonSerializer.Deserialize<GENERAL_MESSAGE_Packet>(json),

                    PacketType.PLAYER_DISCONNECT =>
                        JsonSerializer.Deserialize<PLAYER_DISCONNECT_Packet>(json),

                    PacketType.SERVER_SHUTDOWN =>
                        JsonSerializer.Deserialize<SERVER_SHUTDOWN_Packet>(json),

                    PacketType.PING =>
                        JsonSerializer.Deserialize<PING_Packet>(json),

                    PacketType.PONG =>
                        JsonSerializer.Deserialize<PONG_Packet>(json),

                    PacketType.PLAYER_LIST_SYNC =>
                        JsonSerializer.Deserialize<PLAYER_LIST_SYNC_Packet>(json),

                    PacketType.JOIN_APPROVAL_REQUEST =>
                        JsonSerializer.Deserialize<JOIN_APPROVAL_REQUEST_Packet>(json),

                    PacketType.JOIN_APPROVAL_RESPONSE =>
                        JsonSerializer.Deserialize<JOIN_APPROVAL_RESPONSE_Packet>(json),

                    PacketType.GAME_STATUS_UPDATE_REQUEST =>
                        JsonSerializer.Deserialize<GAME_STATUS_UPDATE_REQUEST_Packet>(json),

                    PacketType.GAME_STATUS_UPDATE_RESPONSE =>
                        JsonSerializer.Deserialize<GAME_STATUS_UPDATE_RESPONSE_Packet>(json),

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
