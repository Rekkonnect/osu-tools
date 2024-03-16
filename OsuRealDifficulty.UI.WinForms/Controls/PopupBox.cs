using OsuRealDifficulty.UI.WinForms.Utilities;

namespace OsuRealDifficulty.UI.WinForms.Controls;

public partial class PopupBox : UserControl
{
    private FadingContainer? _fadingContainer;

    public string Title
    {
        get
        {
            return titleLabel.Text;
        }
        set
        {
            titleLabel.Text = value;
        }
    }

    public string Message
    {
        get
        {
            return messageLabel.Text;
        }
        set
        {
            messageLabel.Text = value;
        }
    }

    public Icon? Icon
    {
        set
        {
            imageLabel.Image = value?.ToBitmap();
        }
    }

    public MessageBoxIcon MessageIcon
    {
        set
        {
            Icon = value switch
            {
                MessageBoxIcon.Error => SystemIcons.Error,
                MessageBoxIcon.Warning => SystemIcons.Warning,
                MessageBoxIcon.Information => SystemIcons.Information,
                MessageBoxIcon.Question => SystemIcons.Question,
                _ => null,
            };
        }
    }

    public DialogResult DialogResult { get; private set; }
        = DialogResult.None;

    public event Action<DialogResult>? ResultSelected;

    public event Action? YesSelected;
    public event Action? OkSelected;
    public event Action? RetrySelected;

    public PopupBox()
    {
        InitializeComponent();
    }

    public void AddButton(PopupBoxButton button)
    {
        button.Click += HandleButtonClick;

        button.Height = buttonLayoutPanel.Height
            - buttonLayoutPanel.Padding.Vertical
            - button.Margin.Vertical;

        button.Font = button.Font
            .WithSize(11)
            .WithStyle(FontStyle.Bold);

        buttonLayoutPanel.Controls.Add(button);
    }

    public void AddButton(DialogResult result, string text)
    {
        var button = new PopupBoxButton
        {
            DialogResult = result,
            Text = text,
        };
        AddButton(button);
    }

    public void Show(Control ownerControl)
    {
        Render(ownerControl);
        _fadingContainer = ShowFade(ownerControl);
    }

    private void Render(Control ownerControl)
    {
        AdjustPosition(ownerControl);
        buttonLayoutPanel.AlignAll();
    }

    private void HandleButtonClick(object? sender, EventArgs e)
    {
        var button = sender as Button;
        var result = button!.DialogResult;
        DialogResult = result;
        HideFade();
        InformResultSelected(result);
    }

    private void InformResultSelected(DialogResult result)
    {
        ResultSelected?.Invoke(result);

        switch (result)
        {
            case DialogResult.OK:
                OkSelected?.Invoke();
                break;
            case DialogResult.Yes:
                YesSelected?.Invoke();
                break;
            case DialogResult.Retry:
                RetrySelected?.Invoke();
                break;
        }
    }

    private void HideFade()
    {
        _fadingContainer!.HideFade();
    }

    private void AdjustPosition(Control faded)
    {
        int horizontalEmpty = faded.Width - Width;
        Left = horizontalEmpty / 2;

        int verticalEmpty = faded.Height - Height;
        Top = verticalEmpty / 2;
    }

    private FadingContainer ShowFade(Control faded)
    {
        var fadingContainer = new FadingContainer
        {
            CoveredControl = faded,
            TopControl = this,
            BackColor = BackColor,
        };
        fadingContainer.Fading.FadeRate = 0.7;
        fadingContainer.DisplayFade();
        return fadingContainer;
    }
}
