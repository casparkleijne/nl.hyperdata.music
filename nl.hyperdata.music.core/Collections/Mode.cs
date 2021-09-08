using System.Collections.Generic;

namespace nl.hyperdata.music.core.Collections
{
    internal class Mode : CollectionBase<IInterval>, IMode
    {
        public Mode(IEnumerable<IInterval> intervals)
        {
            Context = intervals;
        }

        protected override IEnumerable<IInterval> Context { get; }


    }
}
