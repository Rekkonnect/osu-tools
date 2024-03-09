﻿namespace OsuRealDifficulty.Mania;

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

        // TODO: Revisit once analyzers are all implemented
        driver.Add([
            ChordAnnotationAnalyzer.Instance,
            SpeedAnnotationAnalyzer.Instance,
            SinglestreamPatternAnalyzer.Instance,
            TrillPatternAnalyzer.Instance,
        ]);

        driver.Add([
            PatternTypeSwitchAnnotationAnalyzer.Instance,
        ]);
    }
}
