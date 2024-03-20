namespace OsuRealDifficulty.Mania;

public abstract class OddKeyChordListNormalizer
{
    public ChordList? Normalize(ChordList list)
    {
        if (!list.IsOddKey)
        {
            return null;
        }

        return NormalizeCore(list);
    }

    protected abstract ChordList NormalizeCore(ChordList list);
}
