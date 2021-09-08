﻿using nl.hyperdata.music.core;
using nl.hyperdata.music.core.Collections;
using nl.hyperdata.music.core.Collections.Diatonic;
using nl.hyperdata.music.core.Extensions;
using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;


namespace nl.hyperdata.counterpoint
{

    public class Sequence : IEnumerable<SequenceElement>
    {
        private static readonly DiatonicIntervals availableIntervals = new DiatonicIntervals();
        private readonly Stack<SequenceElement> elements = new Stack<SequenceElement>();

        public Sequence(IScale scale) : base()
        {
            Scale = scale;
        }
       
        public IEnumerable<IPitch> Melody => elements.Reverse().Select(x => x.Pitch);
        public IScale Scale { get; }
        public Sequence Begin(IPitch pitch)
        {
            elements.Clear();

            elements.Push(new SequenceElement
            {
                Pitch = pitch
            });

            return this;
        }
        public Sequence RemoveLast()
        {
            if (elements.Count() > 0)
            {
                elements.Pop();
            }
            return this;
        }
        public SequenceElement ElementAt(int index)
        {
            return elements.Reverse().ElementAt(index);
        }
        public SequenceElement First()
        {
            return elements.Reverse().FirstOrDefault();
        }
        public SequenceElement Last()
        {
            return elements.Reverse().LastOrDefault();
        }


        public IEnumerable<SequenceElement> Outline()
        {
            var u = elements.GroupAdjacent(x => x.Interval?.Direction)
                .Select(x => x.FirstOrDefault().Pitch);

            var result =  u.Zip(u.Skip(1), (p, v) =>
                new SequenceElement
                {
                    Pitch = p,
                    Interval = new DiatonicIntervals().Find(v, p)
                }
            ).Reverse();

            yield return elements.LastOrDefault();
            
            foreach(var elem in result)
            {
                yield return elem;
            }
        }

        public Sequence Append(IntervalNumber number, IntervalDirection direction)
        {
            // find all possible intervals that exists overall in the application
            IEnumerable<IInterval> possibles = availableIntervals.Find(number, direction);

            // find the specific interval that fits the scale;
            IInterval interval = Scale.TransposeInterval(elements.Peek().Pitch, possibles);

            // find the pich that is the result of the transposition
            IPitch pitch = Scale.Transpose(elements.Peek().Pitch, interval);

            if (pitch != null)
            {
                elements.Push(new SequenceElement
                {
                    Pitch = pitch,
                    Interval = interval
                });
            }

            return this;
        }

        public IEnumerator<SequenceElement> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}
