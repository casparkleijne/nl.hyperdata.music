using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Extensions
{
    public static class IntervalExtensions
    {
        public static IInterval Find(this IEnumerable<IInterval> context, IInterval interval)
        {
            return context.FirstOrDefault(i => i.Equals(interval));
        }

        public static IInterval Find(this IEnumerable<IInterval> context, double ratio)
        {
            return context.FirstOrDefault(p => p.Equals(ratio));
        }
        public static IInterval FindOpposite(this IEnumerable<IInterval> context, double ratio)
        {
            return context.FirstOrDefault(p => p.Equals(1.00 / ratio));
        }

        public static IInterval Find(this IEnumerable<IInterval> context, IPitch start, IPitch end)
        {
            return Find(context, end.Frequency / start.Frequency);
        }
        public static IEnumerable<IInterval> Find(this IEnumerable<IInterval> context, IntervalNumber number, Direction direction)
        {
            return context.Where(i => i.Direction == direction && i.Number == number);
        }

    }
}
