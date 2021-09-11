using System;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Extensions
{
    public static class IntervalExtensions
    {
        public static IEnumerable<IInterval> Find(this IEnumerable<IInterval> context, IntervalDirection direction, IntervalNumber number)
        {
            return context.Where(x => x.Direction == direction && x.Number == number);
        }

        public static IInterval Find(this IEnumerable<IInterval> context, IntervalDirection direction, IntervalQuality quality, IntervalNumber number)
        {
            return context.Find(direction, number).FirstOrDefault(x => x.Quality == quality);
        }

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

        public static IInterval FindProduct(this IEnumerable<IInterval> context, IEnumerable<IInterval> intervals)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (intervals is null)
            {
                throw new ArgumentNullException(nameof(intervals));
            }
            if (intervals.Count() == 0)
            {
                return context.Find(1);
            }

            return intervals.Aggregate((x, a) => context.Find((ElementBase)x * a));
        }

        public static IInterval FindProduct(this IEnumerable<IInterval> context, IInterval left, IInterval right)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (left is null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right is null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            return context.Find((ElementBase)left * right);
        }
    }
}