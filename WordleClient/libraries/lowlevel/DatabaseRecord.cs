using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleClient.libraries.lowlevel
{
    public class DatabaseRecord
    {
        public string TOKEN { get; set; } = "";
        public string GROUP_NAME { get; set; } = "";
        public string LEVEL { get; set; } = "";
        public string DEFINITION { get; set; } = "";
    }
}
