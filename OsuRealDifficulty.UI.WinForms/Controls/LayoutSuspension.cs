﻿namespace OsuRealDifficulty.UI.WinForms.Controls;

public readonly struct LayoutSuspension
    : IDisposable
{
    private readonly Control _control;

    public LayoutSuspension(Control control)
    {
        _control = control;
        _control.SuspendLayout();
    }

    public void Dispose()
    {
        _control.ResumeLayout();
    }
}
