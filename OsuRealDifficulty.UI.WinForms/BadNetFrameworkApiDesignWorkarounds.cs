using System.Collections;
using System.Globalization;
using System.Resources;

namespace OsuRealDifficulty.UI.WinForms;

public static class BadNetFrameworkApiDesignWorkarounds
{
    public static IEnumerable<KeyValuePair<string, object?>> EnumerateResources(
        this ResourceManager resourceManager, CultureInfo cultureInfo)
    {
        var resourceSet = resourceManager
            .GetResourceSet(cultureInfo, true, true)!;

        foreach (DictionaryEntry entry in resourceSet)
        {
            var resourceKey = entry.Key.ToString()!;
            var resource = entry.Value;
            yield return new(resourceKey, resource);
        }
    }
}
