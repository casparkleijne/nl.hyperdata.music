using nl.hyperdata.music.core;
using nl.hyperdata.music.core.Collections;
using nl.hyperdata.music.core.Collections.Diatonic;
using nl.hyperdata.music.core.Extensions;
using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;
using nl.hyperdata.counterpoint.Extensions;
using System.Collections;
using System;

namespace nl.hyperdata.counterpoint
{

    public class Sequence : IEnumerable<IInterval>
    {

        private readonly Stack<IInterval> stack = new Stack<IInterval>();

        public IMode Mode { get; }

        public Sequence(IMode mode) : base()
        {
            Mode = mode;
        }

 
        public Sequence Prepend(IntervalNumber number, IntervalDirection direction)
        {
            IInterval stackProduct = DiatonicIntervals.Default.FindProduct(stack);

            foreach (var interval in DiatonicIntervals.Default.Find(direction,number))
            {

                if(stackProduct == null)
                {

                }
                var testresult = DiatonicIntervals.Default.FindProduct(stackProduct, interval);
           
                if(Mode.Find( testresult) != null)
                {
                    stack.Push(interval);
                }
            }
            return this;
        }

        public IEnumerator<IInterval> GetEnumerator()
        {
            return ((IEnumerable<IInterval>)stack).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
