
namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public static class ModernModes
    {

        public static IMode Ionian = new Mode(new IInterval[]
        {
            DiatonicIntervalsAscending.MajorSecond,
            DiatonicIntervalsAscending.MajorSecond,
            DiatonicIntervalsAscending.MinorSecond,
            DiatonicIntervalsAscending.MajorSecond,
            DiatonicIntervalsAscending.MajorSecond,
            DiatonicIntervalsAscending.MajorSecond,
            DiatonicIntervalsAscending.MinorSecond
        });

        public static IMode IonianDescending = new Mode(new IInterval[]
         {
            DiatonicIntervalsDescending.MinorSecond,
            DiatonicIntervalsDescending.MajorSecond,
            DiatonicIntervalsDescending.MajorSecond,
            DiatonicIntervalsDescending.MajorSecond,
            DiatonicIntervalsDescending.MinorSecond,
            DiatonicIntervalsDescending.MajorSecond,
            DiatonicIntervalsDescending.MajorSecond,
         });

    }
}
