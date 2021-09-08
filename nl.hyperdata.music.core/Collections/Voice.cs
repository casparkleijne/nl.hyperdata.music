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
        public Voice(IEnumerable<IPitch> pitches, double lowestfrequency, double highestfrequency) : base(pitches.Where(pitch=>(ElementBase)pitch >= lowestfrequency && (ElementBase)pitch <= highestfrequency))
        {
  
        }

        public IPitch Lowest => Context.Min();
        public IPitch Highest => Context.Max();
    }
}
