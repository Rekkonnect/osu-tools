using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects.Mania;
using OsuParsers.Enums;
using OsuParsers.Enums.Beatmaps;
using System.Diagnostics;

namespace OsuFileTools.Core;

internal sealed class HitsoundExtractor(HitsoundExtractor.Options options)
    : ITransformer
{
    private readonly Options _options = options;

    public Beatmap Transform(Beatmap b)
    {
        if (b.GeneralSection.Mode is not Ruleset.Mania)
            throw new InvalidOperationException("Cannot use this tool on a non-mania map");

        var cloned = b.Clone();
        cloned.MetadataSection.Version = _options.HitsoundDifficultyName;
        int keyCount = _options.KeyCount;
        cloned.DifficultySection.ManiaKeyCount = keyCount;

        var clonedHitObjects = cloned.HitObjects;

        if (!_options.IncludeStoryboardSounds)
        {
            cloned.EventsSection.Storyboard.Clear();
        }

        var passedObjects = new HashSet<ObjectPosition>();

        for (int i = 0; i < clonedHitObjects.Count; i++)
        {
            var hitObject = clonedHitObjects[i] as BaseManiaNote;
            if (hitObject is null)
            {
                throw new UnreachableException("All hit objects in a mania map should be BaseManiaNote");
            }

            if (hitObject.HitSound is HitSoundType.None or HitSoundType.Normal)
            {
                clonedHitObjects.RemoveAt(i);
                i--;
                continue;
            }

            var column = ColumnForNote(hitObject);
            hitObject.SetColumn(keyCount, column);

            var passedPosition = new ObjectPosition(hitObject.StartTime, column);

            if (passedObjects.Contains(passedPosition))
            {
                clonedHitObjects.RemoveAt(i);
                i--;
                continue;
            }

            passedObjects.Add(passedPosition);

            if (_options.ConvertLongNotesToRice)
            {
                if (hitObject is ManiaHoldNote hold)
                {
                    var reduced = ReduceHoldToRice(hold);
                    clonedHitObjects[i] = reduced;
                    hitObject = reduced;
                }
            }
        }

        return cloned;
    }

    private static ManiaNote ReduceHoldToRice(ManiaHoldNote hold)
    {
        return new(
            hold.Position,
            hold.StartTime,
            hold.StartTime,
            hold.HitSound,
            hold.Extras,
            hold.IsNewCombo,
            hold.ComboOffset);
    }

    private int ColumnForNote(BaseManiaNote note)
    {
        var baseline = note.HitSound switch
        {
            HitSoundType.Normal => 0,
            HitSoundType.Whistle => 1,
            HitSoundType.Finish => 2,
            HitSoundType.Clap => 3,
            _ => 0,
        };

        var customSet = (int?)note.Extras?.SampleSet ?? 0;
        return baseline + customSet * 4;
    }

    private readonly record struct ObjectPosition(int Offset, int Column);

    public class Options
    {
        public required bool IncludeStoryboardSounds;
        public required bool ConvertLongNotesToRice;
        public required int KeyCount;
        public required string HitsoundDifficultyName;
    }
}
