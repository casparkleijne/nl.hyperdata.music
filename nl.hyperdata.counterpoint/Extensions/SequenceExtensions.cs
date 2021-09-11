using nl.hyperdata.music.core;
using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Text;
using System.Threading.Tasks;
using nl.hyperdata.music.core.Collections.Diatonic;
using nl.hyperdata.music.core.Extensions;

namespace nl.hyperdata.counterpoint.Extensions
{
    public static class SequenceExtensions
    {


        private static IEnumerable<Func<Sequence, bool>> rules = new Func<Sequence, bool>[]
        {
            s=> s.Rule1(),
            s=> s.Rule2(),
            s=> s.Rule3(),
            s=> s.Rule4(),
            s=> s.Rule5(),
            s=> s.Rule6(),
            s=> s.Rule7(),
            s=> s.Rule8(),
            s=> s.Rule9(),
            s=> s.Rule10(),
            s=> s.Rule11(),
            s=> s.Rule12(),
            s=> s.Rule13()
        };

        public static IEnumerable<Func<Sequence, bool>> Rules { get => rules; }

        public static bool AllRules(this Sequence sequence)
        {
            return rules.All(r => r.Invoke(sequence));
        }

        /// <summary>
        /// 8 to 16 notes long of equal value 
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule1(this Sequence sequence)
        {
            return sequence.Count() >= 7 && sequence.Count() <= 15;
        }

        /// <summary>
        /// All notes must be diatonic
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule2(this Sequence sequence)
        {
            return true;
        }

        /// <summary>
        /// Must start and end on tonic
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule3(this Sequence sequence)
        {
            double current = sequence.FirstOrDefault().Value;
            foreach(double ratio in sequence.Skip(1).Select(x=> x.Value))
            {
                current = ratio * current;
            }
            return current == 1;
        }

        /// <summary>
        /// Must end supertonic, tonic
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule4(this Sequence sequence)
        {
            IInterval interval = sequence.LastOrDefault();
            return interval != null && interval.Direction == IntervalDirection.Ascending &&
                interval.Number == IntervalNumber.Second;
             
        }

        /// <summary>
        /// Range of a Sth to a 10th
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule5(this Sequence sequence)
        {
            return true; // sequence.Sum(x => x.Interval.Value) == 0;
        }

        /// <summary>
        /// Stepwise motion predominates though a few leaps are necessary
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule6(this Sequence sequence)
        {
            return sequence.Count(x => x.Number == IntervalNumber.Second) > sequence.Count(x => x.Number != IntervalNumber.Second);
        }

        /// <summary>
        ///  Leaps of a 4th or more must be compensated by a change in direction(most often stepwise)
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule7(this Sequence sequence)
        {
            return true; // sequence.Count(x => x.Interval.Number == IntervalNumber.Second) > sequence.Count(x => x.Interval.Number != IntervalNumber.Second);
        }

        /// <summary>
        /// Must have a single melodic high point that is consonant with tonic
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule8(this Sequence sequence)
        {
            return true; // sequence
        }

        /// <summary>
        /// Do not exceed 5 notes in the same direction
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule9(this Sequence sequence)
        {
            return !sequence.GroupAdjacent(x => x.Direction).Any(x => x.Count() > 4);
        }

        /// <summary>
        /// No repeated notes in consecutive measures
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule10(this Sequence sequence)
        {
            return !sequence.Any(x=> x.Direction == IntervalDirection.None);
        }

        /// <summary>
        ///  No melodic intervals of 7ths or augmented or diminished intervals
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule11(this Sequence sequence)
        {
            return !sequence.Any(x => x.Number == IntervalNumber.Seventh || x.Quality == IntervalQuality.Diminished || x.Quality == IntervalQuality.Tritone || x.Quality == IntervalQuality.Augmented);
        }

        /// <summary>
        /// Must not outline dissonant melodic intervals
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule12(this Sequence sequence)
        {
            var p = sequence.GroupAdjacent(x => x.Direction).Select(i=> DiatonicIntervals.Default.FindProduct(i))
                .Any(x => x.Number == IntervalNumber.Seventh || x.Quality == IntervalQuality.Diminished || x.Quality == IntervalQuality.Tritone || x.Quality == IntervalQuality.Augmented);
            return true;
        }

        /// <summary>
        /// No trills(4 note pattern) or melodic sequences(3 or more note pattern)
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule13(this Sequence sequence)
        {
            return true; // sequence
        }

        //2. All notes must be diatonic
        //3. Must start and end on tonic
        //4. Must end supertonic, tonic
        //5. Range of a Sth to a 10th
        //6. Stepwise motion predominates though a few leaps are necessary
        //7. Leaps of a 4th or more must be compensated by a change in direction(most often stepwise)
        //8. Must have a single melodic high point that is consonant with tonic
        //9. Do not exceed 5 notes in the same direction
        //10. No repeated notes in consecutive measures
        //11. No melodic intervals of 7ths or augmented or diminished intervals
        //12. Must not outline dissonant melodic intervals
        //13. No trills(4 note pattern) or melodic sequences(3 or more note pattern)
    }
}
