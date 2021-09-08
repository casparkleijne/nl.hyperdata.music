using System;
using System.Collections.Generic;

namespace nl.hyperdata.music.core
{
    public class PitchSettings : IPitchSettings, IEquatable<PitchSettings>
    {
        public PitchSettings(double twelfthRootOfTwo = 1.0594630943592953,
                             double baseFrequency = 440,
                             int pitchIndexCorrection = -49)
        {
            TwelfthRootOfTwo = twelfthRootOfTwo;
            BaseFrequency = baseFrequency;
            PitchIndexCorrection = pitchIndexCorrection;
        }

        public double TwelfthRootOfTwo { get; }
        public double BaseFrequency { get; }
        public int PitchIndexCorrection { get; }


        public override bool Equals(object obj)
        {
            return Equals(obj as PitchSettings);
        }

        public bool Equals(PitchSettings other)
        {
            return other != null &&
                   TwelfthRootOfTwo == other.TwelfthRootOfTwo &&
                   BaseFrequency == other.BaseFrequency &&
                   PitchIndexCorrection == other.PitchIndexCorrection;
        }

        public override int GetHashCode()
        {
            int hashCode = -1819562086;
            hashCode = hashCode * -1521134295 + TwelfthRootOfTwo.GetHashCode();
            hashCode = hashCode * -1521134295 + BaseFrequency.GetHashCode();
            hashCode = hashCode * -1521134295 + PitchIndexCorrection.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(PitchSettings left, PitchSettings right)
        {
            return EqualityComparer<PitchSettings>.Default.Equals(left, right);
        }

        public static bool operator !=(PitchSettings left, PitchSettings right)
        {
            return !(left == right);
        }
    }
}
