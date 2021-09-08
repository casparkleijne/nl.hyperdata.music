using System;
using System.Collections.Generic;

namespace nl.hyperdata.music.core.Collections
{
    public interface ICollectionBase<T> :  IEnumerable<T>, IReadOnlyCollection<T>, IEquatable<CollectionBase<T>>
    {
        IEnumerable<T> Context { get; }
    }
}