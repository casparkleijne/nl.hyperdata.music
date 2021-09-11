using System;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Extensions
{
    public static class ElementExtensions
    {
        public static T Find<T>(this IEnumerable<T> context, T element)
            where T : class, IElementBase
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return context.FirstOrDefault(p => p.Equals(element));
        }

        public static T Find<T>(this IEnumerable<T> context, double innervalue)
           where T : class, IElementBase
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.FirstOrDefault(p => p.Equals(innervalue));
        }
    }
}