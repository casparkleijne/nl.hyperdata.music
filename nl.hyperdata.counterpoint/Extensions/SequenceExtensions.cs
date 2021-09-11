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

        //loose and unspecific
        private static bool IsConsonant(this IInterval interval)
        {
           var result = 
                (interval.Number == IntervalNumber.Second ||
                interval.Number == IntervalNumber.Third ||
                interval.Number == IntervalNumber.Fourth ||
                interval.Number == IntervalNumber.Fifth ||
                interval.Number == IntervalNumber.Sixth ||
                interval.Number == IntervalNumber.Octave ||
                interval.Number == IntervalNumber.Ninth ||
                interval.Number == IntervalNumber.Tenth) &&
                (interval.Quality == IntervalQuality.Minor ||
                interval.Quality == IntervalQuality.Major ||
                interval.Quality == IntervalQuality.Minor ||
                interval.Quality == IntervalQuality.Perfect);
            return result;
        }

        private static bool IsInRange(this IInterval interval)
        {
            if (interval is null)
            {
                return false;
            }

            return
                (interval.Number == IntervalNumber.Fifth ||
                interval.Number == IntervalNumber.Sixth ||
                 interval.Number == IntervalNumber.Seventh ||
                interval.Number == IntervalNumber.Octave ||
                interval.Number == IntervalNumber.Ninth ||
                interval.Number == IntervalNumber.Tenth);
        }

        //loose and unspecific
        private static bool IsStep(this IInterval interval)
        {
            return
                (interval.Number == IntervalNumber.Second);
        }

        private static bool IsSkip(this IInterval interval)
        {
            return
                (interval.Number == IntervalNumber.Third);
        }

        private static bool IsLeap(this IInterval interval)
        {
            return
               ! (interval.IsStep() || interval.IsSkip());
        }

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
        /// V. 8 to 16 notes long of equal value 
        /// that is 7 - 15 intervals
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule1(this Sequence sequence)
        {
            return sequence.Count() > 6  && sequence.Count() < 16;
        }

        /// <summary>
        /// V. All notes must be diatonic however just return true (for now)
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule2(this Sequence sequence)
        {
            return true;
        }

        /// <summary>
        /// V. Must start and end on tonic, the overall interval of the whole sequence must be Unison
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule3(this Sequence sequence)
        {
            var p = sequence.Aggregate((a, x) => DiatonicIntervals.Default.FindProduct(a, x));
            return p.Direction == IntervalDirection.None;
        }

        /// <summary>
        /// V. Must end supertonic, tonic, only checking supertonic
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule4(this Sequence sequence)
        {
            IInterval interval = sequence.LastOrDefault();
            return interval != null && interval.Direction == IntervalDirection.Descending &&
                interval.Number == IntervalNumber.Second;
        }


        public static IInterval HighestFromstart(this Sequence sequence)
        {   
            IInterval current = sequence.FirstOrDefault();
            IInterval highest = current;
         
            foreach (IInterval interval in sequence.Skip(1))
            {
                current = DiatonicIntervals.Default.FindProduct(current, interval);
                if ((ElementBase)current > highest)
                {
                    highest = current;
                }
            };
            return highest;
        }

        public static IInterval LowestFromstart(this Sequence sequence)
        {
           
            IInterval current = sequence.FirstOrDefault();
            IInterval lowest = current;
            foreach (IInterval interval in sequence.Skip(1))
            {
                current = DiatonicIntervals.Default.FindProduct(current, interval);
                if ((ElementBase)current < lowest)
                {
                    lowest = current;
                }
            };
            return lowest;
        }

        /// <summary>
        /// V. Range of a Sth to a 10th
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule5(this Sequence sequence)
        {

            var highest = sequence.HighestFromstart();
            var lowest = sequence.LowestFromstart();

            var result = DiatonicIntervals.Default.FindProduct(lowest, highest);

            return result.IsInRange();
        }

        /// <summary>
        /// V. Stepwise motion predominates though a few leaps are necessary
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

            var x = sequence.Pairwise((a, i) => a.IsLeap() ? i.Direction != a.Direction : true).All(v => v);
        
            return x; // sequence.Count(x => x.Interval.Number == IntervalNumber.Second) > sequence.Count(x => x.Interval.Number != IntervalNumber.Second);
        }

    
        public static IEnumerable<IInterval> Compress(this IEnumerable<IInterval> source)
        {
            var g = source
                .GroupAdjacent(x => x.Direction)
                .Select(x => DiatonicIntervals.Default.FindProduct(x));

            while (g.Count() > 2)
                g = g.Batch(2).Select(x => DiatonicIntervals.Default.FindProduct(x));

            return g;
        }


        /// <summary>
        /// Must have a single melodic high point that is consonant with tonic
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule8(this Sequence sequence)
        {


            var test = sequence.Select((s, o) => DiatonicIntervals.Default.FindProduct(sequence.Skip(o)))
                       .Where(x => x.Direction == IntervalDirection.Descending)
                       .GroupBy(x => x.Value)
                       .OrderBy(x => x.Key)
                       .FirstOrDefault()?
                       .Where(i => i.IsConsonant())
                       .Count() == 1;
           
            return test;

         }

        /// <summary>
        /// V. Do not exceed 5 notes in the same direction
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule9(this Sequence sequence)
        {
            return !sequence.GroupAdjacent(x => x.Direction).Any(x => x.Count() > 4);
        }

        /// <summary>
        /// V. No repeated notes in consecutive measures
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule10(this Sequence sequence)
        {
            return !sequence.Any(x=> x.Direction == IntervalDirection.None);
        }

        /// <summary>
        /// V. No melodic intervals of 7ths or augmented or diminished intervals
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule11(this Sequence sequence)
        {
            var test =  !sequence.Any(x => !x.IsConsonant());
            return test;
        }

        /// <summary>
        /// Must not outline dissonant melodic intervals
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule12(this Sequence sequence)
        {
            var p = !sequence.GroupAdjacent(x => x.Direction).Select(i=> DiatonicIntervals.Default.FindProduct(i))
                .Any(x => !x.IsConsonant());
            return p;
        }


        private static IEnumerable<T> Rotate<T>(this IEnumerable<T> source, int i = 1)
        {
            return source.Skip(i).Concat(source.Take(1));
        }

        /// <summary>
        /// No trills(4 note pattern) or melodic sequences(3 or more note pattern)
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>The result.</returns>
        public static bool Rule13(this Sequence sequence)
        {


            var melodicsequence = sequence
                .Skip(1)
                .Select((s, i) => sequence.Zip(sequence.Rotate(i + 1), (x, a) => x.Direction == a.Direction && x.Quality == a.Quality && x.Number == a.Number)
                .GroupAdjacent(x => x)
                .Where(x => x.Key && x.Count() > 2))
                .Where(x => x.Any())
                .Any();

            // thrills;
            IInterval current = sequence.FirstOrDefault();
            int rep = 0;
            foreach(IInterval interval in sequence.Skip(1))
            {
                if(interval.Direction!=current.Direction)
                {
                    rep++;
                }
                else
                {
                    rep = 0;
                }
                current = interval;
            }

            return rep < 4 || !melodicsequence; // sequence
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
