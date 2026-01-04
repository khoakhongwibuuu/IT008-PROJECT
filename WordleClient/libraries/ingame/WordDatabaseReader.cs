using Microsoft.Data.Sqlite;
using WordleClient.libraries.lowlevel;
using System.Diagnostics;
namespace WordleClient.libraries.ingame
{
    class WordDatabaseReader
    {
        private
        const int MIN_TOKEN_LENGTH = 4;
        private
        const int MAX_TOKEN_LENGTH = 7;
        private readonly SqliteConnection sql_con;
        public WordDatabaseReader()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(basePath, "database", "words-extended.db");
            string connectionString = $"Data Source={dbPath};Mode=ReadOnly;";
            sql_con = new SqliteConnection(connectionString);
            sql_con.Open();
        }
        public WDBRecord? ReadRandomWord(string? group, string? level)
        {
            string baseQuery = $"FROM SAMPLE_WORD_LIST WHERE (LENGTH(TOKEN) >= {MIN_TOKEN_LENGTH} AND LENGTH(TOKEN) <= {MAX_TOKEN_LENGTH})";
            using SqliteCommand countCmd = sql_con.CreateCommand();
            if (group != null)
            {
                baseQuery += " AND (GROUP_NAME = @group)";
                countCmd.Parameters.AddWithValue("@group", group);
            }
            if (level != null)
            {
                if (level == "EASY") baseQuery += " AND (LEVEL = 'A1' OR LEVEL = 'A2' OR LEVEL = 'B1')";
                else if (level == "HARD") baseQuery += " AND (LEVEL = 'B2' OR LEVEL = 'C1' OR LEVEL = 'C2')";
            }
            countCmd.CommandText = $"SELECT COUNT(*) {baseQuery}";
            int count = Convert.ToInt32(countCmd.ExecuteScalar());
            if (count == 0) return null;
            Random rnd = new();
            int offset = rnd.Next(count);
            using SqliteCommand cmd = sql_con.CreateCommand();
            cmd.CommandText = $"SELECT TOKEN, GROUP_NAME, LEVEL {baseQuery} LIMIT 1 OFFSET @offset";
            cmd.Parameters.AddWithValue("@offset", offset);
            if (group != null) cmd.Parameters.AddWithValue("@group", group);
            using SqliteDataReader reader = cmd.ExecuteReader();
            return reader.Read() ? new WDBRecord
            {
                TOKEN = reader.GetString(0).ToUpper(),
                GROUP_NAME = reader.GetString(1),
                LEVEL = reader.GetString(2),
            } : null;
        }
        public List<string> loadLevels()
        {
            List<string> levels = [];
            using SqliteCommand cmd = sql_con.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT LEVEL FROM SAMPLE_WORD_LIST";
            using SqliteDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read()) levels.Add(reader.GetString(0));
            }
            return levels;
        }
        public List<string> loadGroups()
        {
            List<string> groups = [];
            using SqliteCommand cmd = sql_con.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT GROUP_NAME FROM SAMPLE_WORD_LIST";
            using (SqliteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read()) groups.Add(reader.GetString(0));
            }
            return groups;
        }
        public List<string> loadDistinctTokens(int length)
        {
            List<string> tokens = [];
            using SqliteCommand cmd = sql_con.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT TOKEN FROM SAMPLE_WORD_LIST WHERE LENGTH(TOKEN) = @length";
            cmd.Parameters.AddWithValue("@length", length);
            using (SqliteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read()) tokens.Add(reader.GetString(0));
            }
            return tokens;
        }
        public void Close() => sql_con.Close();
    }
}