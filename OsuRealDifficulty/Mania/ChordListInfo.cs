namespace OsuRealDifficulty.Mania;

public class ChordListInfo
{
    public required ChordList ChordList { get; init; }
    public required ChordPressColumnsList PressColumns { get; init; }
    public required ChordPressColumnsList NonEmptyPressColumns { get; init; }
}
