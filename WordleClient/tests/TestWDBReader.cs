using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleClient.libraries.ingame;

namespace WordleClient.tests
{
    public class TestWDBReader
    {

        public static void Exec()
        {
            WordDatabaseReader dbr = new WordDatabaseReader();
            string? groupName = "People & Relationships";
            string? level = null;

            var word = dbr.ReadRandomWord(groupName, level);
            if (word != null)
            {
                Debug.WriteLine($"Random word from group '{groupName}' at level '{level}':\n{{\n\ttoken={word.TOKEN},\n\tgroup={word.GROUP_NAME},\n\tlevel={word.LEVEL},\n\tdef={word.DEFINITION}\n}}");
            }
            else
            {
                Debug.WriteLine($"No word found for group '{groupName}' at level '{level}'.");
            }
        }
    }
}
