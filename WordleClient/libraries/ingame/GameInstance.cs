// Pseudocode / Plan:
// 1. Fix case-sensitivity bug in GetRandomVowel and GetRandomConsonant:
//    - Compare characters using a normalized form (ToUpperInvariant) against uppercase sets.
//    - Use HashSet<char> for faster contains checks.
//    - Preserve the original character case when returning a random match from the input string.
// 2. Keep the existing behavior: return null for empty input or when no matching letters found.
// 3. Keep other GameInstance logic unchanged.
// 4. Make minimal, safe changes to improve correctness and performance.

using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using WordleClient.libraries.lowlevel;

namespace WordleClient.libraries.ingame
{
    public class GameInstance
    {
        private readonly WDBRecord targetRecord;
        private readonly int maxAttempts;
        private readonly List<string> dictionary;
        private List<string> previousGuesses;

        private static readonly Random _rand = new Random();
        private static readonly char[] Vowels = {
            'A', 'E', 'I', 'O', 'U'
        };
        private static readonly char[] Consonants = {
            'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M',
            'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z'
        };

        // HashSets for fast, case-insensitive membership checks (compare using ToUpperInvariant)
        private static readonly HashSet<char> VowelSet = new HashSet<char>(Vowels);
        private static readonly HashSet<char> ConsonantSet = new HashSet<char>(Consonants);

        public static char? GetRandomVowel(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            var vowels = input
                .Where(c => char.IsLetter(c) && VowelSet.Contains(char.ToUpperInvariant(c)))
                .ToList();

            if (vowels.Count == 0) return null;

            return vowels[_rand.Next(vowels.Count)];
        }

        public static char? GetRandomConsonant(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            var consonants = input
                .Where(c => char.IsLetter(c) && ConsonantSet.Contains(char.ToUpperInvariant(c)))
                .ToList();

            if (consonants.Count == 0) return null;

            return consonants[_rand.Next(consonants.Count)];
        }

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
            this.targetRecord = new WDBRecord { TOKEN = testWord, DEFINITION = "undefined", GROUP_NAME = "undefined" };
            this.maxAttempts = maxAttempts;
            this.dictionary = new List<string>();
            this.previousGuesses = new List<string>();
        }
        public bool isFoundInDictionary(string guess)
        {
            Debug.WriteLine($"Checking if '{guess}' is in dictionary of size {dictionary.Count}");
            return dictionary.Contains(guess.ToLowerInvariant());
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
        public string GetToken()
        {
            return targetRecord.TOKEN;
        }
        public string GetDefinition()
        {
            return targetRecord.DEFINITION;
        }
        public string getGroupName()
        {
            return targetRecord.GROUP_NAME;
        }
        public string GetHint(int mode)
        {
            if (mode % 2 == 0)
            {
                char? vowel = GetRandomVowel(targetRecord.TOKEN);
                return vowel != null
                    ? $"The chosen word has the letter {vowel}."
                    : "The chosen word does not contain any vowels.";
            }
            else
            {
                char? consonant = GetRandomConsonant(targetRecord.TOKEN);
                return consonant != null
                    ? $"The chosen word has the letter {consonant}."
                    : "The chosen word does not contain any consonants.";
            }
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