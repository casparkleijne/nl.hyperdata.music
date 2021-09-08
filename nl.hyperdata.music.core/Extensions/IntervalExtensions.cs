using System;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Extensions
{
    public static class IntervalExtensions
    {

        public static IInterval Find(this IEnumerable<IInterval> context, IPitch start, IPitch end)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (start is null)
            {
                throw new ArgumentNullException(nameof(start));
            }

            if (end is null)
            {
                throw new ArgumentNullException(nameof(end));
            }

            return context.Find((ElementBase)end / (ElementBase)start);
        }

        public static IEnumerable<IInterval> Find(this IEnumerable<IInterval> context, IntervalNumber number, IntervalDirection direction)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.Where(i => i.Direction == direction && i.Number == number);
        }

    }
}
