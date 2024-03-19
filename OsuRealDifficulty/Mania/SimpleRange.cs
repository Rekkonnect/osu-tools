namespace OsuRealDifficulty.Mania;

public readonly record struct SimpleRange(int Start, int End)
{
    public int Length => End - Start + 1;

    public bool Contains(int value) => Start <= value && value <= End;
}
