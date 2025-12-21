using System.Collections;
namespace WordleClient.libraries.lowlevel
{
    public enum TriState : byte
    {
        NOT_EXIST = 0,
        INVALID_ORDER = 1,
        MATCH = 2
    }
    public class StateArray : IEnumerable<TriState>, IEnumerable
    {
        private readonly byte[] data;
        public int Length
        {
            get;
        }
        public StateArray(int length)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(length);
            Length = length;
            data = new byte[(length + 0b11) >> 2];
        }
        public void Set(int index, TriState value)
        {
            if ((uint)index >= (uint)Length) throw new IndexOutOfRangeException();
            int byteIndex = index >> 2;
            int bitOffset = (index & 0b11) << 1;
            byte mask = (byte)(0b11 << bitOffset);
            data[byteIndex] = (byte)(data[byteIndex] & ~mask | ((byte)value & 0b11) << bitOffset);
        }
        public TriState Get(int index)
        {
            if ((uint)index >= (uint)Length) throw new IndexOutOfRangeException();
            int byteIndex = index >> 2;
            int bitOffset = (index & 0b11) << 1;
            return (TriState)(data[byteIndex] >> bitOffset & 0b11);
        }
        public void SetAll(TriState value)
        {
            byte pattern = 0;
            byte valBits = (byte)((byte)value & 0b11);
            for (int i = 0; i < 4; i++) pattern |= (byte)(valBits << i * 2);
            Array.Fill(data, pattern);
        }
        public bool IsFullValue(TriState value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (Get(i) != value) return false;
            }
            return true;
        }
        public IEnumerator<TriState> GetEnumerator()
        {
            for (int i = 0; i < Length; i++) yield
            return Get(i);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public byte[] RawData => data;
    }
}