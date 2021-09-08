using System;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public class TwelveToneEqualTemperament : CollectionBase<IPitch>
    {
        public TwelveToneEqualTemperament(IPitchSettings settings)
        {
            Settings = settings;
        }

        public static TwelveToneEqualTemperament Default
        {
            get
            {
                return new TwelveToneEqualTemperament(new PitchSettings());
            }
        }
        protected override IEnumerable<IPitch> Context => Enumerable.Range(1, 88)
             .Select(index => new Pitch(index, Math.Pow(Settings.TwelfthRootOfTwo, index + Settings.PitchIndexCorrection) * Settings.BaseFrequency));
        public IPitchSettings Settings { get; }


    }
}
