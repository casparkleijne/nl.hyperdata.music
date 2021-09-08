using System;
using System.Collections.Generic;

namespace nl.hyperdata.music.core
{
    internal class Pitch : ElementBase, IPitch
    {
        public Pitch(int index, double frequency) : base(frequency)
        {
            Index = index;
        }

        public int Index { get; }

        /// <summary>
        /// A human readable line describing this object, for debugging only.
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() => $"PitchIndex:{Index.ToString().PadRight(4)} Freq:{Math.Round(Value, 2)}";



    }
}
