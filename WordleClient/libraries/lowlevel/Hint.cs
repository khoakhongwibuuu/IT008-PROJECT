namespace WordleClient.libraries.lowlevel
{
    public enum HintType
    {
        Absent = 0, Present = 1
    }
    public enum AbsentType
    {
        CONSONANT = 0, VOWEL = 1
    }
    public class Hint
    {
        public HintType h_type
        {
            get;
            set;
        }
        public char? pre_letter
        {
            get;
            set;
        }
        public AbsentType? abs_type
        {
            get;
            set;
        }
        public Hint() { }
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