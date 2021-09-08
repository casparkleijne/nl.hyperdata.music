using System;

namespace nl.hyperdata.music.core
{
    internal class Interval : ElementBase, IInterval
    {
        public Interval(IntervalQuality quality, IntervalNumber number, double ratio, IntervalDirection direction = IntervalDirection.Descending) : base(ratio)
        {
            Quality = quality;
            Number = number;
            Direction = direction;
        }

        public IntervalDirection Direction { get; }
        public IntervalQuality Quality { get; }
        public IntervalNumber Number { get; }

        public override string ToString()
        {
            return $"{ Quality}{Number} {Direction} { Value }";
        }

    }

}
