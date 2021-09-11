using System;
using System.Configuration;

namespace nl.hyperdata.music.core.Collections.Diatonic
{
    public sealed class Config
    {
        public static double TwelfthRootOfTwo => Math.Pow(2, 1.00 / 12.00);
        public static readonly string[] KeyNames = new string[] { "A", "A#,Bb", "B", "C", "C#,Db", "D", "D#,Eb", "E", "F", "F#,Gb", "G", "G#,Ab" };
        public static readonly double BaseFrequency = double.Parse(ConfigurationManager.AppSettings["baseFrequency"]);
        public static readonly int OctaveCount = 8;
        public static readonly int PitchIndexCorrection = (4 * -12) - 1;
        public static readonly int ScaleStepCorrection = -28;
    }
}