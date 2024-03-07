using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;

namespace OsuTools.Common;

public sealed class TimingPointList
{
    public List<TimingPoint> TimingPoints { get; } = new();

    public EncapsulatedTimingPointList GetEncapsulations()
    {
        TimingPoints.Sort(AscendingOffsetComparer.Instance);

        var result = new EncapsulatedTimingPointList();
        TimingPointEncapsulation encapsulation = new(null!, new());
        foreach (var timingPoint in TimingPoints)
        {
            if (timingPoint.Inherited is true)
            {
                encapsulation.InheritedPoints.Add(timingPoint);
            }
            else
            {
                var inheritedList = new List<TimingPoint>();
                // To add the previously registered inherited timing points
                var previousEncapsulation = encapsulation;
                if (previousEncapsulation.Parent is null)
                {
                    inheritedList = previousEncapsulation.InheritedPoints;
                }

                previousEncapsulation.EndOffset = timingPoint.Offset;
                encapsulation = new(timingPoint, inheritedList);
                result.Encapsulations.Add(encapsulation);
            }
        }

        return result;
    }

    public static TimingPointList FromBeatmap(Beatmap beatmap)
    {
        var list = new TimingPointList();
        list.TimingPoints.AddRange(beatmap.TimingPoints);
        return list;
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
