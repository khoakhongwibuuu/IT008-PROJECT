namespace WordleClient.libraries.StateFrom
{
    public static class CustomStateSound
    {
        public static bool IsMuted
        {
            get;
            private set;
        } = false;
        public static void Toggle()
        {
            IsMuted = !IsMuted;
        }
        public static void Set(bool muted)
        {
            IsMuted = muted;
        }
    }
}