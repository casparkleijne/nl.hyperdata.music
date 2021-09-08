using System;

namespace nl.hyperdata.music.core
{
    public interface IInterval : IEquatable<IInterval>, IEquatable<double>
    {
        Direction Direction { get; set; }
        IntervalNumber Number { get; }
        IntervalQuality Quality { get; }
        double Ratio { get; }
    }
}