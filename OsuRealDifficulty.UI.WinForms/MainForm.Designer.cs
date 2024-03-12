using OsuRealDifficulty.UI.WinForms.Controls;

namespace OsuRealDifficulty.UI.WinForms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        difficultyResultDisplay = new AnalysisResultDisplay();
        SuspendLayout();
        // 
        // difficultyResultDisplay
        // 
        difficultyResultDisplay.BackColor = Color.FromArgb(30, 30, 30);
        difficultyResultDisplay.Caption = "difficulty";
        difficultyResultDisplay.Font = new Font("Aptos Display", 10F);
        difficultyResultDisplay.ForeColor = SystemColors.ControlLight;
        difficultyResultDisplay.Location = new Point(215, 12);
        difficultyResultDisplay.Margin = new Padding(4, 3, 4, 3);
        difficultyResultDisplay.Name = "difficultyResultDisplay";
        difficultyResultDisplay.Size = new Size(368, 450);
        difficultyResultDisplay.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(30, 30, 30);
        ClientSize = new Size(595, 478);
        Controls.Add(difficultyResultDisplay);
        Font = new Font("Aptos Display", 10F);
        ForeColor = SystemColors.ControlLight;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4, 3, 4, 3);
        Name = "MainForm";
        Text = "osu!mania difficulty analyzer";
        Load += MainForm_Load;
        ResumeLayout(false);
    }

    #endregion

    private AnalysisResultDisplay difficultyResultDisplay;
}
