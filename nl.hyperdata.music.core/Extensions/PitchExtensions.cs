using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Extensions
{
    public static class PitchExtensions
    {
        public static IPitch Find(this IEnumerable<IPitch> context, IPitch pitch)
        {
            return context.FirstOrDefault(p => p.Equals(pitch));
        }
        public static IPitch Find(this IEnumerable<IPitch> context, double frequency)
        {
            return context.FirstOrDefault(p => p.Equals(frequency));
        }

        public static IPitch Transpose(this IEnumerable<IPitch> context, IPitch pitch, IInterval interval)
        {
            if (interval == null)
            {
                return null;
            }

            if (pitch == null)
            {
                return null;
            }

            return Find(context, pitch.Frequency * interval.Ratio);
        }

        public static IInterval TransposeInterval(this IEnumerable<IPitch> context, IPitch pitch, IEnumerable<IInterval> intervals)
        {
            return intervals
                .Where(i => Find(context, pitch.Frequency * i.Ratio) != null)
                .FirstOrDefault();
        }

        public static IPitch TransposeFirstOrDefault(this IEnumerable<IPitch> context, IPitch pitch, IEnumerable<IInterval> intervals)
        {
            if (pitch == null)
            {
                return null;
            }
            return intervals
                .Select(i => Find(context, pitch.Frequency * i.Ratio))
                .FirstOrDefault(i => i != null);
        }

        public static IEnumerable<IPitch> FilterIncremental(this IEnumerable<IPitch> context, IEnumerable<IInterval> intervals, IPitch root)
        {
            return intervals.Select((_, n) =>
              intervals.Take(n).Aggregate(root, (a, i) => context.Transpose(a, i)));
        }

    }
}
