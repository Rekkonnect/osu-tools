namespace OsuRealDifficulty.Mania;

public enum ChordListType : byte
{
    Source = 0,

    NonEmpty = 1 << 0,
    Normalized = 1 << 2,
}
