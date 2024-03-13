namespace OsuRealDifficulty.UI.WinForms;

public sealed class KeyCountFilterTextBox : TextBox
{
    public int DefaultKeyCount = 4;

    public int KeyCount => Text.ParseInt32OrDefault(DefaultKeyCount);

    protected override void OnTextChanged(EventArgs e)
    {
        if (Text.Length is 0)
            return;

        bool parsed = int.TryParse(Text, out _);
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
