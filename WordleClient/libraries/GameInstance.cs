using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleClient.libraries;

namespace WordleClient.libraries
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
            this.previousGuesses = new List<string>();
        }

        public void AddGuess(string guessingString)
        {

        }
    }
}
