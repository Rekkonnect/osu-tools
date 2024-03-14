namespace OsuRealDifficulty.Mania;

// NOTE: This does not handle simultaneously appearing patterns
// This might be handled from another subcategory of Tech in the future
public record PatternSwitchAnnotation(
    int OffsetStart, int OffsetEnd,
    MapAnnotationType FirstPatternType, MapAnnotationType SecondPatternType)
    : IPattern
{
    public MapAnnotationType Type => MapAnnotationType.PatternSwitch;
}
