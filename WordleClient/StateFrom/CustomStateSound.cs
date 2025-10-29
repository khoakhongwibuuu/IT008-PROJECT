using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WordleClient.StateFrom
{
    public static class CustomStateSound
    {
        public static bool IsMuted
        {
            get;
            private set;
        } = false;
        public static void Toggle()
        {
            IsMuted = !IsMuted;
        }
        public static void Set(bool muted)
        {
            IsMuted = muted;
        }
    }
}
