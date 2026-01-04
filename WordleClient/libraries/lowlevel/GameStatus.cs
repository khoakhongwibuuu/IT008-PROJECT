namespace WordleClient.libraries.lowlevel
{
    public class GameStatus
    {
        public string Username
        {
            get;
            set;
        }
        public bool IsWin
        {
            get;
            set;
        }
        public GameStatus(string username, bool isWin)
        {
            Username = username;
            IsWin = isWin;
        }
    }
}
