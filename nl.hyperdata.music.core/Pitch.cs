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

        public override string ToString() => $"PitchIndex:{Index.ToString().PadRight(4)} Freq:{Math.Round(Value, 2)}";



    }
}
