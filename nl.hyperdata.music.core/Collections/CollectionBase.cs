using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections
{
    public abstract class CollectionBase<T> : ICollectionBase<T>
    {
        public CollectionBase(IEnumerable<T> context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Count => Context.Count();

        public IEnumerable<T> Context { get; }

        public IEnumerator<T> GetEnumerator()
        {
            return Context.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Context).GetEnumerator();
        }

        public bool Equals(CollectionBase<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            throw new NotImplementedException();
        }
    }
}