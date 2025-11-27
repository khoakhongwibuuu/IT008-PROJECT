namespace WordleClient.libraries.lowlevel
{
    public class SingleplayerPlayLog
    {
        public long Timestamp { get; set; } = 0L;
        public string Token { get; set; } = "";
        public string Group { get; set; } = "";
        public bool IsSolved { get; set; } = false;
        public int MaxAttempts { get; set; } = 0;
        public int UsedAttempts { get; set; } = 0;

        public SingleplayerPlayLog(long timestamp, string token, string group, bool isSolved, int maxAttempts, int usedAttempts)
        {
            Timestamp = timestamp;
            Token = token;
            Group = group;
            IsSolved = isSolved;
            MaxAttempts = maxAttempts;
            UsedAttempts = usedAttempts;
        }
    }
}
