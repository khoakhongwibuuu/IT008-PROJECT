using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleClient.libraries.ingame
{
    public class HintGetter
    {
        static Random _rand = new Random();

        // Character constants
        private static readonly char[] Vowels = [
            'A', 'E', 'I', 'O', 'U'
        ];
        private static readonly char[] Consonants = [
            'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M',
            'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z'
        ];

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
    }
}
