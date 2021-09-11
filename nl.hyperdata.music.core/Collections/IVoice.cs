namespace nl.hyperdata.music.core.Collections
{
    public interface IVoice : ICollectionBase<IPitch>
    {
        /**
        Soprano: B3(A3) - D6 (246.942 - 1174.66Hz). Some coloratua soprano roles go up to A6 (1760Hz)
        Mezzo-soprano: G3 - C6 (195.998 - 1046.5Hz)
        Alto (Contralto): E3 - Bb5 (164.814 - 932.328Hz)
        Treble (Boy soprano): A3 - A5 (220 - 880Hz)
        Countertenor: G3 - F5 (195.998 - 698.456Hz)
        Tenor: Bb2 - G5 (116.541 - 783.991Hz)
        Baritone: G2 - A4 (97.998 - 440Hz)
        Basso: C2 - G4 (65.4064 - 391.995Hz)
        */
        IPitch Lowest { get; }
        IPitch Highest { get; }
    }
}