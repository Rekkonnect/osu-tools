namespace OsuRealDifficulty.Mania;

public static class CompleteBeatmapAnnotationAnalysis
{
    public static BeatmapAnalyzerDriver NewDriver(Beatmap beatmap)
    {
        var info = ManiaBeatmapInfoConstruction.Instance.CreateInfoForBeatmap(
            beatmap);
        return NewDriver(info);
    }
    public static BeatmapAnalyzerDriver NewDriver(
        ManiaBeatmapInfo beatmapInfo)
    {
        var driver = new BeatmapAnalyzerDriver(beatmapInfo);
        RegisterAnalyzers(driver);
        return driver;
    }

    private static void RegisterAnalyzers(BeatmapAnalyzerDriver driver)
    {
        // IMPORTANT: The Add steps cannot be merged due to dependencies on
        // previous analyzers having finished executing
        // For example, PatternSwitchAnnotationAnalyzer depends on all the other
        // analyzers having detected their pattern switches and therefore being
        // given access to the annotations they have emitted

        // TODO: Consider the alternative of automatically discovering all available
        // analyzers and calculating their dependency graph via reflection
        // Currently this is not chosen due to the limited and non-expandable scope
        // of the feature

        // TODO: Revisit once analyzers are all implemented

        driver.Add([
            ChordAnnotationAnalyzer.Instance,
            SpeedDifficultyAnalyzer.Instance,
            SinglestreamPatternAnalyzer.Instance,
            TrillPatternAnalyzer.Instance,
            JackPatternAnalyzer.Instance,
        ]);

        driver.Add([
            AnchorPatternDifficultyAnalyzer.Instance,
            MinijackPatternDifficultyAnalyzer.Instance,
            ChordjackPatternDifficultyAnalyzer.Instance,
            FieldjackPatternDifficultyAnalyzer.Instance,
        ]);

        //driver.Add([
        //    PatternSwitchAnnotationAnalyzer.Instance,
        //]);
    }
}
