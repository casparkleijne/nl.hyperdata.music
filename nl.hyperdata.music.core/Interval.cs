using System;

namespace nl.hyperdata.music.core
{
    internal class Interval : ElementBase, IInterval
    {
        private static (IntervalQuality, IntervalNumber)[] Intervals = new (IntervalQuality, IntervalNumber)[]
            {
                (IntervalQuality.Perfect    ,IntervalNumber.Prime),
                (IntervalQuality.Minor      ,IntervalNumber.Second ),
                (IntervalQuality.Major      ,IntervalNumber.Second ),
                (IntervalQuality.Minor      ,IntervalNumber.Third  ),
                (IntervalQuality.Major      ,IntervalNumber.Third  ),
                (IntervalQuality.Perfect    ,IntervalNumber.Fourth ),
                (IntervalQuality.Augmented  ,IntervalNumber.Tritone),
                (IntervalQuality.Perfect    ,IntervalNumber.Fifth  ),
                (IntervalQuality.Minor      ,IntervalNumber.Sixth  ),
                (IntervalQuality.Major      ,IntervalNumber.Sixth  ),
                (IntervalQuality.Minor      ,IntervalNumber.Seventh),
                (IntervalQuality.Major      ,IntervalNumber.Seventh),
                (IntervalQuality.Perfect    ,IntervalNumber.Octave),
                (IntervalQuality.Minor      ,IntervalNumber.Ninth  ),
                (IntervalQuality.Major      ,IntervalNumber.Ninth  ),
                (IntervalQuality.Minor      ,IntervalNumber.Tenth),
                (IntervalQuality.Major      ,IntervalNumber.Tenth),
                (IntervalQuality.Perfect    ,IntervalNumber.Eleventh),
                (IntervalQuality.Augmented  ,IntervalNumber.EleventhTritone),
                (IntervalQuality.Perfect    ,IntervalNumber.Twelveth),
            };

        public Interval(double factor) : base(Math.Pow(2.00, factor / 12.00))
        {
            Quality = Intervals[Math.Abs((int)factor)].Item1;
            Number = Intervals[Math.Abs((int)factor)].Item2;
            Direction = (IntervalDirection)Math.Sign(factor);
        }

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