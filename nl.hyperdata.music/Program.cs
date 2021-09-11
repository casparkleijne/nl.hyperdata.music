using nl.hyperdata.counterpoint;
using nl.hyperdata.counterpoint.Extensions;
using nl.hyperdata.music.core;
using nl.hyperdata.music.core.Collections.Diatonic;
using nl.hyperdata.music.core.Extensions;
using nl.hyperdata.music.midi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music
{
    /**
     *
     * 1. 8 to 16 notes long of equal value
    2. All notes must be diatonic
    3. Must start and end on tonic
        The product of all intervals in the sequence must be Unison
    4. Must end supertonic, tonic
        The second last interval must be a second descending
    5. Range of a Sth to a 10th

    6. Stepwise motion predominates though a few leaps are necessary
        number of intervals that are second > number of intervals that ae !second
    7. Leaps of a 4th or more must be compensated by a change in direction (most often stepwise)
    8. Must have a single melodic high point that is consonant with tonic
    9. Do not exceed 5 notes in the same direction

    10. No repeated notes in consecutive measures
        Unison intervals are not allowed
    11. No melodic intervals of 7ths or augmented or diminished intervals
        As it asys (combine with rule 10)
    12. Must not outline dissonant melodic intervals
        The product of consecutive intervals in the same direction must be consonant
    13. No trills (4 note pattern) or melodic sequences (3 or more note pattern)
        thrils x x x x

     *
     */

    internal class Program
    {
        private static readonly Random rng = new Random(DateTime.Now.Millisecond);
        private static readonly Player player = new Player();

        private static void Main()
        {
            Sequence sequence = new Sequence(ModernModes.Ionian);

            sequence
                .Add(IntervalNumber.Second, IntervalDirection.Ascending)
                .Add(IntervalNumber.Third, IntervalDirection.Ascending)
                .Add(IntervalNumber.Sixth, IntervalDirection.Ascending)
                .Add(IntervalNumber.Second, IntervalDirection.Descending)
                .Add(IntervalNumber.Second, IntervalDirection.Descending)
                .Add(IntervalNumber.Second, IntervalDirection.Descending)
                .Add(IntervalNumber.Third, IntervalDirection.Descending)
                .Add(IntervalNumber.Second, IntervalDirection.Ascending)
                .Add(IntervalNumber.Third, IntervalDirection.Descending)
                .Add(IntervalNumber.Second, IntervalDirection.Descending)
                .Add(IntervalNumber.Second, IntervalDirection.Descending);

            WriteSet("sequence", sequence);
            WriteSet("outline", sequence.Outline());

            Console.WriteLine(DiatonicIntervals.Default.FindProduct(sequence));

            WriteLine("CF--------------");
            WriteLine($"allRules { sequence.AllRules() }");
            WriteLine($"rule1 8 to 16 notes long of equal value  { sequence.Rule1() }");
            WriteLine($"rule2 All notes must be diatonic { sequence.Rule2() }");
            WriteLine($"rule3 Must start and end on tonic { sequence.Rule3() }");
            WriteLine($"rule4 Must end supertonic, tonic { sequence.Rule4() }");
            WriteLine($"rule5 Range of a Sth to a 10th { sequence.Rule5() }");
            WriteLine($"rule6 Stepwise motion predominates though a few leaps are necessary { sequence.Rule6() }");
            WriteLine($"rule7 Leaps of a 4th or more must be compensated by a change in direction (most often stepwise) { sequence.Rule7() }");
            WriteLine($"rule8 Must have a single melodic high point that is consonant with tonic { sequence.Rule8() }");
            WriteLine($"rule9 Do not exceed 5 notes in the same direction { sequence.Rule9() }");
            WriteLine($"rule10 No repeated notes in consecutive measures { sequence.Rule10() }");
            WriteLine($"rule11 No melodic intervals of 7ths or augmented or diminished intervals { sequence.Rule11() }");
            WriteLine($"rule12 Must not outline dissonant melodic intervals { sequence.Rule12() }");
            WriteLine($"rule13 No trills (4 note pattern) or melodic sequences (3 or more note pattern) { sequence.Rule13() }");

            //130.81

            var p = TwelveToneEqualTemperament.Default.Find(261.63);
            Console.WriteLine("M---------------");

            foreach (IInterval interval in sequence)
            {
                Console.WriteLine(p);
                Console.WriteLine(interval);
                player.Play(p, 400);

                p = TwelveToneEqualTemperament.Default.Transpose(p, interval);
            }

            Console.WriteLine(p);
            player.Play(p, 400);

            Console.ReadLine();
        }

        public static void WriteLine(string item)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (item.Contains("False"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(item);
        }

        public static void WriteSet<T>(string title, IEnumerable<T> items)
        {
            Console.WriteLine($"S--{title}--------------------------------");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"---------------------------------{title}--E");
        }
    }
}