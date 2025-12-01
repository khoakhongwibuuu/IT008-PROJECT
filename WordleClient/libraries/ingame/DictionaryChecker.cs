using Microsoft.Data.Sqlite;
using System.Diagnostics;

namespace WordleClient.libraries.ingame
{
    class DictionaryChecker
    {
        private readonly HashSet<string> _tokens;
        public DictionaryChecker(int TOKEN_SIZE)
        {
            List<string> list = [];
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(basePath, "database", "dictionary.db");
            string connectionString = $"Data Source={dbPath};Mode=ReadOnly;";
            using (SqliteConnection connection = new(connectionString))
            {
                connection.Open();
                using SqliteCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT TOKEN FROM DICTIONARY_LENGTH_{TOKEN_SIZE}";

                using SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                connection.Close();
            }

            Debug.WriteLine($"Loaded {list.Count} tokens of length {TOKEN_SIZE} from database.");
            _tokens = new HashSet<string>(list, StringComparer.OrdinalIgnoreCase);
        }
        public bool TokenExists(string TOKEN)
        {
            return _tokens.Contains(TOKEN);
        }
        public void Dispose()
        {
            _tokens.Clear();
        }
    }
}
