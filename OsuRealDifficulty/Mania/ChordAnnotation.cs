﻿namespace OsuRealDifficulty.Mania;

public record ChordAnnotation(int Offset, int NoteCount)
    : ISinglePointAnnotation
{
    public MapAnnotationType Type => MapAnnotationType.Chord;
}

public record ChordjackAnnotation(
    int FirstOffset,
    int SecondOffset,
    BitVector32 PressColumns)
    : ITwoNotePattern
{
    public MapAnnotationType Type => MapAnnotationType.Chordjack;

    public int OffsetStart => FirstOffset;
    public int OffsetEnd => SecondOffset;

    public int Length => OffsetEnd - OffsetStart;
    public int ColumnCount => PressColumns.PopCount();
    public int NoteCount => ColumnCount * 2;
}

public record MinijackAnnotation(
    int FirstOffset,
    int SecondOffset,
    BitVector32 Columns)
    : ITwoNotePattern
{
    public MapAnnotationType Type => MapAnnotationType.Minijack;

    public int TimeDistance => SecondOffset - FirstOffset;
    public int OffsetStart => FirstOffset;
    public int OffsetEnd => SecondOffset;
    public int ColumnCount => Columns.PopCount();
    public int NoteCount => ColumnCount * 2;
}

public record AnchorPattern(
    int OffsetStart,
    int OffsetEnd,
    int HitCount,
    BitVector32 Columns)
    : INotePattern
{
    public MapAnnotationType Type => MapAnnotationType.Anchor;

    public int TotalTimeDistance => OffsetEnd - OffsetStart;
    public double AverageTimeDistance => (double)TotalTimeDistance / HitCount;
    public int ColumnCount => Columns.PopCount();
    public int NoteCount => ColumnCount * HitCount;
}
