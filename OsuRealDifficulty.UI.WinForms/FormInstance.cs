namespace OsuRealDifficulty.UI.WinForms;

public static class FormInstance
{
    public static TForm Open<TForm>()
        where TForm : Form, new()
    {
        return Singleton<TForm>.Open();
    }

    private static class Singleton<TForm>
        where TForm : Form, new()
    {
        private static TForm? _active;

        public static TForm Open()
        {
            if (NeedsNew())
            {
                _active = new TForm();
            }
            _active!.Show();
            _active.Focus();

            return _active;
        }

        private static bool NeedsNew()
        {
            return _active
                is null
                or { IsDisposed: true };
        }
    }
}
