using Microsoft.Data.Sqlite;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.ingame
{
    public class SingleplayerLogger
    {
        private readonly SqliteConnection sql_con;

        public SingleplayerLogger()
        {
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string basePath = Path.Combine(localAppData, "WordleClient");
            string userDataDir = Path.Combine(basePath, "userdata");
            string dbPath = Path.Combine(userDataDir, "singleplayer-log.db");

            // Ensure the directory exists
            if (!Directory.Exists(userDataDir))
            {
                Directory.CreateDirectory(userDataDir);
            }

            // Create the database file with the TABLE if it doesn't exist
            if (!File.Exists(dbPath))
            {
                string tempConnectionString = $"Data Source={dbPath}";
                using (SqliteConnection tempConnection = new(tempConnectionString))
                {
                    tempConnection.Open();
                    string createTableSql =
                    @"
                        CREATE TABLE SINGLEPLAYER_PLAYLOG (
	                        TIMESTAMP	INTEGER NOT NULL,
	                        TOKEN	    TEXT NOT NULL,
	                        TOPIC	    TEXT NOT NULL,
	                        IS_SOLVED	INTEGER NOT NULL,
	                        MAX_ATTEMPTS_ALLOWED	INTEGER NOT NULL,
	                        USED_ATTEMPTS	INTEGER NOT NULL,
	                        PRIMARY KEY(TIMESTAMP,TOKEN,TOPIC)
                        );
                    ";
                    using (SqliteCommand command = tempConnection.CreateCommand())
                    {
                        command.CommandText = createTableSql;
                        command.ExecuteNonQuery();
                    }
                    tempConnection.Close();
                }
            }

            // Database connection initialise
            string connectionString = $"Data Source={dbPath};Mode=ReadWriteCreate;";
            sql_con = new SqliteConnection(connectionString);
            sql_con.Open();
        }
        public void SaveToDatabase(SingleplayerPlayLog SPL)
        {
            using (SqliteCommand cmd = sql_con.CreateCommand())
            {
                cmd.CommandText = @"
                INSERT INTO SINGLEPLAYER_PLAYLOG 
                (TIMESTAMP, TOKEN, TOPIC, IS_SOLVED, MAX_ATTEMPTS_ALLOWED, USED_ATTEMPTS) 
                VALUES 
                (@timestamp, @token, @topic, @is_solved, @max_attempts_allowed, @used_attempts);";

                cmd.Parameters.AddWithValue("@timestamp", SPL.Timestamp);
                cmd.Parameters.AddWithValue("@token", SPL.Token);
                cmd.Parameters.AddWithValue("@topic", SPL.Group);
                cmd.Parameters.AddWithValue("@is_solved", SPL.IsSolved ? 1 : 0);
                cmd.Parameters.AddWithValue("@max_attempts_allowed", SPL.MaxAttempts);
                cmd.Parameters.AddWithValue("@used_attempts", SPL.UsedAttempts);

                cmd.ExecuteNonQuery();
            }
        }
        public List<SingleplayerPlayLog> LoadFromDatabase()
        {
            List<SingleplayerPlayLog> playLogs = [];

            using (SqliteCommand cmd = sql_con.CreateCommand())
            {
                cmd.CommandText = "SELECT TIMESTAMP, TOKEN, TOPIC, IS_SOLVED, MAX_ATTEMPTS_ALLOWED, USED_ATTEMPTS FROM SINGLEPLAYER_PLAYLOG;";
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long timestamp = reader.GetInt64(0);
                        string token = reader.GetString(1);
                        string group = reader.GetString(2);
                        bool isSolved = reader.GetInt32(3) != 0;
                        int maxAttempts = reader.GetInt32(4);
                        int usedAttempts = reader.GetInt32(5);
                        SingleplayerPlayLog playLog = new(timestamp, token, group, isSolved, maxAttempts, usedAttempts);
                        playLogs.Add(playLog);
                    }
                }
            }
            return playLogs;
        }
        public void ClearDatabase()
        {
            using var cmd = sql_con.CreateCommand();
            cmd.CommandText = "DELETE FROM SINGLEPLAYER_PLAYLOG;";
            cmd.ExecuteNonQuery();
        }
        public void Close()
        {
            sql_con.Close();
        }
    }
}
