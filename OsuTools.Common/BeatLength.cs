namespace OsuTools.Common;

public readonly record struct BeatLength(double Length)
{
    public double Bps => 1 / Length;
    public double Bpm => Bps * 60;

    public static BeatLength FromBps(double bps)
    {
        double length = 1 / bps;
        return new(length);
    }
    public static BeatLength FromBpm(double bpm)
    {
        double bps = bpm / 60;
        return FromBps(bps);
    }
}
