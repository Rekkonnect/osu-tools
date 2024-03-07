using OsuParsers.Beatmaps;

namespace OsuFileTools;

internal interface ITransformer
{
    public abstract Beatmap Transform(Beatmap b);
}

// A library is always good to use
#if FALSE


public sealed class TimingPointList
{
    public List<TimingPoint> TimingPoints { get; } = new();

    public EncapsulatedTimingPointList GetEncapsulations()
    {
        TimingPoints.Sort(TimingPoint.AscendingOffsetComparer.Instance);

        var result = new EncapsulatedTimingPointList();
        TimingPointEncapsulation encapsulation = new(null!, new());
        foreach (var timingPoint in TimingPoints)
        {
            if (timingPoint is BasedTimingPoint based)
            {
                var inheritedList = new List<InheritedTimingPoint>();
                // To add the previously registered inherited timing points
                if (encapsulation.Parent is null)
                {
                    inheritedList = encapsulation.InheritedPoints;
                }

                encapsulation = new(based, inheritedList);
                result.Encapsulations.Add(encapsulation);
            }
            else if (timingPoint is InheritedTimingPoint inherited)
            {
                encapsulation.InheritedPoints.Add(inherited);
            }
        }

        return result;
    }
}

public abstract class TimingPoint
{
    // Unknown values are represented as doubles to ensure that we do not
    // fail to parse potentially unexpected values

    public int Offset { get; set; }
    public double Value { get; set; }
    public double UnknownValue_2 { get; set; }
    public double UnknownValue_3 { get; set; }
    public double UnknownValue_4 { get; set; }
    public int SampleVolume { get; set; }
    public double UnknownValue_6 { get; set; }
    public bool KiaiMode { get; set; }

    public static TimingPoint Parse(SpanString line)
    {
        var rest = line;
        int offset = IterateSpanString(ref rest, ',').ParseInt32();
        double value = IterateSpanString(ref rest, ',').ParseDouble();

        var timingPoint = CreateTimingPointFromValue(value);
        timingPoint.Offset = offset;
        timingPoint.UnknownValue_2 = IterateSpanString(ref rest, ',').ParseDouble();
        timingPoint.UnknownValue_3 = IterateSpanString(ref rest, ',').ParseDouble();
        timingPoint.UnknownValue_4 = IterateSpanString(ref rest, ',').ParseDouble();
        timingPoint.SampleVolume = IterateSpanString(ref rest, ',').ParseInt32();
        timingPoint.UnknownValue_6 = IterateSpanString(ref rest, ',').ParseInt32();
        timingPoint.KiaiMode = IterateSpanString(ref rest, ',') is "1";

        return timingPoint;
    }

    private static TimingPoint CreateTimingPointFromValue(double value)
    {
        if (value < 0)
            return new InheritedTimingPoint { Value = value };

        return new BasedTimingPoint { Value = value };
    }

    private static SpanString IterateSpanString(ref SpanString source, char delimiter)
    {
        source.SplitOnce(delimiter, out var left, out source);
        return left;
    }

    public sealed class AscendingOffsetComparer : Comparer<TimingPoint>
    {
        public static AscendingOffsetComparer Instance { get; } = new();

        private AscendingOffsetComparer() { }

        public override int Compare(TimingPoint? x, TimingPoint? y)
        {
            return x!.Offset.CompareTo(y!.Offset);
        }
    }
}

public sealed class BasedTimingPoint : TimingPoint
{
    public double MillisecondsPerBeat => Value;
    public double BeatsPerSecond => 1 / MillisecondsPerBeat;
    public double Bpm => BeatsPerSecond * 60;
}

public sealed class InheritedTimingPoint : TimingPoint
{
    public double SliderVelocity => 100 / -Value;
}

#endif