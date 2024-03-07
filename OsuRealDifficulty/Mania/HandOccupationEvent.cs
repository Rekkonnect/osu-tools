namespace OsuRealDifficulty.Mania;

public struct HandOccupationEvent(int offset, HandState left, HandState right)
{
    public int Offset = offset;
    public HandOccupation Occupation = new(left, right);

    public readonly override string ToString()
    {
        return $"{Offset} - {Occupation}";
    }
}
