using OsuParsers.Beatmaps;

namespace OsuRealDifficulty.Mania;

public static class CompleteBeatmapAnnotationAnalysis
{
    public static BeatmapAnnotationAnalysisDriver NewDriver(Beatmap beatmap)
    {
        var info = ManiaBeatmapInfoConstructor.Instance.CreateInfoForBeatmap(
            beatmap);
        return NewDriver(info);
    }
    public static BeatmapAnnotationAnalysisDriver NewDriver(
        ManiaBeatmapInfo beatmapInfo)
    {
        var driver = new BeatmapAnnotationAnalysisDriver(beatmapInfo);
        RegisterAnalyzers(driver);
        return driver;
    }

    private static void RegisterAnalyzers(BeatmapAnnotationAnalysisDriver driver)
    {
        // TODO: Revisit once analyzers are all implemented
        driver.Add([
            TrillPatternAnalyzer.Instance,
        ]);
    }
}
