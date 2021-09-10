using nl.hyperdata.counterpoint;
using nl.hyperdata.counterpoint.Extensions;
using nl.hyperdata.music.core;
using nl.hyperdata.music.core.Collections;
using nl.hyperdata.music.core.Collections.Diatonic;
using nl.hyperdata.music.core.Extensions;
using nl.hyperdata.music.midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nl.hyperdata.music
{
    /**
     * 
     * 1. 8 to 16 notes long of equal value 
    2. All notes must be diatonic
    3. Must start and end on tonic
    4. Must end supertonic, tonic
    5. Range of a Sth to a 10th
    6. Stepwise motion predominates though a few leaps are necessary
    7. Leaps of a 4th or more must be compensated by a change in direction (most often stepwise)
    8. Must have a single melodic high point that is consonant with tonic
    9. Do not exceed 5 notes in the same direction
    10. No repeated notes in consecutive measures
    11. No melodic intervals of 7ths or augmented or diminished intervals
    12. Must not outline dissonant melodic intervals
    13. No trills (4 note pattern) or melodic sequences (3 or more note pattern)

     * 
     */


    internal class Program
    {
        private static readonly Random rng = new Random(DateTime.Now.Millisecond);
        private static readonly Player player = new Player();

        private static void Main()
        {

            WriteSet("allintervals", DiatonicIntervals.Default);
            
            IPitch root = TwelveToneEqualTemperament.Default.Find(16.350000);


            
            Sequence sequence = new Sequence(ModernModes.Ionian);

            sequence
                .Append(IntervalNumber.Second, IntervalDirection.Ascending)
                .Append(IntervalNumber.Second, IntervalDirection.Ascending)               
                .Append(IntervalNumber.Second, IntervalDirection.Ascending)
                .Append(IntervalNumber.Second, IntervalDirection.Ascending)              
                .Append(IntervalNumber.Second, IntervalDirection.Ascending)
                .Append(IntervalNumber.Second, IntervalDirection.Descending)               
                .Append(IntervalNumber.Second, IntervalDirection.Descending)
                .Append(IntervalNumber.Second, IntervalDirection.Descending)             
                .Append(IntervalNumber.Second, IntervalDirection.Descending)
                .Append(IntervalNumber.Second, IntervalDirection.Descending);

            WriteSet("sequence", sequence);



            Console.WriteLine();
            Console.WriteLine("CF--------------");
            Console.WriteLine($"allRules { sequence.AllRules() }");
            Console.WriteLine($"rule1 { sequence.Rule1() }");
            Console.WriteLine($"rule2 { sequence.Rule2() }");
            Console.WriteLine($"rule3 { sequence.Rule3() }");
            Console.WriteLine($"rule4 { sequence.Rule4() }");
            Console.WriteLine($"rule5 { sequence.Rule5() }");      
            Console.WriteLine($"rule6 { sequence.Rule6() }");



            //   player.Play(sequence.Select(x => x.Pitch), 300);

            //  Task.Delay(100).Wait();



            Console.ReadLine();

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
























































































































































































































































































































