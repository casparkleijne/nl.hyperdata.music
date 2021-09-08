using System;

namespace nl.hyperdata.music.core
{
    public interface IInterval :  IElementBase
    {
        IntervalDirection Direction { get; }
        IntervalNumber Number { get; }
        IntervalQuality Quality { get; }
    }
}