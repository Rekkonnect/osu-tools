namespace OsuFileTools.Core;

public static class FileInfoExtensions
{
    public static string ReadAllText(this FileInfo file)
    {
        return File.ReadAllText(file.FullName);
    }

    public static async Task<string> ReadAllTextAsync(this FileInfo file)
    {
        return await File.ReadAllTextAsync(file.FullName);
    }

    public static string[] ReadAllLines(this FileInfo file)
    {
        return File.ReadAllLines(file.FullName);
    }

    public static async Task<string[]> ReadAllLinesAsync(this FileInfo file)
    {
        return await File.ReadAllLinesAsync(file.FullName);
    }

    public static void WriteAllLines(this FileInfo file, string[] lines)
    {
        File.WriteAllLines(file.FullName, lines);
    }

    public static async Task WriteAllLinesAsync(this FileInfo file, string[] lines)
    {
        await File.WriteAllLinesAsync(file.FullName, lines);
    }
}
