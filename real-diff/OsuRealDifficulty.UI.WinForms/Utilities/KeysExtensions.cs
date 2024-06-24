namespace OsuRealDifficulty.UI.WinForms.Utilities;

public static class KeysExtensions
{
    public static bool IsDigitKey(this Keys key)
    {
        switch (key)
        {
            case Keys.D0:
            case Keys.D1:
            case Keys.D2:
            case Keys.D3:
            case Keys.D4:
            case Keys.D5:
            case Keys.D6:
            case Keys.D7:
            case Keys.D8:
            case Keys.D9:
            case Keys.NumPad0:
            case Keys.NumPad1:
            case Keys.NumPad2:
            case Keys.NumPad3:
            case Keys.NumPad4:
            case Keys.NumPad5:
            case Keys.NumPad6:
            case Keys.NumPad7:
            case Keys.NumPad8:
            case Keys.NumPad9:
                return true;
        }

        return false;
    }

    public static int GetDigitKeyValue(this Keys key)
    {
        switch (key)
        {
            case Keys.D0:
            case Keys.NumPad0:
                return 0;
            case Keys.D1:
            case Keys.NumPad1:
                return 1;
            case Keys.D2:
            case Keys.NumPad2:
                return 2;
            case Keys.D3:
            case Keys.NumPad3:
                return 3;
            case Keys.D4:
            case Keys.NumPad4:
                return 4;
            case Keys.D5:
            case Keys.NumPad5:
                return 5;
            case Keys.D6:
            case Keys.NumPad6:
                return 6;
            case Keys.D7:
            case Keys.NumPad7:
                return 7;
            case Keys.D8:
            case Keys.NumPad8:
                return 8;
            case Keys.D9:
            case Keys.NumPad9:
                return 9;
        }

        return -1;
    }
}

public record F;
