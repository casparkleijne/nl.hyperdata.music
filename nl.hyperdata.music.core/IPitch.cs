using System;

namespace nl.hyperdata.music.core
{
    public interface IPitch : IComparable<IPitch>, IEquatable<IPitch>, IEquatable<double>
    {
        int Index { get; }
        double Frequency { get; }
    }
}