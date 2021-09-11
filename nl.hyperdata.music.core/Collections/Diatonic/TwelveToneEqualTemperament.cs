using System;
using System.Linq;

namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public class TwelveToneEqualTemperament : CollectionBase<IPitch>
    {
        public static TwelveToneEqualTemperament Default = new TwelveToneEqualTemperament();

        public TwelveToneEqualTemperament() : base(Enumerable.Range(1, 88).Select(index => new Pitch(index, Math.Pow(Math.Pow(2.00, 1 / 12.00), index - 58) * 440.00)))
        {
        }
    }
}