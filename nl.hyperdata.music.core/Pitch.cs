using System;

namespace nl.hyperdata.music.core
{
    internal class Pitch : IPitch
    {
        public Pitch(int index, double frequency)
        {
            Index = index;
            Frequency = frequency;
        }

        public double Frequency { get; }
        public int Index { get; }
        public int CompareTo(IPitch other) => (int)Frequency - (int)other.Frequency;
        public override string ToString() => $"PitchIndex:{Index.ToString().PadRight(4)} Freq:{Math.Round(Frequency, 2)}";
        public bool Equals(IPitch other)
        {
            if (other == null)
            {
                return false;
            }
            return Math.Round(Frequency, 2) == Math.Round(other.Frequency, 2);
        }

        public bool Equals(double other)
        {
            return Math.Round(Frequency, 2) == Math.Round(other, 2);
        }
    }
}
