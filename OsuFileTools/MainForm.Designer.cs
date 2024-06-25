namespace OsuFileTools;

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
        loadBeatmapDialog = new OpenFileDialog();
        saveDialogBeatmap = new SaveFileDialog();
        tabControl1 = new TabControl();
        transformerPage = new TabPage();
        beatmapTransformerControl1 = new Controls.BeatmapTransformerControl();
        timingPointGenerationPage = new TabPage();
        simpleGeneratorsControl1 = new Controls.TimingPointGenerationControl();
        polyrhythmPage = new TabPage();
        polyrhythmCreatorControl1 = new Controls.PolyrhythmCreatorControl();
        tabControl1.SuspendLayout();
        transformerPage.SuspendLayout();
        timingPointGenerationPage.SuspendLayout();
        polyrhythmPage.SuspendLayout();
        SuspendLayout();
        // 
        // loadBeatmapDialog
        // 
        loadBeatmapDialog.InitialDirectory = "%localappdata%/osu!";
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(transformerPage);
        tabControl1.Controls.Add(timingPointGenerationPage);
        tabControl1.Controls.Add(polyrhythmPage);
        tabControl1.Dock = DockStyle.Fill;
        tabControl1.Location = new Point(6, 6);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(1136, 672);
        tabControl1.TabIndex = 0;
        // 
        // transformerPage
        // 
        transformerPage.Controls.Add(beatmapTransformerControl1);
        transformerPage.Location = new Point(4, 24);
        transformerPage.Name = "transformerPage";
        transformerPage.Padding = new Padding(3);
        transformerPage.Size = new Size(1128, 644);
        transformerPage.TabIndex = 0;
        transformerPage.Text = "Transformer";
        transformerPage.UseVisualStyleBackColor = true;
        // 
        // beatmapTransformerControl1
        // 
        beatmapTransformerControl1.AutoSize = true;
        beatmapTransformerControl1.Location = new Point(0, 0);
        beatmapTransformerControl1.Name = "beatmapTransformerControl1";
        beatmapTransformerControl1.Size = new Size(1129, 647);
        beatmapTransformerControl1.TabIndex = 0;
        // 
        // timingPointGenerationPage
        // 
        timingPointGenerationPage.Controls.Add(simpleGeneratorsControl1);
        timingPointGenerationPage.Location = new Point(4, 24);
        timingPointGenerationPage.Name = "timingPointGenerationPage";
        timingPointGenerationPage.Padding = new Padding(3);
        timingPointGenerationPage.Size = new Size(1128, 644);
        timingPointGenerationPage.TabIndex = 1;
        timingPointGenerationPage.Text = "Timing Point Generation";
        timingPointGenerationPage.UseVisualStyleBackColor = true;
        // 
        // simpleGeneratorsControl1
        // 
        simpleGeneratorsControl1.Location = new Point(393, 0);
        simpleGeneratorsControl1.Name = "simpleGeneratorsControl1";
        simpleGeneratorsControl1.Size = new Size(733, 643);
        simpleGeneratorsControl1.TabIndex = 0;
        // 
        // polyrhythmPage
        // 
        polyrhythmPage.Controls.Add(polyrhythmCreatorControl1);
        polyrhythmPage.Location = new Point(4, 24);
        polyrhythmPage.Name = "polyrhythmPage";
        polyrhythmPage.Padding = new Padding(3);
        polyrhythmPage.Size = new Size(1128, 644);
        polyrhythmPage.TabIndex = 2;
        polyrhythmPage.Text = "Polyrhythm";
        polyrhythmPage.UseVisualStyleBackColor = true;
        // 
        // polyrhythmCreatorControl1
        // 
        polyrhythmCreatorControl1.Location = new Point(0, 0);
        polyrhythmCreatorControl1.Name = "polyrhythmCreatorControl1";
        polyrhythmCreatorControl1.Size = new Size(1127, 643);
        polyrhythmCreatorControl1.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1148, 684);
        Controls.Add(tabControl1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "MainForm";
        Padding = new Padding(6);
        Text = "osu! file tools";
        tabControl1.ResumeLayout(false);
        transformerPage.ResumeLayout(false);
        transformerPage.PerformLayout();
        timingPointGenerationPage.ResumeLayout(false);
        polyrhythmPage.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private OpenFileDialog loadBeatmapDialog;
    private SaveFileDialog saveDialogBeatmap;
    private TabControl tabControl1;
    private TabPage transformerPage;
    private TabPage timingPointGenerationPage;
    private TabPage polyrhythmPage;
    private Controls.BeatmapTransformerControl beatmapTransformerControl1;
    private Controls.TimingPointGenerationControl simpleGeneratorsControl1;
    private Controls.PolyrhythmCreatorControl polyrhythmCreatorControl1;
}
