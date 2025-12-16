namespace WordleClient.libraries.lowlevel
{
    public class SinglePlayAnalytic
    {
        public int playCount = 0;
        public int winCount = 0;
        public int currentStreak = 0;
        public int maxStreak = 0;
        public double winRate = 0.0;
        public double averageAttempts = 0.0;
        public SinglePlayAnalytic(int playCount, int winCount, int currentStreak, int maxStreak, double winRate, double averageAttempts)
        {
            this.playCount = playCount;
            this.winCount = winCount;
            this.currentStreak = currentStreak;
            this.maxStreak = maxStreak;
            this.winRate = winRate;
            this.averageAttempts = averageAttempts;
        }
        public SinglePlayAnalytic()
        {
        }
    }
}
