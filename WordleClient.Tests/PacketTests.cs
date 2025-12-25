using System;
using WordleClient.libraries.lowlevel;
using Xunit;

namespace WordleClient.Tests
{
    public class PacketTests
    {
        /* ============================================================
         * SERIALIZATION / DESERIALIZATION SUCCESS CASES
         * ============================================================ */

        [Fact]
        public void JoinRequest_RoundTrip_Succeeds()
        {
            var packet = new JOIN_REQUEST_Packet(
                username: "Alice",
                sender: "client",
                recipient: "server");

            string json = packet.ToJson();

            bool ok = PacketFactory.TryParse(json, out Packet? parsed, out string? error);

            Assert.True(ok);
            Assert.Null(error);
            Assert.NotNull(parsed);

            var join = Assert.IsType<JOIN_REQUEST_Packet>(parsed);
            Assert.Equal("Alice", join.Username);
        }

        [Fact]
        public void StartGame_RoundTrip_Succeeds()
        {
            var packet = new START_GAME_Packet(
                wordLength: 5,
                topic: "Animals",
                level: "Easy",
                maxAttempts: 6,
                gameSeed: 1,
                numPlayers: 3,
                sender: "server",
                recipient: "client"
            );

            string json = packet.ToJson();

            bool ok = PacketFactory.TryParse(json, out Packet? parsed, out _);

            var start = Assert.IsType<START_GAME_Packet>(parsed);
            Assert.Equal(5, start.WordLength);
            Assert.Equal("Animals", start.Topic);
            Assert.Equal("Easy", start.Level);
            Assert.Equal(6, start.MaxAttempts);
        }

        [Fact]
        public void GeneralMessage_RoundTrip_Succeeds()
        {
            var packet = new GENERAL_MESSAGE_Packet(
                message: "Hello world",
                sender: "server",
                recipient: "client");

            string json = packet.ToJson();

            bool ok = PacketFactory.TryParse(json, out Packet? parsed, out _);

            var msg = Assert.IsType<GENERAL_MESSAGE_Packet>(parsed);
            Assert.Equal("Hello world", msg.Message);
        }

        [Fact]
        public void PlayerDisconnect_RoundTrip_Succeeds()
        {
            var packet = new PLAYER_DISCONNECT_Packet(
                playerName: "Bob",
                sender: "server",
                recipient: "all");

            string json = packet.ToJson();

            bool ok = PacketFactory.TryParse(json, out Packet? parsed, out _);

            var dc = Assert.IsType<PLAYER_DISCONNECT_Packet>(parsed);
            Assert.Equal("Bob", dc.PlayerName);
        }

        [Fact]
        public void ServerShutdown_RoundTrip_Succeeds()
        {
            var packet = new SERVER_SHUTDOWN_Packet(
                sender: "server",
                recipient: "all");

            string json = packet.ToJson();

            bool ok = PacketFactory.TryParse(json, out Packet? parsed, out _);

            Assert.IsType<SERVER_SHUTDOWN_Packet>(parsed);
        }

        /* ============================================================
         * HINT PACKET
         * ============================================================ */

        [Fact]
        public void HintResponse_RoundTrip_Succeeds()
        {
            var hint = new Hint(HintType.Present, 'A');
            var packet = new HINT_RESPONSE_Packet(
                hint,
                sender: "server",
                recipient: "client");

            string json = packet.ToJson();

            bool ok = PacketFactory.TryParse(json, out Packet? parsed, out _);

            var parsedHint = Assert.IsType<HINT_RESPONSE_Packet>(parsed);
            Assert.Equal(HintType.Present, parsedHint.Hint.h_type);
            Assert.Equal('A', parsedHint.Hint.pre_letter);
            Assert.Null(parsedHint.Hint.abs_type);
        }

        /* ============================================================
         * VALIDATION / ERROR HANDLING
         * ============================================================ */

        [Fact]
        public void TryParse_InvalidJson_Fails()
        {
            string json = "{ this is not valid json ";

            bool ok = PacketFactory.TryParse(json, out Packet? packet, out string? error);

            Assert.False(ok);
            Assert.Null(packet);
            Assert.NotNull(error);
        }

        [Fact]
        public void TryParse_MissingType_Fails()
        {
            string json = """
            {
                "Sender": "a",
                "Recipient": "b"
            }
            """;

            bool ok = PacketFactory.TryParse(json, out Packet? packet, out string? error);

            Assert.False(ok);
            Assert.Null(packet);
            Assert.Equal("Missing packet type", error);
        }

        [Fact]
        public void TryParse_UnknownType_Fails()
        {
            string json = """
            {
                "Type": 999,
                "Sender": "a",
                "Recipient": "b"
            }
            """;

            bool ok = PacketFactory.TryParse(json, out Packet? packet, out string? error);

            Assert.False(ok);
            Assert.Null(packet);
            Assert.Contains("Unsupported", error);
        }
    }
}
