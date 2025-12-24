using System.Collections;
namespace WordleClient.libraries.lowlevel
{
    public enum TriState : byte
    {
        NOT_EXIST = 0,
        INVALID_ORDER = 1,
        MATCH = 2
    }
    [Serializable]
    public sealed class StateArray : IEnumerable<TriState>
    {
        private byte[] _data;
        public StateArray()
        {
            _data = Array.Empty<byte>();
        }
        public StateArray(int length)
        {
            _data = new byte[length];
        }
        public int Length => _data.Length;
        public TriState Get(int index)
        {
            return (TriState)_data[index];
        }
        public void Set(int index, TriState value)
        {
            _data[index] = (byte)value;
        }
        public TriState this[int index]
        {
            get => (TriState)_data[index];
            set => _data[index] = (byte)value;
        }
        public bool IsFullValue(TriState value)
        {
            byte b = (byte)value;
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] != b)
                    return false;
            }
            return true;
        }
        public IEnumerator<TriState> GetEnumerator()
        {
            for (int i = 0; i < _data.Length; i++)
                yield return (TriState)_data[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
        public byte[] ToByteArray()
        {
            return (byte[])_data.Clone();
        }
    }
}