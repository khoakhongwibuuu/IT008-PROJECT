using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleClient.libraries.CustomControls;

namespace WordleClient.libraries.ingame
{
    public static class Animation
    {
        public static async Task FlipBox(CharBox box)
        {
            int steps = 5;
            for (int i = 0; i < steps; i++) { box.Height -= 5; box.Top += 2; await Task.Delay(10); }
            for (int i = 0; i < steps; i++) { box.Height += 5; box.Top -= 2; await Task.Delay(10); }
        }
    }
}
