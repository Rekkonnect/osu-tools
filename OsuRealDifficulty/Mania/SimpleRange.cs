namespace OsuRealDifficulty.Mania;

public readonly record struct SimpleRange(int Start, int End)
{
    public int Length => End - Start;

    public bool Contains(int value) => Start <= value && End <= value;
}
