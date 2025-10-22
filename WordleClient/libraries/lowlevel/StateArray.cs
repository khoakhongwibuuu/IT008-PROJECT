﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleClient.libraries.lowlevel
{
    public enum TriState : byte
    {
        NOT_EXIST = 0, // Character does not exist in the word
        MATCH = 1, // Character exists in the word and is in the correct position
        INVALID_ORDER = 2 // Character exists in the word but is in the wrong position
    }
    public class StateArray : IEnumerable<TriState>, IEnumerable
    {
        private readonly byte[] data;
        public int Length { get; }

        public StateArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));
            Length = length;
            data = new byte[(length + 3) / 4]; // 4 values per byte
        }

        /// <summary>
        /// Sets the TriState value at the specified index.
        /// </summary>
        public void Set(int index, TriState value)
        {
            if ((uint)index >= (uint)Length)
                throw new IndexOutOfRangeException();

            int byteIndex = index >> 2;         // index / 4
            int bitOffset = (index & 3) * 2;    // (index % 4) * 2
            byte mask = (byte)(0b11 << bitOffset);

            data[byteIndex] = (byte)(data[byteIndex] & ~mask | ((byte)value & 0b11) << bitOffset);
        }

        /// <summary>
        /// Gets the TriState value at the specified index.
        /// </summary>
        public TriState Get(int index)
        {
            if ((uint)index >= (uint)Length)
                throw new IndexOutOfRangeException();

            int byteIndex = index >> 2;
            int bitOffset = (index & 3) * 2;
            return (TriState)(data[byteIndex] >> bitOffset & 0b11);
        }

        /// <summary>
        /// Sets all elements to the given value efficiently.
        /// </summary>
        public void SetAll(TriState value)
        {
            byte pattern = 0;
            byte valBits = (byte)((byte)value & 0b11);
            // Each byte holds 4 of the same 2-bit values
            for (int i = 0; i < 4; i++)
                pattern |= (byte)(valBits << i * 2);

            Array.Fill(data, pattern);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the array.
        /// </summary>
        public IEnumerator<TriState> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
                yield return Get(i);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Gets the raw byte buffer (for serialization or debugging).
        /// </summary>
        public byte[] RawData => data;
    }
}
