using Garyon.Extensions;
using OsuParsers.Database.Objects;

namespace OsuRealDifficulty.UI.WinForms.Core;

// This retains responsiveness for a good amount
internal sealed class BeatmapFilter
{
    public bool Title { get; set; } = true;
    public bool Artist { get; set; } = true;
    public bool Mapper { get; set; } = true;
    public bool Difficulty { get; set; } = true;
    public bool Source { get; set; } = true;
    public bool Tags { get; set; } = true;

    public bool FilterKeyCount { get; set; } = false;
    public int KeyCount { get; set; } = 4;

    public string Lexeme { get; set; } = string.Empty;

    public bool HasAnyFilter
    {
        get
        {
            return FilterKeyCount is true
                || !string.IsNullOrEmpty(Lexeme);
        }
    }

    internal bool Passes(DbBeatmapSet set)
    {
        foreach (var lexemeWord in EnumerateWords(Lexeme))
        {
            if (Title)
            {
                if (MatchesSearchLexemeWord(set.Title, lexemeWord))
                    continue;
            }
            if (Artist)
            {
                if (MatchesSearchLexemeWord(set.Artist, lexemeWord))
                    continue;
            }
            if (Source)
            {
                if (MatchesSearchLexemeWord(set.Source, lexemeWord))
                    continue;
            }
            if (Tags)
            {
                if (MatchesSearchLexemeWord(set.Tags, lexemeWord))
                    continue;
            }

            foreach (var beatmap in set.Beatmaps)
            {
                if (PassesShort(beatmap, lexemeWord))
                    goto continueOuter;
            }

            return false;

        continueOuter:
            continue;
        }

        if (FilterKeyCount)
        {
            bool matchesRequiredKeyCount = set.ContainsManiaWithKeyCount(KeyCount);
            if (!matchesRequiredKeyCount)
                return false;
        }

        return true;
    }

    private bool PassesShort(DbBeatmap beatmap, ReadOnlySpan<char> lexemeWord)
    {
        if (Mapper)
        {
            if (MatchesSearchLexemeWord(beatmap.Creator, lexemeWord))
                return true;
        }
        if (Difficulty)
        {
            if (MatchesSearchLexemeWord(beatmap.Difficulty, lexemeWord))
                return true;
        }

        return false;
    }

    private static bool MatchesSearchLexemeWord(string target, ReadOnlySpan<char> lexemeWord)
    {
        foreach (var targetWord in EnumerateWords(target))
        {
            if (targetWord.StartsWith(lexemeWord, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }

    internal bool PassesIgnoreLexeme(DbBeatmap beatmap)
    {
        if (FilterKeyCount)
        {
            bool matchesKeyCount = beatmap.IsManiaWithKeyCount(KeyCount);
            if (!matchesKeyCount)
                return false;
        }

        return true;
    }

    internal bool Passes(DbBeatmap beatmap)
    {
        foreach (var lexemeWord in EnumerateWords(Lexeme))
        {
            if (Title)
            {
                if (MatchesSearchLexemeWord(beatmap.Title, lexemeWord))
                    continue;
            }
            if (Artist)
            {
                if (MatchesSearchLexemeWord(beatmap.Artist, lexemeWord))
                    continue;
            }
            if (Mapper)
            {
                if (MatchesSearchLexemeWord(beatmap.Creator, lexemeWord))
                    continue;
            }
            if (Difficulty)
            {
                if (MatchesSearchLexemeWord(beatmap.Difficulty, lexemeWord))
                    continue;
            }
            if (Source)
            {
                if (MatchesSearchLexemeWord(beatmap.Source, lexemeWord))
                    continue;
            }
            if (Tags)
            {
                if (MatchesSearchLexemeWord(beatmap.Tags, lexemeWord))
                    continue;
            }

            return false;
        }

        return true;
    }

    private static SpaceDelimitedTokenEnumerator EnumerateWords(string s)
    {
        return new(s);
    }

    private ref struct SpaceDelimitedTokenEnumerator
    {
        public ReadOnlySpan<char> Source { get; }
        public int CurrentIndex { get; private set; } = 0;

        public ReadOnlySpan<char> Current { get; private set; }

        public SpaceDelimitedTokenEnumerator(ReadOnlySpan<char> source)
        {
            Source = source;
        }

        public bool MoveNext()
        {
            if (CurrentIndex >= Source.Length)
            {
                return false;
            }

            var evaluatedSpan = Source[CurrentIndex..];
            int nextSpaceIndex = evaluatedSpan.IndexOf(' ');
            if (nextSpaceIndex < 0)
            {
                Current = evaluatedSpan;
                CurrentIndex = Source.Length;
                return true;
            }

            Current = evaluatedSpan[..nextSpaceIndex];
            CurrentIndex += nextSpaceIndex + 1;
            return true;
        }

        public void Reset()
        {
            CurrentIndex = 0;
            Current = default;
        }

        public readonly SpaceDelimitedTokenEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
