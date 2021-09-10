 
using System.Linq;

namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public static class ModernModes
    {


        public static IMode Ionian = new Mode(new IInterval[]
        {
            DiatonicIntervals.Default.FirstOrDefault(i=> i.Direction == IntervalDirection.Ascending && i.Quality == IntervalQuality.Major && i.Number == IntervalNumber.Second),
            DiatonicIntervals.Default.FirstOrDefault(i=> i.Direction == IntervalDirection.Ascending && i.Quality == IntervalQuality.Major && i.Number == IntervalNumber.Second),
            DiatonicIntervals.Default.FirstOrDefault(i=> i.Direction == IntervalDirection.Ascending && i.Quality == IntervalQuality.Minor && i.Number == IntervalNumber.Second),
            DiatonicIntervals.Default.FirstOrDefault(i=> i.Direction == IntervalDirection.Ascending && i.Quality == IntervalQuality.Major && i.Number == IntervalNumber.Second),
            DiatonicIntervals.Default.FirstOrDefault(i=> i.Direction == IntervalDirection.Ascending && i.Quality == IntervalQuality.Major && i.Number == IntervalNumber.Second),
            DiatonicIntervals.Default.FirstOrDefault(i=> i.Direction == IntervalDirection.Ascending && i.Quality == IntervalQuality.Major && i.Number == IntervalNumber.Second),
            DiatonicIntervals.Default.FirstOrDefault(i=> i.Direction == IntervalDirection.Ascending && i.Quality == IntervalQuality.Minor && i.Number == IntervalNumber.Second),

        });



    }
}
