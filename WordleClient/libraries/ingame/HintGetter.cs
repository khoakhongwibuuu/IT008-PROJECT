using WordleClient.libraries.lowlevel;

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

        private static char? GetRandomVowel(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            var vowels = input
                .Where(c => char.IsLetter(c) && VowelSet.Contains(char.ToUpperInvariant(c)))
                .ToList();

            if (vowels.Count == 0) return null;

            return vowels[_rand.Next(vowels.Count)];
        }
        private static char? GetRandomConsonant(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            var consonants = input
                .Where(c => char.IsLetter(c) && ConsonantSet.Contains(char.ToUpperInvariant(c)))
                .ToList();

            if (consonants.Count == 0) return null;

            return consonants[_rand.Next(consonants.Count)];
        }
        public static String HintTranslator(Hint hint)
        {
            if (hint.h_type == HintType.Present)
            {
                return $"The chosen word has the letter '{hint.pre_letter}' .";
            }
            else
            {
                if (hint.abs_type == AbsentType.VOWEL)
                {
                    return "There are no vowels in the word.";
                }
                else
                {
                    return "There are no consonants in the word.";
                }
            }
        }
        public static Hint GetHint(string token, int seed)
        {
            bool even = (seed % 2) == 0;
            char? c = even ? GetRandomVowel(token) : GetRandomConsonant(token);
            return c == null
                ? new Hint(HintType.Absent, null, even ? AbsentType.VOWEL : AbsentType.CONSONANT)
                : new Hint(HintType.Present, c, null);
        }
    }
}
