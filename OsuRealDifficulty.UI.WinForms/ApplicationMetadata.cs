using System.Reflection;

namespace OsuRealDifficulty.UI.WinForms;

public static class ApplicationMetadata
{
    public const string Name = "osu!mania difficulty analyzer";

    public static GitInformation GitInfo
        => GitInformation.GetAssemblyInstance(typeof(ApplicationMetadata));

    static ApplicationMetadata()
    {
        GitInformation.ApplyAssemblyAttributes(ThisAssembly);
    }

    public static Assembly ThisAssembly => typeof(ApplicationMetadata).Assembly;

    public static string? CurrentVersion => ThisAssembly
        .GetCustomAttribute<AssemblyFileVersionAttribute>()
        ?.Version;

    public static string VersionString => $"v{CurrentVersion}-{GitInfo.Commit}";

    public static string FullTitle => $"{Name} [{VersionString}]";
}
