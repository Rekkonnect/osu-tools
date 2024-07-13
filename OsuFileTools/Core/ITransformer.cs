using OsuParsers.Beatmaps;

namespace OsuFileTools.Core;

internal interface ITransformer
{
    public abstract Beatmap Transform(Beatmap b);
}
