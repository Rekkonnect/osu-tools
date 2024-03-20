namespace OsuRealDifficulty.Mania;

public static class OddKeyNormalization
{
    /// <summary>
    /// Normalizes the odd-key chord list into an even-key chord list, accounting
    /// for alternating the hands for the special middle column.
    /// </summary>
    /// <param name="oddKeyChordList">
    /// The odd key chord list. Providing an even key chord list will
    /// return <see langword="null"/>.
    /// </param>
    /// <returns>
    /// If the given chord list is for a field with an even key count,
    /// <see langword="null"/> is returned. Otherwise, a newly created chord
    /// list is returned.
    /// </returns>
    public static ChordList? NormalizeWithAlternateHands(ChordList oddKeyChordList)
    {
        return CanonicalHandOddKeyChordListNormalizer.Instance
            .Normalize(oddKeyChordList);
    }
}
