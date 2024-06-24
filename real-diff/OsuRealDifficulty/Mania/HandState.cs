namespace OsuRealDifficulty.Mania;

[Flags]
public enum HandState
{
    Void = 0,
    Press = 1 << 0,
    Hold = 1 << 1,
    Release = 1 << 2,
    FingerHit = 1 << 3,
    FingerRelease = 1 << 4,

    PressFinger = Press | FingerHit,
    PressFingerHold = PressFinger | Hold,
}
