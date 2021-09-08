using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections
{
    public abstract class CollectionBase<T> : IEnumerable<T>, IReadOnlyCollection<T>, IEquatable<CollectionBase<T>>
    {

        public int Count => Context.Count();


        protected abstract IEnumerable<T> Context { get; }

        public IEnumerator<T> GetEnumerator()
        {
            return Context.GetEnumerator();
        }

        public T Find(Func<T, bool> expression)
        {
            return Context.FirstOrDefault(expression);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Context).GetEnumerator();
        }

        public bool Equals(CollectionBase<T> other)
        {
            throw new NotImplementedException();
        }
    }
}
