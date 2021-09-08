using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public class DiatonicIntervals : CollectionBase<IInterval>
    {
        public DiatonicIntervals() : base(new DiatonicIntervalsAscending().Concat(new DiatonicIntervalsAscending().Select(x => new Interval(x.Quality, x.Number, 1.00 / x.Value, IntervalDirection.Descending))))
        {

        }
    }

}
