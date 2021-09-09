using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public class DiatonicIntervals : CollectionBase<IInterval>
    {

        public static DiatonicIntervals Default = new DiatonicIntervals();

        public DiatonicIntervals() : base(Enumerable.Range(0, 39).Select(n => new Interval(n-19)))
        {

        }
    }

}
