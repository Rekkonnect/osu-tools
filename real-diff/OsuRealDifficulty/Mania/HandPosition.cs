namespace OsuRealDifficulty.Mania;

public enum HandPosition
{
    Left,
    Right,
}

public static class HandPositionExtensions
{
    public static HandPosition Opposite(this HandPosition position)
    {
        return position switch
        {
            HandPosition.Left => HandPosition.Right,
            HandPosition.Right => HandPosition.Left,
        };
    }
}
