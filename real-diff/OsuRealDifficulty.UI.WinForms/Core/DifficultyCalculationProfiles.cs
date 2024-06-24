using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty.UI.WinForms.Core;

internal sealed class DifficultyCalculationProfiles
{
    public static DifficultyCalculationProfiles Default => new()
    {
        Profiles =
        {
            // TODO: Fix for more keys
            [1] = DifficultyCalculationProfile_4K.Instance,
            [2] = DifficultyCalculationProfile_4K.Instance,
            [3] = DifficultyCalculationProfile_4K.Instance,
            [4] = DifficultyCalculationProfile_4K.Instance,
            [5] = DifficultyCalculationProfile_4K.Instance,
            [6] = DifficultyCalculationProfile_4K.Instance,
            [7] = DifficultyCalculationProfile_4K.Instance,
            [8] = DifficultyCalculationProfile_4K.Instance,
            [9] = DifficultyCalculationProfile_4K.Instance,
        }
    };

    public DifficultyCalculationProfile FallbackProfile
        = DifficultyCalculationProfile_4K.Instance;

    public Dictionary<int, DifficultyCalculationProfile> Profiles = new();

    public DifficultyCalculationProfile ProfileForKeys(int keys)
    {
        return Profiles.GetValueOrDefault(keys, FallbackProfile);
    }
}
