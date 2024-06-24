namespace OsuRealDifficulty.Mania;

public enum NoteState
{
    /// <summary>
    /// The column has no notes.
    /// </summary>
    Void,
    /// <summary>
    /// The column has a rice note, including both pressing
    /// and releasing the key at any point.
    /// </summary>
    Rice,
    /// <summary>
    /// The column has a hold note, and it's currently being pressed.
    /// </summary>
    Press,
    /// <summary>
    /// The column has a hold note, and it's currently being held.
    /// </summary>
    Hold,
    /// <summary>
    /// The column has a hold note, and it's being released.
    /// </summary>
    Release,
}
