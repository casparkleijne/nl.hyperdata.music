using nl.hyperdata.music.core;

namespace nl.hyperdata.counterpoint
{
    public class SequenceElement
    {        
        public IInterval Interval { get; set; }
        public IPitch Pitch { get; set; }

        public override string ToString()
        {
            return $"{Interval} {Pitch}".TrimStart();
        }

    }
}
