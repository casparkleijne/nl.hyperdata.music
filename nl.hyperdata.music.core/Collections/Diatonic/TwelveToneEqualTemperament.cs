using System;
using System.Collections.Generic;
using System.Linq;

namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public class TwelveToneEqualTemperament : CollectionBase<IPitch>
    {
        private static readonly PitchSettings pitchSettings = new PitchSettings();

        public TwelveToneEqualTemperament(IPitchSettings settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public static Lazy<TwelveToneEqualTemperament> Default = new Lazy<TwelveToneEqualTemperament>(() => new TwelveToneEqualTemperament(pitchSettings));

        protected override IEnumerable<IPitch> Context => Enumerable.Range(1, 88)
             .Select(index => new Pitch(index, Math.Pow(Settings.TwelfthRootOfTwo, index + Settings.PitchIndexCorrection) * Settings.BaseFrequency));
        public IPitchSettings Settings { get; }


    }
}
