namespace OsuRealDifficulty.UI.WinForms.Controls;

partial class BackgroundCalculationReporter
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
        backgroundCalculationInformationLabel = new Label();
        backgroundCalculationProgressLabel = new Label();
        backgroundCalculationProgressBar = new ProgressBar();
        executionTimeLabel = new Label();
        SuspendLayout();
        // 
        // backgroundCalculationInformationLabel
        // 
        backgroundCalculationInformationLabel.AutoSize = true;
        backgroundCalculationInformationLabel.Font = new Font("Aptos Display", 10F);
        backgroundCalculationInformationLabel.ForeColor = Color.Silver;
        backgroundCalculationInformationLabel.Location = new Point(3, 12);
        backgroundCalculationInformationLabel.Name = "backgroundCalculationInformationLabel";
        backgroundCalculationInformationLabel.Size = new Size(147, 36);
        backgroundCalculationInformationLabel.TabIndex = 51;
        backgroundCalculationInformationLabel.Text = "calculating all beatmaps'\r\ndifficulty in background";
        // 
        // backgroundCalculationProgressLabel
        // 
        backgroundCalculationProgressLabel.AutoSize = true;
        backgroundCalculationProgressLabel.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        backgroundCalculationProgressLabel.ForeColor = Color.Silver;
        backgroundCalculationProgressLabel.Location = new Point(156, 10);
        backgroundCalculationProgressLabel.Name = "backgroundCalculationProgressLabel";
        backgroundCalculationProgressLabel.Size = new Size(85, 19);
        backgroundCalculationProgressLabel.TabIndex = 50;
        backgroundCalculationProgressLabel.Text = "1265 / 1489";
        // 
        // backgroundCalculationProgressBar
        // 
        backgroundCalculationProgressBar.BackColor = Color.FromArgb(50, 50, 50);
        backgroundCalculationProgressBar.ForeColor = SystemColors.ControlDark;
        backgroundCalculationProgressBar.Location = new Point(159, 31);
        backgroundCalculationProgressBar.Maximum = 1489;
        backgroundCalculationProgressBar.Name = "backgroundCalculationProgressBar";
        backgroundCalculationProgressBar.Size = new Size(197, 23);
        backgroundCalculationProgressBar.TabIndex = 49;
        backgroundCalculationProgressBar.Value = 1265;
        // 
        // executionTimeLabel
        // 
        executionTimeLabel.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        executionTimeLabel.ForeColor = Color.Silver;
        executionTimeLabel.Location = new Point(287, 10);
        executionTimeLabel.Name = "executionTimeLabel";
        executionTimeLabel.Size = new Size(69, 19);
        executionTimeLabel.TabIndex = 52;
        executionTimeLabel.Text = "6.2s";
        executionTimeLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // BackgroundCalculationReporter
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.Transparent;
        Controls.Add(executionTimeLabel);
        Controls.Add(backgroundCalculationInformationLabel);
        Controls.Add(backgroundCalculationProgressLabel);
        Controls.Add(backgroundCalculationProgressBar);
        Font = new Font("Aptos Display", 10F);
        Name = "BackgroundCalculationReporter";
        Size = new Size(356, 54);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label backgroundCalculationInformationLabel;
    private Label backgroundCalculationProgressLabel;
    private ProgressBar backgroundCalculationProgressBar;
    private Label executionTimeLabel;
}
