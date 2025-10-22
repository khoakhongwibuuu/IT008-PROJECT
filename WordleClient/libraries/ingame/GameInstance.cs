using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.ingame
{
    public class GameInstance
    {
        string targetWord;
        int maxAttempts;
        List<string> previousGuesses;

        public GameInstance(string targetWord, int maxAttempts)
        {
            this.targetWord = targetWord;
            this.maxAttempts = maxAttempts;
            previousGuesses = new List<string>();
        }
        public StateArray EvaluateGuess(string guess)
        {
            if (guess.Length != targetWord.Length)
                throw new ArgumentException("Guess length does not match target word length.");
            StateArray result = new StateArray(guess.Length);
            bool[] targetMatched = new bool[targetWord.Length];
            // First pass: check for matches
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == targetWord[i])
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
                for (int j = 0; j < targetWord.Length; j++)
                {
                    if (!targetMatched[j] && guess[i] == targetWord[j])
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
    }
}
