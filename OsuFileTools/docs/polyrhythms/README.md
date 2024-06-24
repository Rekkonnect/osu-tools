# Polyrhythm Timing Point Creation Documentation

## Polyrhythms

Polyrhythms are rhythmical patterns that do not follow the standard subdivisions of 2, like 1/2, 1/4, etc.
This includes 1/3, 1/5, 1/7, and all others. 1/3 is specifically called "triples" as it's more common and isn't as exotic as the rest.

Polyrhythms are usually denoted in scores as a X:Y value.
The real duration of the polyrhythm phrase (the collection of notes that are grouped together with the symbol) depends on the Y value, and the subdivision that the polyrhythm involves.
The subdivision is implied and not mentioned in the X:Y notation.
We assume that the subdivision is a value Z, which we determine from the subdivisions of the notes within the phrase.
Usually (but not always) the highest subdivision we encounter is the subdivision of the polyrhythm.
For example, if we have a phrase that has 1/8 and 1/16 notes, then the subdivision of the polyrhythm phrase is 1/16, unless the numbers don't add up.

For this document we will use the X:Y/Z notation for further clarification due to the said ambiguities.
Most examples will be from **Chaos Time the DARK** by **t+pazolite**, whose assets are [here](examples/chaos-time).

Examples of polyrhythm phrases in musical scores include:

- 14:8/16<br/>
![image](https://github.com/Rekkonnect/osu-tools/assets/8298332/75a7b564-423f-43ef-9f9b-a24563c21a01)

- 19:16/16<br/>
![image](https://github.com/Rekkonnect/osu-tools/assets/8298332/9ab236b6-0800-4f03-9b45-c7759fce085e)

The X value indicates that the phrase includes notes representing a rhythmical duration equal to X/Z, but is played in Y/Z rhythmical duration.
Therefore, polyrhythms are equivalent to a short tempo shift by a ratio of X/Y that applies only to the specific polyrhythm phrase, and playing the denoted notes normally.

For example, to play 19:16/16 with a base tempo of 1/4 = 165 BPM, we can "shift" the tempo to 1/4 = (19/16) * 165 = 195.9375 BPM.

This is a very impractical way of thinking when playing the score.
The use case of this piece of theory is for mapping the songs in osu!, or any other rhythm game.

## Mapping in osu!

osu! doesn't know polyrhythms other than 1/3, 1/5 and 1/7 (including the subdivisions 1/6, 1/9, 1/12).
It's a limitation that we encounter in certain songs that have such unusual structure, which we have to bypass.
To abide to the rules of correctly snapping the notes to the grid, whichever BPM that is, we have to create timing points specifically for each polyrhythm phrase.

The timing points can be created by using the technique above to shift the BPM.
The duration of the timing point is determined by the X value in the X:Y/Z notation we described above.
Depending on the beat divisor that each note lies on, the next timing point will appear after X snaps at the chosen beat divisor.

For example, assume we use the 1/2 beat divisor for our notes. The polyrhythm 5:3/8 will span over 5 snaps for the timing divisor with 5/3 * 165 = 275 BPM:

![image](https://github.com/Rekkonnect/osu-tools/assets/8298332/bb8a71d7-527d-478b-ba7e-42c21cee56f6)

The polyrhythm that is denoted:

![image](https://github.com/Rekkonnect/osu-tools/assets/8298332/60ba2202-eb07-4e89-bf80-ac0dd028e838)

## Polyrhythm notation file structure

This tool uses a hand-crafted notation for denoting a section of polyrhythms.
Each polyrhythm section begins at a certain offset, has a certain BPM and time signature.
The section consists of measures, which measures must add up to the total rhythmical value denoted by the time signature.
The measures consist of phrases that occupy a denoted rhythmical value.

A typical polyrhythm notation file may look something like this:
```
Timing 54652 - 165 - 4/4

// 2
4:3/8
2/16
2/8 - 2 2 1
2/8

// 3
4:3/8
2/16
3:2/16
2/16
1/4

// 4
5:3/8
3:2/16
5:3/8
3:2/16

// 5
7:4/8 - 1 1 2 2 1 1 2 2 2 2
1/2 - R

// ... truncated ...
```

All sections begin with the header `Timing X - Y - A/B`, where:
- X is the offset (in ms)
- Y is the BPM of the section
- A/B is the time signature (A is the measure duration and B is the subdivision)

Note that the BPM of the section is automatically equal to the BPM of the subdivison declared in B.
BPM denotes the number of times that a subdivision is played, hence the above specification of 1/4 = 165 BPM.
Scores may be in 1/4 but have their tempo denoted in another subdivision, like 1/2 or 1/8.

Measures are separated by empty lines in between them.
Multiple empty lines are treated as one empty line separator, and are therefore okay to use.

Each line represents a phrase that belongs to the current measure.
The phrase begins with the polyrhythm notation, denoting the length of the phrase.
Standard non-polyrhythmical durations are also supported, like `1/2`.
Durations may optionally be followed by a string of phrase notes, where the exact notes of the phrase are denoted.
Omitting the string of phrase notes implies that all phrase notes have the same duration, and there are as many as the X value denotes.
For example, `5:3/8` denotes 5 notes with equal duration, and `3/4` denotes 3 notes with equal duration.

Lines beginning with `//` are comments and are completely ignored.
Comments can only be added at the start of the line, not after the line has begun.

Comments are helpful to add notes like explaining why a phrase was written in the way it is.
In the above example the measures are commented with `//`; this is **optional** and has **no** importance for the tool whatsoever, it's only for helping the user identify the measure's index.

### Phrase note notation

Phrases that are denoted with a phrase note string have more capabilities and should be capable of representing almost all complicated patterns.

Phrase notes are laid out in the order they appear, separated by a single space.
Each phrase note is represented by a few characteristics that will be explained below.

In the above example, the line
```
7:4/8 - 1 1 2 2 1 1 2 2 2 2
```

denotes this polyrhythm:

![image](https://github.com/Rekkonnect/osu-tools/assets/8298332/75a7b564-423f-43ef-9f9b-a24563c21a01)

Note that the image denotes the polyrhythm in 14:8/16, while the notation file denotes it in 7:4/8. Those are both equivalent notations, and 7:4/8 is only preferred for the purposes of declaring the subdivisions more cleanly, as shown below.

Each number value past the `-` is a multiplier towards the **subdivision**.
Fractional multipliers are also supported.
Inversely, the same line could be written as:

```
14:8/16 - 1/2 1/2 1 1 1/2 1/2 1 1 1 1
```

Notes may also have the dot notation, which extends its duration by 50%.
For example:

![image](https://github.com/Rekkonnect/osu-tools/assets/8298332/f8f43eb5-9688-45e1-ad4a-e1f456b49f92)

This pattern denotes 2 dotted 1/8 notes.
Their total rhythmical value is equal to 2 * (1/8 + 1/16) = 2 * 3/16 = 6/16 = 3/8.
Dotted notes are represented by adding a dot at the end of the phrase note, like so:

```
3/8 - 1. 1.
```

Multiply dotted notes are also supported, which is denoted by the number of dots for the note.
Each additional dot extends the duration by 1/(2^N), where `N` is the 1-based index of the dot.
For example, a 1/8 note that is doubly dotted will have a duration of 1/8 + 1/16 + 1/32 = 7/32.
That note will be denoted as:

```
7/32 - 1/4..
```

Rests are denoted with an `R` in front of them.
Standard rules apply, in that rests may also have a different rhythmical value, or be dotted any number of times.
A simple rest that would be otherwise notated `R1` may be simplified to `R`.
For example:

```
// Two 1/4 rests
2/4 - R R

// Two dotted 1/4 rests
3/4 - R. R1.
```

## Multiple segments

Multiple segments within the same notation file may be included.
Each segment extends up to the point where its last note is described.
Each segment may have any attribute independent of its other segments.
This feature is for the convenience of doing the operation once and including multiple polyrhythmical segments.

For example:
```
Timing 54652 - 165 - 4/4

// 2
4:3/8
2/16
2/8 - 2 2 1
2/8

Timing 153493 - 270 - 3/4

// 2
9:3/8
4/32
1/4 - 4 4 4 4
```
