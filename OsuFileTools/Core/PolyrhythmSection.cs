using Garyon.Extensions;
using OsuTools.Common;

namespace OsuFileTools.Core;

public class PolyrhythmSectionParser
{
    public static IReadOnlyList<PolyrhythmSection> Parse(
        string text)
    {
        var enumerator = text.AsSpan().EnumerateLines();
        var lines = new SpanLineEnumeratorWrapper(enumerator);
        return Parse(lines);
    }

    public static IReadOnlyList<PolyrhythmSection> Parse(
        SpanLineEnumeratorWrapper lines)
    {
        bool any = lines.MoveNext();
        if (!any)
            return [];

        var sections = new List<PolyrhythmSection>();
        while (true)
        {
            var section = ParseSection(ref lines);
            if (section is null)
                break;

            sections.Add(section);

            if (!lines.IsActive)
                break;
        }

        return sections;
    }

    private static PolyrhythmSection? ParseSection(
        ref SpanLineEnumeratorWrapper lines)
    {
        EatEmptyLines(ref lines);

        var current = lines.Current;
        if (current.IsEmpty)
            return null;

        if (!current.StartsWith("Timing"))
        {
            throw new FormatException("The given section span does not begin with a Timing header");
        }

        var section = ParseTiming(current);
        lines.MoveNext();

        while (true)
        {
            EatEmptyLines(ref lines);
            if (!lines.IsActive)
                break;

            var measure = TryParseMeasure(ref lines);
            if (measure is null)
                break;

            section.AddMeasure(measure);
        }

        return section;
    }

    private static void EatEmptyLines(
        ref SpanLineEnumeratorWrapper lines)
    {
        while (true)
        {
            var current = lines.Current;
            if (current.Length is not 0)
                break;

            bool hasMore = lines.MoveNext();
            if (!hasMore)
                return;
        }
    }

    private static PolyrhythmMeasure? TryParseMeasure(
        ref SpanLineEnumeratorWrapper lines)
    {
        var phrases = new List<BasePolyrhythmPhrase>();

        while (true)
        {
            var current = lines.Current;
            if (current.Length is 0)
                break;

            if (current.StartsWith("Timing"))
                break;

            // comment
            if (current.StartsWith("//"))
            {
                goto end;
            }

            var phrase = ParsePhrase(current);
            phrases.Add(phrase);

end:
            if (!lines.MoveNext())
            {
                break;
            }
        }

        if (phrases.Count is 0)
            return null;

        return PolyrhythmMeasure.FromPhrases(phrases);
    }

    private static BasePolyrhythmPhrase ParsePhrase(
        ReadOnlySpan<char> span)
    {
        bool hasNotes = span.SplitOnce(
            " - ",
            out var rhythm,
            out var notes);

        ParsePhraseRhythm(
            rhythm,
            out var polyValue,
            out var quantizedValue,
            out var denominator);

        if (hasNotes)
        {
            var parsedNotes = ParseNotes(notes);
            return new ComplexPolyrhythmPhrase(
                polyValue,
                quantizedValue,
                denominator,
                parsedNotes);
        }

        return new SimplePolyrhythmPhrase(
            polyValue,
            quantizedValue,
            denominator);
    }

    private static void ParsePhraseRhythm(
        ReadOnlySpan<char> span,
        out int polyValue,
        out int quantizedValue,
        out int denominator)
    {
        span.SplitOnce('/', out var nominator, out var denominatorSpan);
        denominator = denominatorSpan.ParseInt32();
        var hasPoly = nominator.SplitOnce(
            ':',
            out var polySpan,
            out var quantizedSpan);

        if (hasPoly)
        {
            polyValue = polySpan.ParseInt32();
            quantizedValue = quantizedSpan.ParseInt32();
        }
        else
        {
            quantizedValue = nominator.ParseInt32();
            polyValue = quantizedValue;
        }
    }

    private static IReadOnlyList<PhraseNote> ParseNotes(
        ReadOnlySpan<char> span)
    {
        return span.SplitSelect(' ', ParsePhraseNote);
    }

    private static PhraseNote ParsePhraseNote(
        ReadOnlySpan<char> span)
    {
        bool isRest = false;
        int multiplier = 1;
        int dots = 0;
        if (span.StartsWith("R"))
        {
            isRest = true;
            span = span[1..];
        }

        if (span.Length > 0)
        {
            multiplier = span.ParseFirstInt32(0, out var endIndex);
            span = span[endIndex..];

            while (true)
            {
                if (span.Length is 0)
                    break;

                if (span[0] is not '.')
                    break;

                dots++;
                span = span[1..];
            }
        }

        return new(multiplier, dots, isRest);
    }

    private static PolyrhythmSection ParseTiming(
        ReadOnlySpan<char> span)
    {
        const string timingPrefix = "Timing ";
        var rest = span[timingPrefix.Length..];
        rest.SplitOnce(" - ", out var offsetSpan, out rest);
        rest.SplitOnce(" - ", out var bpmSpan, out var timeSignatureSpan);

        var offset = offsetSpan.ParseInt32();
        var bpm = bpmSpan.ParseDouble();
        var timeSignature = ParseTimeSignature(timeSignatureSpan);
        return new(offset, BeatLength.FromBpm(bpm), timeSignature);
    }

    private static RhythmicalValue ParseTimeSignature(
        ReadOnlySpan<char> span)
    {
        span.SplitOnce('/', out var left, out var right);
        int nominator = left.ParseInt32();
        int denominator = right.ParseInt32();
        return new(nominator, denominator);
    }
}

public class PolyrhythmSection(
    int offset,
    BeatLength beatLength,
    RhythmicalValue timeSignature)
{
    private readonly List<PolyrhythmMeasure> _measures = [];

    public int Offset { get; } = offset;
    public BeatLength BeatLength { get; } = beatLength;
    public RhythmicalValue TimeSignature { get; } = timeSignature;

    public IReadOnlyList<PolyrhythmMeasure> Measures => _measures;

    public void AddMeasure(PolyrhythmMeasure measure)
    {
        var totalValue = measure.TotalValue;
        if (!totalValue.Equals(TimeSignature))
        {
            throw new ArgumentException("The measure does not align with the described time signature");
        }
        _measures.Add(measure);
    }
}

public class PolyrhythmMeasure(
    RhythmicalValue totalValue,
    IReadOnlyList<BasePolyrhythmPhrase> phrases)
{
    public RhythmicalValue TotalValue { get; } = totalValue;
    public IReadOnlyList<BasePolyrhythmPhrase> Phrases { get; } = phrases;

    public static PolyrhythmMeasure FromPhrases(
        IReadOnlyList<BasePolyrhythmPhrase> phrases)
    {
        var totalValue = RhythmicalValue.Zero;
        foreach (var phrase in phrases)
        {
            var phraseValue = phrase.QuantizedRhythmicalValue;
            totalValue += phraseValue;
        }

        return new(
            totalValue,
            phrases);
    }
}

public abstract class BasePolyrhythmPhrase(
    int polyValue, int quantizedValue, int denominator)
{
    public int PolyValue { get; } = polyValue;
    public int QuantizedValue { get; } = quantizedValue;
    public int Denominator { get; } = denominator;

    public RhythmicalValue QuantizedRhythmicalValue
        => new(QuantizedValue, Denominator);

    public bool IsPolyrhythmic => PolyValue != QuantizedValue;

    public override string ToString()
    {
        if (IsPolyrhythmic)
            return $"{PolyValue}:{QuantizedValue}/{Denominator}";
        return $"{PolyValue}/{Denominator}";
    }
}

public class SimplePolyrhythmPhrase(
    int polyValue, int quantizedValue, int denominator)
    : BasePolyrhythmPhrase(
        polyValue, quantizedValue, denominator)
{
}

public class ComplexPolyrhythmPhrase(
    int polyValue, int quantizedValue, int denominator,
    IReadOnlyList<PhraseNote> phraseNotes)
    : BasePolyrhythmPhrase(
        polyValue, quantizedValue, denominator)
{
    public readonly IReadOnlyList<PhraseNote> PhraseNotes
        = phraseNotes;

    public bool Validate()
    {
        var totalValue = RhythmicalValue.Zero;
        foreach (var note in PhraseNotes)
        {
            totalValue += note.TotalValue(Denominator);
        }

        var targetValue = new RhythmicalValue(PolyValue, Denominator);
        return totalValue.Equals(targetValue);
    }

    public override string ToString()
    {
        var left = base.ToString();
        var phrases = string.Join(' ', PhraseNotes);
        return $"{left} - {phrases}";
    }
}

public readonly record struct PhraseNote(
    int EncodedMultiplier,
    int Flags)
{
    public int Dots => Flags & 0b1111;

    public const int RestMask = 1 << 31;
    public bool IsRest => (Flags & RestMask) is not 0;

    public int MultiplierNominator
        => EncodedMultiplier > 0
            ? EncodedMultiplier
            : 1;

    public int MultiplierDenominator
        => EncodedMultiplier < 0
            ? -EncodedMultiplier
            : 1;

    public PhraseNote(int encodedMultiplier, int dots, bool isRest)
        : this(encodedMultiplier, dots | RestValue(isRest))
    {
    }

    private static int RestValue(bool isRest)
    {
        return isRest
            ? RestMask
            : 0;
    }

    public RhythmicalValue TotalValue(int phraseDenominator)
    {
        var baseValue = new RhythmicalValue(
            MultiplierNominator,
            phraseDenominator * MultiplierDenominator);
        var totalValue = baseValue;

        for (int i = 0; i < Dots; i++)
        {
            baseValue *= 2;
            totalValue += baseValue;
        }

        return totalValue;
    }

    public override string ToString()
    {
        var nominator = MultiplierNominator;
        var denominator = MultiplierDenominator;
        int dots = Dots;
        bool isRest = IsRest;
        var prefix = "";
        if (isRest)
        {
            prefix = "R";
        }
        var suffix = "";
        if (dots > 0)
        {
            suffix = new string('.', dots);
        }
        var value = nominator.ToString();
        if (denominator is not 1)
        {
            value = $"{nominator}/{denominator}";
        }
        return $"{prefix}{value}{suffix}";
    }
}

public readonly record struct RhythmicalValue(
    int Nominator,
    int Denominator)
{
    public static readonly RhythmicalValue Zero = new(0, 1);

    public double Ratio => (double)Nominator / Denominator;

    public RhythmicalValue ScaleForDenominator(int denominator)
    {
        if (denominator > Denominator)
        {
            int scale = denominator / Denominator;
            return new(
                Nominator * scale,
                denominator);
        }
        else
        {
            int scale = Denominator / denominator;
            return new(
                Nominator / scale,
                denominator);
        }
    }

    public bool Equals(RhythmicalValue other)
    {
        return Ratio == other.Ratio;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static RhythmicalValue operator +(
        RhythmicalValue left, RhythmicalValue right)
    {
        int commonDenominator = Lcm(left.Denominator, right.Denominator);
        left = left.ScaleForDenominator(commonDenominator);
        right = right.ScaleForDenominator(commonDenominator);
        var nextNominator = left.Nominator + right.Nominator;
        return new(nextNominator, commonDenominator);
    }
    public static RhythmicalValue operator -(
        RhythmicalValue left, RhythmicalValue right)
    {
        return left + -right;
    }
    public static RhythmicalValue operator -(
        RhythmicalValue x)
    {
        return new(-x.Nominator, x.Denominator);
    }

    public static RhythmicalValue operator *(
        RhythmicalValue left, int scalar)
    {
        return new(
            left.Nominator * scalar,
            left.Denominator);
    }
    public static RhythmicalValue operator /(
        RhythmicalValue left, int scalar)
    {
        return new(
            left.Nominator,
            left.Denominator * scalar);
    }

    private static int Lcm(int left, int right)
    {
        var gcd = Gcd(left, right);
        return left * right / gcd;
    }

    private static int Gcd(int left, int right)
    {
        if (left == right)
            return left;

        if (left < right)
        {
            int next = right - left;
            return Gcd(left, next);
        }
        else
        {
            int next = left - right;
            return Gcd(right, next);
        }
    }
}
