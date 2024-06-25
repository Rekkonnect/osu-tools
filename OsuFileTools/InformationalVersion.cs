using Garyon.Extensions;
using System.Reflection;

namespace OsuFileTools;

// From Syndiesis
public sealed record InformationalVersion(string Version, string? CommitSha)
{
    public static InformationalVersion Parse(AssemblyInformationalVersionAttribute attribute)
    {
        return Parse(attribute.InformationalVersion);
    }

    public static InformationalVersion Parse(string versionString)
    {
        bool hasSplitter = versionString.AsSpan().SplitOnce('+', out var left, out var right);
        left.SplitOnce('-', out var realVersion, out _);
        if (hasSplitter)
        {
            return new(realVersion.ToString(), right.ToString());
        }

        return new(realVersion.ToString(), null);
    }

    public static InformationalVersion? InformationalVersionForAssembly(Assembly assembly)
    {
        var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        if (attribute is null)
            return null;

        return Parse(attribute);
    }
}
