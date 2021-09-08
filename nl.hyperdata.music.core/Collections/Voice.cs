using System;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections
{

    /// <summary>
    /// The voice.
    /// </summary>
    /// 
    public class Voice : CollectionBase<IPitch>, IVoice
    {
        public Voice(IEnumerable<IPitch> pitches, double lowestfrequency, double highestfrequency) : base(pitches.Where(pitch => (ElementBase)pitch >= lowestfrequency && (ElementBase)pitch <= highestfrequency))
        {

        }


        public IPitch Lowest => Context.Min();
        public IPitch Highest => Context.Max();

        public static IVoice Soprano(IEnumerable<IPitch> pitches)
        {
            return new Voice(pitches, 246.942, 1174.66);
        }

        public static IVoice MezzoSoprano(IEnumerable<IPitch> pitches)
        {
            return new Voice(pitches, 195.998, 1046.5);
        }

        public static IVoice Alto(IEnumerable<IPitch> pitches)
        {
            return new Voice(pitches, 164.814, 932.328);
        }

        public static IVoice Treble(IEnumerable<IPitch> pitches)
        {
            return new Voice(pitches, 220, 880);
        }

        public static IVoice Tenor(IEnumerable<IPitch> pitches)
        {
            return new Voice(pitches, 246.942, 1174.66);
        }

        public static IVoice Baritone(IEnumerable<IPitch> pitches)
        {
            return new Voice(pitches, 97.998, 440);
        }

        public static IVoice Basso(IEnumerable<IPitch> pitches)
        {
            return new Voice(pitches, 65.4064, 391.995);
        }
    }
}
