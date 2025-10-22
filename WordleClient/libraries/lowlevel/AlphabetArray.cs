using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleClient.libraries.lowlevel
{
    public class AlphabetArray : IEnumerable<char>
    {
        private readonly byte[] data;
        public int Length { get; }

        public AlphabetArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            Length = length;
            int totalBits = length * 5;
            data = new byte[(totalBits + 7) / 8]; // round up to full bytes
        }

        /// <summary>
        /// Sets the letter (A–Z) at the given index.
        /// </summary>
        public void Set(int index, char letter)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException();

            if (letter < 'A' || letter > 'Z')
                throw new ArgumentOutOfRangeException(nameof(letter), "Must be between 'A' and 'Z'.");

            int value = letter - 'A';
            int bitPos = index * 5;
            int byteIndex = bitPos >> 3;       // divide by 8
            int bitOffset = bitPos & 7;        // mod 8

            uint bits = (uint)value << bitOffset;

            // write low part
            data[byteIndex] = (byte)((data[byteIndex] & ~(0x1F << bitOffset)) | ((byte)(bits & (0xFF << bitOffset))));

            // cross-byte case
            if (bitOffset > 3)
            {
                data[byteIndex + 1] = (byte)((data[byteIndex + 1] & ~(0xFF >> (8 - (bitOffset - 3)))) | ((byte)(bits >> (8 - bitOffset))));
            }
        }

        /// <summary>
        /// Gets the letter (A–Z) at the given index.
        /// </summary>
        public char Get(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException();

            int bitPos = index * 5;
            int byteIndex = bitPos >> 3;
            int bitOffset = bitPos & 7;

            int value = (data[byteIndex] >> bitOffset) & 0x1F;

            if (bitOffset > 3 && byteIndex + 1 < data.Length)
            {
                value |= (data[byteIndex + 1] << (8 - bitOffset)) & 0x1F;
            }

            return (char)('A' + value);
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
                yield return Get(i);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public byte[] RawData => data;
    }
}
