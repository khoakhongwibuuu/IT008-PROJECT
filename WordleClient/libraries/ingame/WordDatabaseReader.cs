using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.ingame
{
    class WordDatabaseReader
    {
        private readonly SQLiteConnection sql_con;

        public WordDatabaseReader()
        {
            string dbPath = Path.Combine(Environment.CurrentDirectory, "database", "words.db");
            string ConnectionString = $"Data Source={dbPath};Read Only=True;Version=3;";
            sql_con = new SQLiteConnection(ConnectionString);
            sql_con.Open();
        }

        public WDBRecord? ReadRandomWord(string? group, string? level)
        {
            string baseQuery = "FROM SAMPLE_WORD_LIST WHERE 0=0";
            using var countCmd = new SQLiteCommand(sql_con);

            if (group != null)
            {
                baseQuery += " AND GROUP_NAME = @group";
                countCmd.Parameters.AddWithValue("@group", group);
            }
            if (level != null)
            {
                baseQuery += " AND LEVEL = @level";
                countCmd.Parameters.AddWithValue("@level", level);
            }

            countCmd.CommandText = $"SELECT COUNT(*) {baseQuery}";
            int count = Convert.ToInt32(countCmd.ExecuteScalar());

            if (count == 0) return null;

            var rnd = new Random();
            int offset = rnd.Next(count);

            using var cmd = new SQLiteCommand(
                $"SELECT TOKEN, GROUP_NAME, LEVEL, DEFINITION {baseQuery} LIMIT 1 OFFSET @offset",
                sql_con);

            cmd.Parameters.AddWithValue("@offset", offset);
            if (group != null) cmd.Parameters.AddWithValue("@group", group);
            if (level != null) cmd.Parameters.AddWithValue("@level", level);

            using var reader = cmd.ExecuteReader();
            return reader.Read()
                ? new WDBRecord
                {
                    TOKEN = reader.GetString(0),
                    GROUP_NAME = reader.GetString(1),
                    LEVEL = reader.GetString(2),
                    DEFINITION = reader.GetString(3)
                }
                : null;
        }


        public void Close() => sql_con.Close();
    }
}
