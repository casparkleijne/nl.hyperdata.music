
using nl.hyperdata.music.core.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections
{
    public class Scale : CollectionBase<IPitch>, IScale
    {
        public Scale(IPitch root, IMode mode, IEnumerable<IPitch> pitches)
        {
            Mode = mode;
            Root = root;
            Context = pitches.Where(p => mode.Select((_, n) =>
              mode.Take(n).Aggregate(root, (q, i) => pitches.Transpose(q, i)))
                .Any(s => p.Frequency % s.Frequency <= 0.00001));
        }

        public IMode Mode { get; }
        public IPitch Root { get; }
        protected override IEnumerable<IPitch> Context { get; }
    }
}
