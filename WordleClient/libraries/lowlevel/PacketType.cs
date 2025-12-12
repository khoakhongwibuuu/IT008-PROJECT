using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
