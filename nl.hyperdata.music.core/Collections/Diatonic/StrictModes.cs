
namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public static class StrictModes
    {

        public static IMode Ionian = new Mode(new IInterval[]
        {
            DiatonicIntervalsAscending.MajorSecond,
            DiatonicIntervalsAscending.MajorThird,
            DiatonicIntervalsAscending.PerfectFourth,
            DiatonicIntervalsAscending.PerfectFifth,
            DiatonicIntervalsAscending.MajorSixth,
            DiatonicIntervalsAscending.MajorSeventh,
            DiatonicIntervalsAscending.Octave
        });

    }
}
