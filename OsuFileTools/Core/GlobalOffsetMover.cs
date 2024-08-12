using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;

namespace OsuFileTools.Core;

public sealed class GlobalOffsetMover(
    GlobalOffsetMover.Options options)
    : ITransformer
{
    private readonly Options _options = options;

    public Beatmap Transform(Beatmap b)
    {
        if (_options.IsNoOp)
            return b;

        var clone = b.Clone();

        // Timing points
        foreach (var timingPoint in clone.TimingPoints)
        {
            TransformTimingPoint(timingPoint);
        }

        // Hit objects
        foreach (var hitObject in clone.HitObjects)
        {
            TransformHitObject(hitObject);
        }

        // Bookmarks
        int[]? bookmarks = clone.EditorSection.Bookmarks;
        for (int i = 0; i < bookmarks?.Length; i++)
        {
            ref int bookmark = ref bookmarks[i];
            TransformOffset(ref bookmark);
        }

        // Preview time
        int previewTime = clone.GeneralSection.PreviewTime;
        TransformOffset(ref previewTime);
        clone.GeneralSection.PreviewTime = previewTime;

        // Storyboards not supported at the time

        return clone;
    }

    // Behold lovely copy-paste
    private void TransformOffset(ref int offset)
    {
        if (offset < _options.OffsetStart)
            return;

        if (offset > _options.OffsetEnd)
            return;

        offset += (int)_options.MoveBy;
    }

    private void TransformTimingPoint(TimingPoint timingPoint)
    {
        if (timingPoint.Offset < _options.OffsetStart)
            return;

        if (timingPoint.Offset > _options.OffsetEnd)
            return;

        timingPoint.Offset += _options.MoveBy;
    }

    private void TransformHitObject(HitObject hitObject)
    {
        TransformHitObjectStartTime(hitObject);
        TransformHitObjectEndTime(hitObject);
    }

    private void TransformHitObjectEndTime(HitObject hitObject)
    {
        if (hitObject.EndTime < _options.OffsetStart)
            return;

        if (hitObject.EndTime > _options.OffsetEnd)
            return;

        hitObject.EndTime += (int)_options.MoveBy;
    }

    private void TransformHitObjectStartTime(HitObject hitObject)
    {
        if (hitObject.StartTime < _options.OffsetStart)
            return;

        if (hitObject.StartTime > _options.OffsetEnd)
            return;

        hitObject.StartTime += (int)_options.MoveBy;
    }

    public sealed class Options
    {
        public double OffsetStart;
        public double OffsetEnd;
        public double MoveBy;

        public double OffsetLength => OffsetEnd - OffsetStart;

        public bool IsNoOp
        {
            get
            {
                return OffsetLength is 0
                    || MoveBy is 0
                    ;
            }
        }
    }
}
