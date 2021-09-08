using System.Collections.Generic;

namespace nl.hyperdata.music.core.Collections
{
    public interface IScale : IEnumerable<IPitch>
    {
        IMode Mode { get; }
        IPitch Root { get; }
    }
}