using System;

namespace nl.hyperdata.music.core
{
    internal class Interval : IInterval
    {
        public Interval(IntervalQuality quality, IntervalNumber number, double ratio, Direction direction = Direction.Descending)
        {
            Quality = quality;
            Number = number;
            Ratio = ratio;
            Direction = direction;
        }

        public Direction Direction { get; set; }
        public IntervalQuality Quality { get; }
        public IntervalNumber Number { get; }
        public double Ratio { get; }

        public bool Equals(IInterval other)
        {
            if (other == null)
            {
                return false;
            }
            return Math.Round(Ratio, 2) == Math.Round(other.Ratio, 2);
        }

        public bool Equals(double other)
        {
            return Math.Round(Ratio, 2) == Math.Round(other, 2);
        }

        public override string ToString()
        {
            return $"{ Quality}{Number} {Direction} { Ratio }";
        }

    }

}
