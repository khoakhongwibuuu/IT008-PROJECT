using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.ingame
{
    public class GameRoom
    {
        Player host;
        List<Player> clients = new List<Player>();
    }
}
