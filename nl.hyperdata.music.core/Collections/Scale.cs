using nl.hyperdata.music.core.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections
{
    public class Scale : CollectionBase<IPitch>, IScale
    {
        public Scale(IEnumerable<IPitch> pitches, IPitch root, IMode mode) : base(pitches.Where(p => mode.Select((_, n) => mode.Take(n).Aggregate(root, (q, i) => pitches.Transpose(q, i))).Any(s => p.Value % s.Value <= 0.00001)))
        {
            Mode = mode ?? throw new System.ArgumentNullException(nameof(mode));
            Root = root ?? throw new System.ArgumentNullException(nameof(root));
        }

        public IMode Mode { get; }
        public IPitch Root { get; }
    }
}