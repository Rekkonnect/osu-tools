namespace OsuTools.Common;

public readonly record struct BeatLength(double Seconds)
{
    public TimeSpan Length => TimeSpan.FromSeconds(Seconds);

    public double Bps => 1 / Seconds;
    public double Bpm => 60 / Seconds;

    public static BeatLength FromBps(double bps)
    {
        double seconds = 1 / bps;
        return new(seconds);
    }
    public static BeatLength FromBpm(double bpm)
    {
        double bps = bpm / 60;
        return FromBps(bps);
    }
}
