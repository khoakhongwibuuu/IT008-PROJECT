using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.ingame
{
    class DatabaseReader
    {
        private readonly SQLiteConnection sql_con;

        public DatabaseReader(string connectionString)
        {
            sql_con = new SQLiteConnection(connectionString);
            sql_con.Open();
        }

        public DatabaseRecord? ReadRandomWord(string GROUP_NAME, string LEVEL)
        {
            string query = @"
        SELECT TOKEN, GROUP_NAME, LEVEL, DEFINITION
        FROM SAMPLE_WORD_LIST
        WHERE LEVEL = @level
          AND GROUP_NAME = @group
        ORDER BY RANDOM()
        LIMIT 1;
    ";

            using var command = new SQLiteCommand(query, sql_con);
            command.Parameters.AddWithValue("@level", LEVEL);
            command.Parameters.AddWithValue("@group", GROUP_NAME);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new DatabaseRecord
                {
                    TOKEN = reader["TOKEN"]?.ToString() ?? "",
                    GROUP_NAME = reader["GROUP_NAME"]?.ToString() ?? "",
                    LEVEL = reader["LEVEL"]?.ToString() ?? "",
                    DEFINITION = reader["DEFINITION"]?.ToString() ?? ""
                };
            }

            return null;
        }

        public void Close() => sql_con.Close();
    } 
}
