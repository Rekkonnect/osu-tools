namespace OsuRealDifficulty.Mania;

public struct HandOccupation
{
    // Reserve 8 bits for future reference
    private const uint handMask = 0b1111_1111;
    private const int handMaskLength = 8;

    private uint _bits;

    public readonly HandState Left => GetHand(HandPosition.Left);
    public readonly HandState Right => GetHand(HandPosition.Right);

    public HandOccupation(HandState left, HandState right)
    {
        SetState(HandPosition.Left, left);
        SetState(HandPosition.Right, right);
    }

    public void SetState(HandPosition hand, HandState state)
    {
        SetState((int)hand, state);
    }

    public void SetState(int hand, HandState state)
    {
        int shift = hand * handMaskLength;
        uint mask = handMask << shift;
        uint stateValue = (uint)state << shift;
        _bits = ReplaceBits(_bits, mask, stateValue);
    }

    public readonly HandState GetHand(HandPosition hand)
    {
        int handIndex = (int)hand;
        return (HandState)GetHandBits(handIndex);
    }

    private readonly uint GetHandBits(int hand)
    {
        int shift = hand * handMaskLength;
        uint stateBits = (_bits >> shift) & handMask;
        return stateBits;
    }

    private static uint ReplaceBits(uint bits, uint mask, uint value)
    {
        return (bits & ~mask) | value;
    }

    public readonly override string ToString()
    {
        return $"{Left} {Right}";
    }
}
