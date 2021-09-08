using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections
{
    public class Voice : CollectionBase<IPitch>, IVoice
    {
        public Voice(IEnumerable<IPitch> pitches, IPitch lowest, IPitch highest)
        {
            Lowest = lowest;
            Highest = highest;
            Context = pitches
                .SkipWhile(p => !p.Equals(lowest))
                .TakeWhile(p => !p.Equals(highest));
        }



        public IPitch Lowest { get; }
        public IPitch Highest { get; }
        protected override IEnumerable<IPitch> Context { get; }

    }
}
