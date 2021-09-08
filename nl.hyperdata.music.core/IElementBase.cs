using System;

namespace nl.hyperdata.music.core
{
    public interface IElementBase : IComparable<IElementBase>, IEquatable<IElementBase>, IEquatable<double>
    {
        double Value { get; }
    }
}