using System.Data.SqlClient;

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
            string ConnectionString = $"Data Source={dbPath};Read Only=True;Version=3;";

            using (SqlConnection connection = new(ConnectionString))
            using (SqlCommand command = new($"SELECT TOKEN FROM DICTIONARY_LENGTH_{TOKEN_SIZE}", connection))
            {
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();
                {
                    while (reader.Read())
                        list.Add(reader.GetString(0));
                }
            }

            _tokens = new HashSet<string>(list, StringComparer.OrdinalIgnoreCase);
        }
        public bool TokenExists(string TOKEN)
        {
            return _tokens.Contains(TOKEN);
        }
    }
}
