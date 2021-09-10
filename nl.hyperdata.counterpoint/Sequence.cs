using nl.hyperdata.music.core;
using nl.hyperdata.music.core.Collections;
using nl.hyperdata.music.core.Collections.Diatonic;
using nl.hyperdata.music.core.Extensions;
using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;
using nl.hyperdata.counterpoint.Extensions;
using System.Collections;

namespace nl.hyperdata.counterpoint
{

    public class Sequence : IEnumerable<IInterval>
    {
        private static readonly DiatonicIntervals availableIntervals = new DiatonicIntervals();
        private readonly Stack<IInterval> stack = new Stack<IInterval>();

        public IMode Mode { get; }

        public Sequence(IMode mode) : base()
        {
            Mode = mode;
        }

        public bool IsValid()
        {
            return this.Rule1() && 
                this.Rule2() && 
                this.Rule3();
        }

        /**
        public IEnumerable<SequenceElement> Outline()
        {
            var u = elements.GroupAdjacent(x => x.Direction);


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
        **/


        public Sequence Append(IntervalNumber number, IntervalDirection direction)
        {
            if(stack.Count() == 0)
            {

            }
            var current = stack.Peek();


            

            return this;
        }

        public IEnumerator<IInterval> GetEnumerator()
        {
            return ((IEnumerable<IInterval>)stack).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)stack).GetEnumerator();
        }
    }
}
