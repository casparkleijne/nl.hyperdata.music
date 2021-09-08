using System;
using System.Collections.Generic;

namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public class DiatonicIntervalsAscending : CollectionBase<IInterval>
    {

        public static IInterval Unison => new Interval
        (
            IntervalQuality.Perfect,
            IntervalNumber.Prime,
            Math.Pow(2.00, 0.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval MinorSecond => new Interval
        (
            IntervalQuality.Minor,
            IntervalNumber.Second,
            Math.Pow(2.00, 1.00 / 12.00),
            IntervalDirection.Ascending
        );

        public static IInterval MajorSecond => new Interval
        (
            IntervalQuality.Major,
            IntervalNumber.Second,
            Math.Pow(2.00, 2.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval MinorThird => new Interval
        (
            IntervalQuality.Minor,
            IntervalNumber.Third,
             Math.Pow(2.00, 3.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval MajorThird => new Interval
        (
            IntervalQuality.Major,
            IntervalNumber.Third,
            Math.Pow(2.00, 4.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval PerfectFourth => new Interval
        (
            IntervalQuality.Perfect,
            IntervalNumber.Fourth,
            Math.Pow(2.00, 5.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval Tritone => new Interval
        (
            IntervalQuality.Augmented,
            IntervalNumber.Fourth,
            Math.Pow(2.00, 6.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval PerfectFifth => new Interval
        (
            IntervalQuality.Perfect,
            IntervalNumber.Fifth,
            Math.Pow(2.00, 7.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval MinorSixt => new Interval
        (
            IntervalQuality.Minor,
            IntervalNumber.Sixth,
            Math.Pow(2.00, 8.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval MajorSixth => new Interval
        (
            IntervalQuality.Major,
            IntervalNumber.Sixth,
            Math.Pow(2.00, 9.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval MinorSeventh => new Interval
        (
            IntervalQuality.Minor,
            IntervalNumber.Sixth,
            Math.Pow(2.00, 10.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval MajorSeventh => new Interval
        (
            IntervalQuality.Major,
            IntervalNumber.Seventh,
            Math.Pow(2.00, 11.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval Octave => new Interval
        (
           IntervalQuality.Perfect,
           IntervalNumber.Octave,
           Math.Pow(2.00, 12.00 / 12.00),
           IntervalDirection.Ascending
        );

        public static IInterval MinorNinth => new Interval
        (
           IntervalQuality.Minor,
           IntervalNumber.Ninth,
           Math.Pow(2.00, 13.00 / 12.00),
           IntervalDirection.Ascending
        );
        public static IInterval MajorNinth => new Interval
        (
           IntervalQuality.Major,
           IntervalNumber.Ninth,
           Math.Pow(2.00, 14.00 / 12.00),
           IntervalDirection.Ascending
        );
        public static IInterval MinorTenth => new Interval
        (
           IntervalQuality.Minor,
           IntervalNumber.Tenth,
           Math.Pow(2.00, 15.00 / 12.00),
           IntervalDirection.Ascending
        );

        public static IInterval MajorTenth => new Interval
        (
           IntervalQuality.Major,
           IntervalNumber.Tenth,
           Math.Pow(2.00, 16.00 / 12.00),
           IntervalDirection.Ascending
        );

        public static IInterval PerfectEleventh => new Interval
        (
            IntervalQuality.Perfect,
            IntervalNumber.Eleventh,
            Math.Pow(2.00, 17.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval AugmentedEleventh => new Interval
        (
            IntervalQuality.Augmented,
            IntervalNumber.Eleventh,
            Math.Pow(2.00, 18.00 / 12.00),
            IntervalDirection.Ascending
        );
        public static IInterval PerfectTwelveth => new Interval
        (
            IntervalQuality.Perfect,
            IntervalNumber.Twelveth,
            Math.Pow(2.00, 19.00 / 12.00),
            IntervalDirection.Ascending
        );

        public DiatonicIntervalsAscending() : base(new List<IInterval>
            {
                Unison,
                MinorSecond,
                MajorSecond,
                MinorThird,
                MajorThird,
                PerfectFourth,
                Tritone,
                PerfectFifth,
                MajorSixth,
                MajorSeventh,
                Octave,
                MinorNinth,
                MajorNinth,
                MinorTenth,
                MajorTenth,
                PerfectEleventh,
                AugmentedEleventh,
                PerfectTwelveth
           })
        {

        }


    }

}
