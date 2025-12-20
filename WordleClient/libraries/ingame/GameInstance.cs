using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.ingame
{
    public class GameInstance
    {
        private static readonly Random _rand = new();

        // GI Params
        private readonly WDBRecord targetRecord;

        public GameInstance(WDBRecord targetRecord)
        {
            WordDatabaseReader wdr = new();
            this.targetRecord = targetRecord;
            wdr.Close();
        }
        public GameInstance(string testWord)
        {
            this.targetRecord = new WDBRecord { TOKEN = testWord, GROUP_NAME = "undefined" };
        }
        public StateArray EvaluateGuess(string guess)
        {
            if (guess.Length != targetRecord.TOKEN.Length)
                throw new ArgumentException("Guess length does not match target word length.");
            StateArray result = new(guess.Length);
            bool[] targetMatched = new bool[targetRecord.TOKEN.Length];

            // First pass: check for matches
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == targetRecord.TOKEN[i])
                {
                    result.Set(i, TriState.MATCH);
                    targetMatched[i] = true;
                }
            }

            // Second pass: check for invalid order
            for (int i = 0; i < guess.Length; i++)
            {
                if (result.Get(i) == TriState.MATCH)
                    continue;
                bool found = false;
                for (int j = 0; j < targetRecord.TOKEN.Length; j++)
                {
                    if (!targetMatched[j] && guess[i] == targetRecord.TOKEN[j])
                    {
                        found = true;
                        targetMatched[j] = true;
                        break;
                    }
                }
                result.Set(i, found ? TriState.INVALID_ORDER : TriState.NOT_EXIST);
            }
            return result;
        }
        public string GetToken()
        {
            return targetRecord.TOKEN;
        }
        public string GetGroupName()
        {
            return targetRecord.GROUP_NAME;
        }
        public string GetDifficulty()
        {
            return targetRecord.LEVEL;
        }
        public void Dispose()
        {
            // Destructor
            targetRecord.TOKEN = string.Empty;
            targetRecord.GROUP_NAME = string.Empty;
            targetRecord.LEVEL = string.Empty;
        }
    }
}