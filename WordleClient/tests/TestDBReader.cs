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
    public class TestDBReader
    {

        public static void Exec()
        {
            string dbPath = Path.Combine(Environment.CurrentDirectory, "database", "words.db");
            string ConnectionString = $"Data Source={dbPath};Read Only=True;Version=3;";

            DatabaseReader dbr = new DatabaseReader(ConnectionString);
            string groupName = "Cooking";
            string level = "A2";

            var word = dbr.ReadRandomWord(groupName, level);
            if (word != null)
            {
                Debug.WriteLine($"Random word from group '{groupName}' at level '{level}': {word.TOKEN} - {word.DEFINITION}");
            }
            else
            {
                Debug.WriteLine($"No word found for group '{groupName}' at level '{level}'.");
            }
        }
    }
}
