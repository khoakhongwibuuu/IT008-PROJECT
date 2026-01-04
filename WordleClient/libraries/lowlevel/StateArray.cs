using System.Collections;
using System.Text.Json.Serialization;
namespace WordleClient.libraries.lowlevel
{
    public enum TriState : byte
    {
        NOT_EXIST = 0,
        INVALID_ORDER = 1,
        MATCH = 2
    }
    public sealed class StateArray : IEnumerable<TriState>
    {
        // 🔑 JSON MUST SEE THIS
        [JsonInclude]
        public byte[] Data { get; private set; } = Array.Empty<byte>();

        // REQUIRED for deserialization
        public StateArray() { }

        public StateArray(int length)
        {
            Data = new byte[length];
        }

        public int Length => Data.Length;

        /* ===== Required API ===== */

        public TriState Get(int index)
            => (TriState)Data[index];

        public void Set(int index, TriState value)
            => Data[index] = (byte)value;

        public TriState this[int index]
        {
            get => (TriState)Data[index];
            set => Data[index] = (byte)value;
        }

        public bool IsFullValue(TriState value)
        {
            byte b = (byte)value;
            for (int i = 0; i < Data.Length; i++)
                if (Data[i] != b)
                    return false;
            return true;
        }

        public IEnumerator<TriState> GetEnumerator()
        {
            for (int i = 0; i < Data.Length; i++)
                yield return (TriState)Data[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}