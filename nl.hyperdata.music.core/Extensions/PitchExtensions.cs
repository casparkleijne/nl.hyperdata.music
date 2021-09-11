using System;
using System.Collections.Generic;

namespace nl.hyperdata.music.core.Extensions
{
    public static class PitchExtensions
    {
        public static IPitch Transpose(this IEnumerable<IPitch> context, IPitch pitch, IInterval interval)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (pitch is null)
            {
                throw new ArgumentNullException(nameof(pitch));
            }

            if (interval is null)
            {
                throw new ArgumentNullException(nameof(interval));
            }

            return context.Find((ElementBase)pitch * (ElementBase)interval);
        }

        public static IInterval TransposeInterval(this IEnumerable<IPitch> context, IPitch pitch, IEnumerable<IInterval> intervals)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (pitch is null)
            {
                throw new ArgumentNullException(nameof(pitch));
            }

            if (intervals is null)
            {
                throw new ArgumentNullException(nameof(intervals));
            }

            foreach (var interval in intervals)
            {
                if (context.Transpose(pitch, interval) != null)
                {
                    return interval;
                }
            }

            return null;
        }
    }
}