using System;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public class DiatonicIntervals : CollectionBase<IInterval>
    {
        private static readonly Random psrng = new Random(1);

        public static DiatonicIntervals Default = new DiatonicIntervals();

        public DiatonicIntervals() : base(Enumerable.Range(0, 39).Select(n => new Interval(n-19)))
        {

        }

        public static IInterval Random()
        {
            return Default.Skip(8).Take(12).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }
    }

}
