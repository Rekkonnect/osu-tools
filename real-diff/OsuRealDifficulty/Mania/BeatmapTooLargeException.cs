namespace OsuRealDifficulty.Mania;

public sealed class BeatmapTooLargeException : Exception
{
    public Beatmap? Beatmap
    {
        get
        {
            return Data[typeof(Beatmap)] as Beatmap;
        }
        private set
        {
            Data[typeof(Beatmap)] = value;
        }
    }

    public BeatmapTooLargeException(Beatmap? beatmap, string message)
        : base(message)
    {
        Beatmap = beatmap;
    }
}
