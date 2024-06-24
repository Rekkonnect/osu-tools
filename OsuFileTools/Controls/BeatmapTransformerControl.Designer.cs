namespace OsuFileTools.Controls;

partial class BeatmapTransformerControl
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
        groupBox3 = new GroupBox();
        groupBox5 = new GroupBox();
        applyInheritedTimingPointButton = new Button();
        inheritedTimingPointCreatorBaselineBpmNumeric = new NumericUpDown();
        label6 = new Label();
        groupBox4 = new GroupBox();
        applyTimingPointResnapButton = new Button();
        timingPointResnapperPreviousBeatLength = new NumericUpDown();
        label3 = new Label();
        timingPointResnapperDivisor = new NumericUpDown();
        label2 = new Label();
        label1 = new Label();
        groupBox2 = new GroupBox();
        revertTransformedBeatmapButton = new Button();
        saveTransformedBeatmapButton = new Button();
        transformedBeatmapText = new TextBox();
        groupBox1 = new GroupBox();
        loadSourceBeatmapButton = new Button();
        sourceBeatmapText = new TextBox();
        loadBeatmapDialog = new OpenFileDialog();
        saveDialogBeatmap = new SaveFileDialog();
        groupBox3.SuspendLayout();
        groupBox5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)inheritedTimingPointCreatorBaselineBpmNumeric).BeginInit();
        groupBox4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)timingPointResnapperPreviousBeatLength).BeginInit();
        ((System.ComponentModel.ISupportInitialize)timingPointResnapperDivisor).BeginInit();
        groupBox2.SuspendLayout();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(groupBox5);
        groupBox3.Controls.Add(groupBox4);
        groupBox3.Location = new Point(786, 0);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(340, 643);
        groupBox3.TabIndex = 5;
        groupBox3.TabStop = false;
        groupBox3.Text = "Transformations";
        // 
        // groupBox5
        // 
        groupBox5.Controls.Add(applyInheritedTimingPointButton);
        groupBox5.Controls.Add(inheritedTimingPointCreatorBaselineBpmNumeric);
        groupBox5.Controls.Add(label6);
        groupBox5.Location = new Point(6, 149);
        groupBox5.Name = "groupBox5";
        groupBox5.Size = new Size(328, 121);
        groupBox5.TabIndex = 6;
        groupBox5.TabStop = false;
        groupBox5.Text = "Inherited Timing Point Creator";
        // 
        // applyInheritedTimingPointButton
        // 
        applyInheritedTimingPointButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        applyInheritedTimingPointButton.Location = new Point(226, 86);
        applyInheritedTimingPointButton.Name = "applyInheritedTimingPointButton";
        applyInheritedTimingPointButton.Size = new Size(96, 29);
        applyInheritedTimingPointButton.TabIndex = 5;
        applyInheritedTimingPointButton.Text = "Apply";
        applyInheritedTimingPointButton.UseVisualStyleBackColor = true;
        // 
        // inheritedTimingPointCreatorBaselineBpmNumeric
        // 
        inheritedTimingPointCreatorBaselineBpmNumeric.DecimalPlaces = 6;
        inheritedTimingPointCreatorBaselineBpmNumeric.Location = new Point(139, 22);
        inheritedTimingPointCreatorBaselineBpmNumeric.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        inheritedTimingPointCreatorBaselineBpmNumeric.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
        inheritedTimingPointCreatorBaselineBpmNumeric.Name = "inheritedTimingPointCreatorBaselineBpmNumeric";
        inheritedTimingPointCreatorBaselineBpmNumeric.Size = new Size(183, 23);
        inheritedTimingPointCreatorBaselineBpmNumeric.TabIndex = 4;
        inheritedTimingPointCreatorBaselineBpmNumeric.Value = new decimal(new int[] { 165, 0, 0, 0 });
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(55, 24);
        label6.Name = "label6";
        label6.Size = new Size(78, 15);
        label6.TabIndex = 0;
        label6.Text = "Baseline BPM";
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(applyTimingPointResnapButton);
        groupBox4.Controls.Add(timingPointResnapperPreviousBeatLength);
        groupBox4.Controls.Add(label3);
        groupBox4.Controls.Add(timingPointResnapperDivisor);
        groupBox4.Controls.Add(label2);
        groupBox4.Controls.Add(label1);
        groupBox4.Location = new Point(6, 22);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(328, 121);
        groupBox4.TabIndex = 0;
        groupBox4.TabStop = false;
        groupBox4.Text = "Timing Point Resnapper";
        // 
        // applyTimingPointResnapButton
        // 
        applyTimingPointResnapButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        applyTimingPointResnapButton.Location = new Point(226, 86);
        applyTimingPointResnapButton.Name = "applyTimingPointResnapButton";
        applyTimingPointResnapButton.Size = new Size(96, 29);
        applyTimingPointResnapButton.TabIndex = 5;
        applyTimingPointResnapButton.Text = "Apply";
        applyTimingPointResnapButton.UseVisualStyleBackColor = true;
        // 
        // timingPointResnapperPreviousBeatLength
        // 
        timingPointResnapperPreviousBeatLength.DecimalPlaces = 17;
        timingPointResnapperPreviousBeatLength.Location = new Point(139, 22);
        timingPointResnapperPreviousBeatLength.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        timingPointResnapperPreviousBeatLength.Name = "timingPointResnapperPreviousBeatLength";
        timingPointResnapperPreviousBeatLength.Size = new Size(183, 23);
        timingPointResnapperPreviousBeatLength.TabIndex = 4;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(139, 49);
        label3.Name = "label3";
        label3.Size = new Size(21, 15);
        label3.TabIndex = 3;
        label3.Text = "1 /";
        // 
        // timingPointResnapperDivisor
        // 
        timingPointResnapperDivisor.Location = new Point(160, 47);
        timingPointResnapperDivisor.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
        timingPointResnapperDivisor.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        timingPointResnapperDivisor.Name = "timingPointResnapperDivisor";
        timingPointResnapperDivisor.Size = new Size(59, 23);
        timingPointResnapperDivisor.TabIndex = 2;
        timingPointResnapperDivisor.Value = new decimal(new int[] { 8, 0, 0, 0 });
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(64, 49);
        label2.Name = "label2";
        label2.Size = new Size(69, 15);
        label2.TabIndex = 1;
        label2.Text = "Beat Divisor";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(15, 24);
        label1.Name = "label1";
        label1.Size = new Size(118, 15);
        label1.TabIndex = 0;
        label1.Text = "Previous Beat Length";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(revertTransformedBeatmapButton);
        groupBox2.Controls.Add(saveTransformedBeatmapButton);
        groupBox2.Controls.Add(transformedBeatmapText);
        groupBox2.Location = new Point(393, 0);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(387, 643);
        groupBox2.TabIndex = 4;
        groupBox2.TabStop = false;
        groupBox2.Text = "Transformed Beatmap";
        // 
        // revertTransformedBeatmapButton
        // 
        revertTransformedBeatmapButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        revertTransformedBeatmapButton.Location = new Point(6, 22);
        revertTransformedBeatmapButton.Name = "revertTransformedBeatmapButton";
        revertTransformedBeatmapButton.Size = new Size(96, 25);
        revertTransformedBeatmapButton.TabIndex = 8;
        revertTransformedBeatmapButton.Text = "Revert";
        revertTransformedBeatmapButton.UseVisualStyleBackColor = true;
        // 
        // saveTransformedBeatmapButton
        // 
        saveTransformedBeatmapButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        saveTransformedBeatmapButton.Location = new Point(285, 22);
        saveTransformedBeatmapButton.Name = "saveTransformedBeatmapButton";
        saveTransformedBeatmapButton.Size = new Size(96, 25);
        saveTransformedBeatmapButton.TabIndex = 7;
        saveTransformedBeatmapButton.Text = "Save";
        saveTransformedBeatmapButton.UseVisualStyleBackColor = true;
        // 
        // transformedBeatmapText
        // 
        transformedBeatmapText.Location = new Point(6, 53);
        transformedBeatmapText.MaxLength = 9999999;
        transformedBeatmapText.Multiline = true;
        transformedBeatmapText.Name = "transformedBeatmapText";
        transformedBeatmapText.ScrollBars = ScrollBars.Both;
        transformedBeatmapText.Size = new Size(375, 584);
        transformedBeatmapText.TabIndex = 0;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(loadSourceBeatmapButton);
        groupBox1.Controls.Add(sourceBeatmapText);
        groupBox1.Location = new Point(0, 0);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(387, 643);
        groupBox1.TabIndex = 3;
        groupBox1.TabStop = false;
        groupBox1.Text = "Source Beatmap";
        // 
        // loadSourceBeatmapButton
        // 
        loadSourceBeatmapButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        loadSourceBeatmapButton.Location = new Point(6, 22);
        loadSourceBeatmapButton.Name = "loadSourceBeatmapButton";
        loadSourceBeatmapButton.Size = new Size(96, 25);
        loadSourceBeatmapButton.TabIndex = 6;
        loadSourceBeatmapButton.Text = "Load";
        loadSourceBeatmapButton.UseVisualStyleBackColor = true;
        // 
        // sourceBeatmapText
        // 
        sourceBeatmapText.Location = new Point(6, 53);
        sourceBeatmapText.MaxLength = 9999999;
        sourceBeatmapText.Multiline = true;
        sourceBeatmapText.Name = "sourceBeatmapText";
        sourceBeatmapText.ScrollBars = ScrollBars.Both;
        sourceBeatmapText.Size = new Size(375, 584);
        sourceBeatmapText.TabIndex = 0;
        // 
        // loadBeatmapDialog
        // 
        loadBeatmapDialog.InitialDirectory = "%localappdata%/osu!";
        // 
        // BeatmapTransformerControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Name = "BeatmapTransformerControl";
        Size = new Size(1129, 643);
        groupBox3.ResumeLayout(false);
        groupBox5.ResumeLayout(false);
        groupBox5.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)inheritedTimingPointCreatorBaselineBpmNumeric).EndInit();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)timingPointResnapperPreviousBeatLength).EndInit();
        ((System.ComponentModel.ISupportInitialize)timingPointResnapperDivisor).EndInit();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox3;
    private GroupBox groupBox5;
    private Button applyInheritedTimingPointButton;
    private NumericUpDown inheritedTimingPointCreatorBaselineBpmNumeric;
    private Label label6;
    private GroupBox groupBox4;
    private Button applyTimingPointResnapButton;
    private NumericUpDown timingPointResnapperPreviousBeatLength;
    private Label label3;
    private NumericUpDown timingPointResnapperDivisor;
    private Label label2;
    private Label label1;
    private GroupBox groupBox2;
    private Button revertTransformedBeatmapButton;
    private Button saveTransformedBeatmapButton;
    private TextBox transformedBeatmapText;
    private GroupBox groupBox1;
    private Button loadSourceBeatmapButton;
    private TextBox sourceBeatmapText;
    private OpenFileDialog loadBeatmapDialog;
    private SaveFileDialog saveDialogBeatmap;
}
