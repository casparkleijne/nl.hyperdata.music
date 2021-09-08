using nl.hyperdata.counterpoint;
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
            TwelveToneEqualTemperament allPitches = TwelveToneEqualTemperament.Default.Value;

            IPitch root = allPitches.Find(261.6300000000000000);
            IPitch top = allPitches.Find(2093.000000000000000);

            //WriteSet("allpitches", allPitches);

            IMode mode = ModernModes.Ionian;
         //   WriteSet("mode ionian", mode);

            IVoice voice = new Voice(allPitches, root, top);
            WriteSet("voice soprano", voice);

            IScale scale = new Scale(root, mode, voice);
            WriteSet("currentscale", scale);

            Sequence sequence = new Sequence(scale);

            sequence.Begin(scale.Transpose(root, DiatonicIntervalsAscending.PerfectTwelveth))
                .Append(IntervalNumber.Second, IntervalDirection.Ascending)
                .Append(IntervalNumber.Second, IntervalDirection.Ascending)       
                .Append(IntervalNumber.Second, IntervalDirection.Descending)
                .Append(IntervalNumber.Third,  IntervalDirection.Descending)
                .Append(IntervalNumber.Third, IntervalDirection.Ascending)
                .Append(IntervalNumber.Second, IntervalDirection.Descending)
                .Append(IntervalNumber.Third,  IntervalDirection.Descending)
                .Append(IntervalNumber.Second, IntervalDirection.Descending)
                .Append(IntervalNumber.Second, IntervalDirection.Ascending)
                .Append(IntervalNumber.Second, IntervalDirection.Ascending)
                .Append(IntervalNumber.Second, IntervalDirection.Descending)
                .Append(IntervalNumber.Third, IntervalDirection.Descending)
                .Append(IntervalNumber.Third, IntervalDirection.Ascending)
                .Append(IntervalNumber.Second, IntervalDirection.Descending)
                .Append(IntervalNumber.Third, IntervalDirection.Descending)
                .Append(IntervalNumber.Second, IntervalDirection.Descending);



            var start = sequence.First();
            var end = sequence.Last();
            WriteSet("sequence", sequence.Reverse());

         //   player.Play(sequence.Select(x => x.Pitch), 300);

          //  Task.Delay(100).Wait();

            var outline = sequence.Outline().ToList();
      
          //  player.Play(outline.Select(x => x.Pitch), 300);
            
            WriteSet("outline", outline);

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
























































































































































































































































































































