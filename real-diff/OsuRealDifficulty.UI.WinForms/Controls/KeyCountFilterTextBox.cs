using OsuRealDifficulty.UI.WinForms.Utilities;

namespace OsuRealDifficulty.UI.WinForms.Controls;

public sealed class KeyCountFilterTextBox : TextBox
{
    public int DefaultKeyCount = 4;

    public int KeyCount => Text.ParseInt32OrDefault(DefaultKeyCount);

    protected override void OnKeyDown(KeyEventArgs e)
    {
        var digitKeyValue = e.KeyCode.GetDigitKeyValue();
        if (digitKeyValue < 1)
            return;

        var newText = digitKeyValue.ToString();
        this.SetTextScrollToEnd(newText);
    }

    protected override void OnTextChanged(EventArgs e)
    {
        var text = Text;
        if (text.Length is 0)
            return;

        bool parsed = int.TryParse(text, out _);
        if (!parsed)
        {
            ResetToDefaultKeyCount();
        }

        base.OnTextChanged(e);
    }

    protected override void OnLeave(EventArgs e)
    {
        if (Text.Length is 0)
        {
            ResetToDefaultKeyCount();
        }

        base.OnLeave(e);
    }

    private void ResetToDefaultKeyCount()
    {
        Text = DefaultKeyCount.ToString();
    }
}
