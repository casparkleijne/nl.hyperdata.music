using System.Collections.Generic;

namespace nl.hyperdata.music.core.Collections
{
    public interface IScale : ICollectionBase<IPitch>
    {
        IMode Mode { get; }
        IPitch Root { get; }
    }
}