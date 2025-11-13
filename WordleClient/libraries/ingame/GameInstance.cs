using System.Diagnostics;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.ingame
{
    public class GameInstance
    {
        private readonly WDBRecord targetRecord;
        private readonly int maxAttempts;
        private readonly List<string> dictionary;
        private List<string> previousGuesses;

        public GameInstance(WDBRecord targetRecord, int maxAttempts)
        {
            WordDatabaseReader wdr = new();
            this.targetRecord = targetRecord;
            this.maxAttempts = maxAttempts;
            this.dictionary = wdr.loadDistinctTokens(targetRecord.TOKEN.Length);
            this.previousGuesses = new List<string>();
        }
        public GameInstance(string testWord, int maxAttempts)
        {
            this.targetRecord = new WDBRecord { TOKEN = testWord, DEFINITION = "undefined", GROUP_NAME = "undefined"  };
            this.maxAttempts = maxAttempts;
            this.dictionary = new List<string>();
            this.previousGuesses = new List<string>();
        }
        public bool isFoundInDictionary(string guess)
        {
            Debug.WriteLine($"Checking if '{guess}' is in dictionary of size {dictionary.Count}");
            return dictionary.Contains(guess.ToLower());
        }
        public StateArray EvaluateGuess(string guess)
        {
            if (guess.Length != targetRecord.TOKEN.Length)
                throw new ArgumentException("Guess length does not match target word length.");
            StateArray result = new StateArray(guess.Length);
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
            previousGuesses.Add(guess);
            return result;
        }
        public void Dispose()
        {
            // Destructor
            targetRecord.TOKEN = string.Empty;
            targetRecord.DEFINITION = string.Empty;
            targetRecord.GROUP_NAME = string.Empty;
            previousGuesses.Clear();
        }
    }
}
