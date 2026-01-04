namespace WordleClient.libraries.lowlevel
{
    public class WDBRecord_Simplified
    {
        public int TOKEN_LENGTH { get; set; } = 0;
        public string GROUP_NAME { get; set; } = "";
        public string LEVEL { get; set; } = "";
        public WDBRecord_Simplified(int L, string GR, string LV)
        {
            TOKEN_LENGTH = L;
            GROUP_NAME = GR;
            LEVEL = LV;
        }
    }
}
