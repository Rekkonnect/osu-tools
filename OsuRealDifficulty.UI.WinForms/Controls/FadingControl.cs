﻿using System.Diagnostics.CodeAnalysis;

namespace OsuRealDifficulty.UI.WinForms.Controls;

public class FadingControl : Control
{
    public double FadeRate = 0.5;
    public Color FillColor;

    public int Alpha => (int)(255 * Math.Clamp(FadeRate, 0, 1));

    private Panel _overlayPanel;

    public FadingControl()
    {
        InitializeComponent();
    }

    [MemberNotNull(nameof(_overlayPanel))]
    private void InitializeComponent()
    {
        Dock = DockStyle.Fill;
        BringToFront();

        _overlayPanel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Black,
            Visible = false,
            Parent = this
        };
        _overlayPanel.BringToFront();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        // Do nothing to prevent painting the background
    }

    public void SetFading(bool enable)
    {
        // Show or hide the overlay panel based on fading status
        _overlayPanel.Visible = enable;
        _overlayPanel.BackColor = Color.FromArgb(Alpha, FillColor);
    }
}