using System;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections
{
    public class Voice : CollectionBase<IPitch>, IVoice
    {
        public Voice(IEnumerable<IPitch> pitches, IPitch lowest, IPitch highest)
        {
            if (pitches is null)
            {
                throw new ArgumentNullException(nameof(pitches));
            }

            Lowest = lowest ?? throw new ArgumentNullException(nameof(lowest));
            Highest = highest ?? throw new ArgumentNullException(nameof(highest));

            var o = lowest.Equals(highest);



            Context = pitches
                .SkipWhile(p => !p.Equals(lowest))
                .TakeWhile(p => !p.Equals(highest)).ToList();

            if(Context.Count()== 0)
            {
                throw new ArgumentException(nameof(pitches));
            }
        }



        public IPitch Lowest { get; }
        public IPitch Highest { get; }
        protected override IEnumerable<IPitch> Context { get; }

    }
}
