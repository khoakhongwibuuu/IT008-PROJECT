using System.Data.SQLite;
using WordleClient.libraries.lowlevel;
using System.Diagnostics;

namespace WordleClient.libraries.ingame
{
    class WordDatabaseReader
    {
        private readonly SQLiteConnection sql_con;
        public WordDatabaseReader()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(basePath, "database", "words.db");
            string ConnectionString = $"Data Source={dbPath};Read Only=True;Version=3;";
            sql_con = new SQLiteConnection(ConnectionString);
            sql_con.Open();
        }
        public WDBRecord? ReadRandomWord(string? group, string? level)
        {
            Debug.WriteLine($"DB_READER_OUTPUT: Taken group={group} and level={level}");
            string baseQuery = "FROM SAMPLE_WORD_LIST WHERE (LENGTH(TOKEN) >= 4 AND LENGTH(TOKEN) <= 8)";
            using var countCmd = new SQLiteCommand(sql_con);

            if (group != null)
            {
                baseQuery += " AND (GROUP_NAME = @group)";
                countCmd.Parameters.AddWithValue("@group", group);
            }
            if (level != null)
            {
                if (level == "EASY")
                {
                    baseQuery += " AND (LEVEL = 'A1' OR LEVEL = 'A2' OR LEVEL = 'B1')";
                }
                else if (level == "HARD")
                {
                    baseQuery += " AND (LEVEL = 'B2' OR LEVEL = 'C1' OR LEVEL = 'C2')";
                }
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
        public List<string> loadLevels()
        {
            List<string> levels = new List<string>();
            using var cmd = new SQLiteCommand("SELECT DISTINCT LEVEL FROM SAMPLE_WORD_LIST", sql_con);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                levels.Add(reader.GetString(0));
            }
            return levels;
        }
        public List<string> loadGroups()
        {
            List<string> groups = new List<string>();
            using var cmd = new SQLiteCommand("SELECT DISTINCT GROUP_NAME FROM SAMPLE_WORD_LIST", sql_con);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                groups.Add(reader.GetString(0));
            }
            return groups;
        }
        public List<string> loadDistinctTokens(int length)
        {
            List<string> tokens = new List<string>();
            string QUERY = $"SELECT DISTINCT TOKEN FROM SAMPLE_WORD_LIST WHERE (LENGTH(TOKEN) = {length})";
            using var cmd = new SQLiteCommand(QUERY, sql_con);
            using var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                tokens.Add(reader.GetString(0));
            }
            return tokens;
        }   

        public void Close() => sql_con.Close();
    }
}
