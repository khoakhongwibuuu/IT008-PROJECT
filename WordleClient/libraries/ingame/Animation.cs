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
        public static async Task HeartAnimation(PictureBox heart)
        {
            if (heart == null) return;
            int originalW = heart.Width;
            int originalH = heart.Height;

            int beatW = originalW + 4;
            int beatH = originalH + 4;

            heart.Size = new Size(beatW, beatH);
            heart.Location = new Point(heart.Location.X - 2, heart.Location.Y - 2);
            await Task.Delay(120);
            heart.Size = new Size(originalW, originalH);
            heart.Location = new Point(heart.Location.X + 2, heart.Location.Y + 2);
            await Task.Delay(120);
        }
        public static async Task FlipBox(CharBox box)
        {
            int steps = 5;
            for (int i = 0; i < steps; i++) { box.Height -= 5; box.Top += 2; await Task.Delay(10); }
            for (int i = 0; i < steps; i++) { box.Height += 5; box.Top -= 2; await Task.Delay(10); }
        }
    }
}
