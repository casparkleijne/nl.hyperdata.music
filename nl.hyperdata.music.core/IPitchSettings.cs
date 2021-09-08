namespace nl.hyperdata.music.core
{
    public interface IPitchSettings
    {
        double BaseFrequency { get; }
        int PitchIndexCorrection { get; }
        double TwelfthRootOfTwo { get; }
    }
}