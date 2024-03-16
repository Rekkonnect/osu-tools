namespace OsuRealDifficulty.UI.WinForms.Controls;

partial class PopupBox
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        messageLabel = new Label();
        titleLabel = new Label();
        buttonLayoutPanel = new CenterAligningFlowLayoutPanel();
        imageLabel = new Label();
        SuspendLayout();
        // 
        // messageLabel
        // 
        messageLabel.Font = new Font("Aptos Display", 11F);
        messageLabel.ForeColor = Color.Silver;
        messageLabel.ImageAlign = ContentAlignment.TopCenter;
        messageLabel.Location = new Point(0, 103);
        messageLabel.Name = "messageLabel";
        messageLabel.Size = new Size(428, 72);
        messageLabel.TabIndex = 52;
        messageLabel.Text = "example message\r\nspanning over multiple lines";
        messageLabel.TextAlign = ContentAlignment.TopCenter;
        // 
        // titleLabel
        // 
        titleLabel.BackColor = Color.FromArgb(75, 75, 75);
        titleLabel.Dock = DockStyle.Top;
        titleLabel.Font = new Font("Aptos Display", 13F, FontStyle.Bold);
        titleLabel.ForeColor = SystemColors.ControlLight;
        titleLabel.Location = new Point(0, 0);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(428, 35);
        titleLabel.TabIndex = 53;
        titleLabel.Text = "example title";
        titleLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // buttonLayoutPanel
        // 
        buttonLayoutPanel.Anchor = AnchorStyles.None;
        buttonLayoutPanel.BackColor = Color.Transparent;
        buttonLayoutPanel.Location = new Point(0, 178);
        buttonLayoutPanel.Name = "buttonLayoutPanel";
        buttonLayoutPanel.Padding = new Padding(0, 0, 0, 6);
        buttonLayoutPanel.Size = new Size(428, 44);
        buttonLayoutPanel.TabIndex = 54;
        // 
        // imageLabel
        // 
        imageLabel.Font = new Font("Aptos Display", 10F);
        imageLabel.ForeColor = Color.Silver;
        imageLabel.Location = new Point(0, 35);
        imageLabel.Name = "imageLabel";
        imageLabel.Size = new Size(428, 68);
        imageLabel.TabIndex = 55;
        imageLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // PopupBox
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(50, 50, 50);
        Controls.Add(imageLabel);
        Controls.Add(buttonLayoutPanel);
        Controls.Add(titleLabel);
        Controls.Add(messageLabel);
        Font = new Font("Aptos Display", 10F);
        Name = "PopupBox";
        Size = new Size(428, 222);
        ResumeLayout(false);
    }

    #endregion

    private Label messageLabel;
    private Label titleLabel;
    private CenterAligningFlowLayoutPanel buttonLayoutPanel;
    private Label imageLabel;
}
