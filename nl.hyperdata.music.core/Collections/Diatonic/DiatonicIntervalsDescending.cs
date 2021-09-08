using System;
using System.Collections;
using System.Collections.Generic;

namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public class DiatonicIntervalsDescending : IEnumerable<IInterval>
    {

        public static IInterval Unison => new Interval
        (
            IntervalQuality.Perfect,
            IntervalNumber.Prime,
            1.00 / Math.Pow(2.00, 0.00 / 12.00),
            Direction.Descending
        );

        public static IInterval MinorSecond => new Interval
        (
            IntervalQuality.Minor,
            IntervalNumber.Second,
            1.00 / Math.Pow(2.00, 1.00 / 12.00),
            Direction.Descending
        );

        public static IInterval MajorSecond => new Interval
        (
            IntervalQuality.Major,
            IntervalNumber.Second,
            1.00 / Math.Pow(2.00, 2.00 / 12.00),
            Direction.Descending
        );

        public static IInterval MinorThird => new Interval
        (
            IntervalQuality.Minor,
            IntervalNumber.Third,
            1.00 / Math.Pow(2.00, 3.00 / 12.00),
            Direction.Descending
        );

        public static IInterval MajorThird => new Interval
        (
            IntervalQuality.Major,
            IntervalNumber.Third,
            1.00 / Math.Pow(2.00, 4.00 / 12.00),
            Direction.Descending
        );

        public static IInterval PerfectFourth => new Interval
        (
            IntervalQuality.Perfect,
            IntervalNumber.Fourth,
            1.00 / Math.Pow(2.00, 5.00 / 12.00),
            Direction.Descending
        );

        public static IInterval Tritone => new Interval
        (
            IntervalQuality.Augmented,
            IntervalNumber.Fourth,
            1.00 / Math.Pow(2.00, 6 / 12.00),
            Direction.Descending
        );

        public static IInterval PerfectFifth => new Interval
        (
            IntervalQuality.Perfect,
            IntervalNumber.Fifth,
            1.00 / Math.Pow(2.00, 7 / 12.00),
            Direction.Descending
        );

        public static IInterval MinorSixt => new Interval
        (
            IntervalQuality.Minor,
            IntervalNumber.Sixth,
            1.00 / Math.Pow(2.00, 8 / 12.00),
            Direction.Descending
        );

        public static IInterval MajorSixth => new Interval
        (
            IntervalQuality.Major,
            IntervalNumber.Sixth,
            1.00 / Math.Pow(2.00, 9 / 12.00),
            Direction.Descending
        );

        public static IInterval MinorSeventh => new Interval
        (
            IntervalQuality.Major,
            IntervalNumber.Sixth,
            1.00 / Math.Pow(2.00, 10 / 12.00),
            Direction.Descending
        );

        public static IInterval MajorSeventh => new Interval
        (
            IntervalQuality.Minor,
            IntervalNumber.Seventh,
            1.00 / Math.Pow(2.00, 11 / 12.00),
            Direction.Descending
        );

        public static IInterval Octave => new Interval
        (
           IntervalQuality.Perfect,
           IntervalNumber.Octave,
           1.00 / Math.Pow(2.00, 12.00 / 12.00),
           Direction.Descending
        );

        private static readonly List<IInterval> items =
            new List<IInterval>
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
                Octave
           };

        public IEnumerator<IInterval> GetEnumerator()
        {
            return ((IEnumerable<IInterval>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)items).GetEnumerator();
        }

    }

}
