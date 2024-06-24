using OsuParsers.Database.Objects;
using OsuRealDifficulty.UI.WinForms.Core;

namespace OsuRealDifficulty.UI.WinForms;

public partial class MainForm
{
    public class CurrentBeatmapSelection
    {
        private DbBeatmapSet? _beatmapSet;
        private DbBeatmap? _beatmap;

        public DbBeatmapSet? BeatmapSet
        {
            get
            {
                return _beatmapSet;
            }
            set
            {
                if (AreBeatmapSetsEqual(_beatmapSet, value))
                    return;

                _beatmapSet = value;
                BeatmapSetChanged?.Invoke(value);
            }
        }

        public DbBeatmap? Beatmap
        {
            get
            {
                return _beatmap;
            }
            set
            {
                if (AreBeatmapsEqual(_beatmap, value))
                    return;

                _beatmap = value;
                BeatmapChanged?.Invoke(value);
            }
        }

        public event Action<DbBeatmapSet?>? BeatmapSetChanged;
        public event Action<DbBeatmap?>? BeatmapChanged;

        public void Clear(bool raiseEvents)
        {
            if (raiseEvents)
            {
                BeatmapSet = null;
                Beatmap = null;
            }
            else
            {
                _beatmapSet = null;
                _beatmap = null;
            }
        }

        public static bool AreBeatmapSetsEqual(DbBeatmapSet? x, DbBeatmapSet? y)
        {
            return x?.SetId == y?.SetId;
        }
        public static bool AreBeatmapsEqual(DbBeatmap? x, DbBeatmap? y)
        {
            var definitelyEqual = AreDefinitelyEqual(x, y);
            if (definitelyEqual is not null)
            {
                return definitelyEqual.Value;
            }

            // enough checks -- we don't have to overdo it
            return x!.BeatmapId == y!.BeatmapId
                && x.Difficulty == y.Difficulty
                && x.BeatmapSetId == y.BeatmapSetId;
        }

        private static bool? AreDefinitelyEqual(object? x, object? y)
        {
            bool xn = x is null;
            bool yn = y is null;

            if (xn && yn)
                return true;

            if (xn ^ yn)
                return false;

            return null;
        }
    }
}
