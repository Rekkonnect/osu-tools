using OsuRealDifficulty.Mania;

namespace OsuRealDifficulty.Tests.Mania;

public sealed class ChordListParsingTests
{
    #region Happy tests

    [Test]
    public void RiceWithoutOffsets()
    {
        const string chordString = """
            | - -|
            |-- -|
            | ---|
            |-- -|
            """;

        var chordList = ChordListParsing.Parse(chordString);
        Assert.That(chordList.Keys, Is.EqualTo(4));
        Chord[] expectedChords =
        [
            new()
            {
                Offset = 0,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Rice),
            },
            new()
            {
                Offset = 1,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Rice),
            },
            new()
            {
                Offset = 2,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Rice),
            },
            new()
            {
                Offset = 3,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Rice),
            },
        ];

        Assert.That(chordList.Chords, Is.EqualTo(expectedChords));
    }

    [Test]
    public void RiceWithOffsets()
    {
        const string chordString = """
            | - -| 375
            |-- -| 225
            | ---| 150
            |-- -| 25
            """;

        var chordList = ChordListParsing.Parse(chordString);
        Assert.That(chordList.Keys, Is.EqualTo(4));
        Chord[] expectedChords =
        [
            new()
            {
                Offset = 25,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Rice),
            },
            new()
            {
                Offset = 150,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Rice),
            },
            new()
            {
                Offset = 225,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Rice),
            },
            new()
            {
                Offset = 375,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Rice),
            },
        ];

        Assert.That(chordList.Chords, Is.EqualTo(expectedChords));
    }

    [Test]
    public void LNMixWithOffsets()
    {
        const string chordString = """
            | - ^| 375
            |--^|| 225
            | --|| 150
            |-- -| 25
            """;

        var chordList = ChordListParsing.Parse(chordString);
        Assert.That(chordList.Keys, Is.EqualTo(4));
        Chord[] expectedChords =
        [
            new()
            {
                Offset = 25,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Press),
            },
            new()
            {
                Offset = 150,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Press,
                    NoteState.Hold),
            },
            new()
            {
                Offset = 225,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Release,
                    NoteState.Hold),
            },
            new()
            {
                Offset = 375,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Release),
            },
        ];

        Assert.That(chordList.Chords, Is.EqualTo(expectedChords));
    }

    [Test]
    public void BrokenLNHoldWithOffsets()
    {
        const string chordString = """
            | - ^| 375
            |--^|| 225
            | --|| 150
            |-- || 25
            """;

        var chordList = ChordListParsing.Parse(chordString);
        Assert.That(chordList.Keys, Is.EqualTo(4));
        Chord[] expectedChords =
        [
            new()
            {
                Offset = 25,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Hold),
            },
            new()
            {
                Offset = 150,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Press,
                    NoteState.Hold),
            },
            new()
            {
                Offset = 225,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Release,
                    NoteState.Hold),
            },
            new()
            {
                Offset = 375,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Release),
            },
        ];

        Assert.That(chordList.Chords, Is.EqualTo(expectedChords));
    }

    [Test]
    public void PatternWithOffsetsAndComments()
    {
        const string chordString = """
            | - ^| 375 another comment
            |--^|| 225 < this is fieldjack
            | --|| 150
            |-- ||  25 no comments above
            """;

        var chordList = ChordListParsing.Parse(chordString);
        Assert.That(chordList.Keys, Is.EqualTo(4));
        Chord[] expectedChords =
        [
            new()
            {
                Offset = 25,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Hold),
            },
            new()
            {
                Offset = 150,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Press,
                    NoteState.Hold),
            },
            new()
            {
                Offset = 225,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Release,
                    NoteState.Hold),
            },
            new()
            {
                Offset = 375,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Release),
            },
        ];

        Assert.That(chordList.Chords, Is.EqualTo(expectedChords));
    }

    [Test]
    public void PatternWithSomeCommentsNoOffsets()
    {
        const string chordString = """
            | - ^| another comment
            |--^|| < this is not fieldjack
            | --||
            |-- || no comments above
            """;

        var chordList = ChordListParsing.Parse(chordString);
        Assert.That(chordList.Keys, Is.EqualTo(4));
        Chord[] expectedChords =
        [
            new()
            {
                Offset = 0,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Hold),
            },
            new()
            {
                Offset = 1,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Press,
                    NoteState.Hold),
            },
            new()
            {
                Offset = 2,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Release,
                    NoteState.Hold),
            },
            new()
            {
                Offset = 3,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Release),
            },
        ];

        Assert.That(chordList.Chords, Is.EqualTo(expectedChords));
    }

    [Test]
    public void Rice7K()
    {
        const string chordString = """
            | -- ---|
            |----- -|
            | ---  -|
            |--- - -|
            """;

        var chordList = ChordListParsing.Parse(chordString);
        Assert.That(chordList.Keys, Is.EqualTo(7));
        Chord[] expectedChords =
        [
            new()
            {
                Offset = 0,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Rice),
            },
            new()
            {
                Offset = 1,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Void,
                    NoteState.Rice),
            },
            new()
            {
                Offset = 2,
                Notes = ChordNotes.FromStates(
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Rice),
            },
            new()
            {
                Offset = 3,
                Notes = ChordNotes.FromStates(
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Void,
                    NoteState.Rice,
                    NoteState.Rice,
                    NoteState.Rice),
            },
        ];

        Assert.That(chordList.Chords, Is.EqualTo(expectedChords));
    }

    #endregion

    #region Sad tests

    // No sad tests because we are happy developers :)

    #endregion
}
