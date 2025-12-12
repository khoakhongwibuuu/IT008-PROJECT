namespace WordleClient.libraries.lowlevel
{
    public enum HintType
    {
        Absent = 0,
        Present = 1
    }
    public enum AbsentType
    {
        CONSONANT = 0,
        VOWEL = 1
    }
    public class Hint
    {
        HintType h_type { get; set; }
        char? pre_letter { get; set; } // null if h_type = absent
        AbsentType? abs_type { get; set; } // null if h_type = present
        public Hint(HintType type, char? letter = null, AbsentType? absentType = null)
        {
            h_type = type;
            if (type == HintType.Present)
            {
                pre_letter = letter;
                abs_type = null;
            }
            else
            {
                pre_letter = null;
                abs_type = absentType;
            }
        }
    }
}
