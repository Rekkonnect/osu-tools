using Garyon.Extensions;

namespace OsuFileTools.Core;

public sealed class BeatmapCreatorRenamer(
    BeatmapCreatorRenamer.Options options)
    : IRawFileTransformer, IMassOperation
{
    private readonly Options _options = options;

    public MassOperationProgressOverview ProgressOverview { get; } = new();

    public void Transform(FileInfo beatmapFile)
    {
        var lines = beatmapFile.ReadAllLines();
        bool renamed = Rename(lines);
        if (renamed && _options.CreateBackup)
        {
            var backupFilePath = $"{beatmapFile.FullName}.bak";
            beatmapFile.CopyTo(backupFilePath);
        }
        beatmapFile.WriteAllLines(lines);

        ProgressOverview.Report(
            renamed
                ? OperationOutcome.Success
                : OperationOutcome.Skip);
    }

    private bool Rename(string[] fullFileLines)
    {
        for (int i = 0; i < fullFileLines.Length; i++)
        {
            ref var line = ref fullFileLines[i];

            const string creatorProperty = "Creator:";
            bool matches = line.AsSpan().SplitOnce(creatorProperty, out _, out var value);
            if (matches)
            {
                value = value.Trim();
                bool matchesUsername = value.Equals(_options.Old, StringComparison.OrdinalIgnoreCase);
                if (!matchesUsername)
                {
                    // we found a map from another creator, so we do not act on it
                    return false;
                }

                line = $"{creatorProperty}{_options.New}";
                return true;
            }
        }

        return false;
    }

    public sealed class Options
    {
        public required string Old;
        public required string New;
        public required bool CreateBackup;
    }
}
