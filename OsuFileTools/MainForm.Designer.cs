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
        groupBox1 = new GroupBox();
        loadSourceBeatmapButton = new Button();
        sourceBeatmapText = new TextBox();
        groupBox2 = new GroupBox();
        revertTransformedBeatmapButton = new Button();
        saveTransformedBeatmapButton = new Button();
        transformedBeatmapText = new TextBox();
        groupBox3 = new GroupBox();
        groupBox4 = new GroupBox();
        applyTimingPointResnapButton = new Button();
        timingPointResnapperPreviousBeatLength = new NumericUpDown();
        label3 = new Label();
        timingPointResnapperDivisor = new NumericUpDown();
        label2 = new Label();
        label1 = new Label();
        loadBeatmapDialog = new OpenFileDialog();
        saveDialogBeatmap = new SaveFileDialog();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox3.SuspendLayout();
        groupBox4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)timingPointResnapperPreviousBeatLength).BeginInit();
        ((System.ComponentModel.ISupportInitialize)timingPointResnapperDivisor).BeginInit();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(loadSourceBeatmapButton);
        groupBox1.Controls.Add(sourceBeatmapText);
        groupBox1.Location = new Point(12, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(387, 644);
        groupBox1.TabIndex = 0;
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
        loadSourceBeatmapButton.Click += loadSourceBeatmapButton_Click;
        // 
        // sourceBeatmapText
        // 
        sourceBeatmapText.Location = new Point(6, 53);
        sourceBeatmapText.MaxLength = 9999999;
        sourceBeatmapText.Multiline = true;
        sourceBeatmapText.Name = "sourceBeatmapText";
        sourceBeatmapText.ScrollBars = ScrollBars.Both;
        sourceBeatmapText.Size = new Size(375, 585);
        sourceBeatmapText.TabIndex = 0;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(revertTransformedBeatmapButton);
        groupBox2.Controls.Add(saveTransformedBeatmapButton);
        groupBox2.Controls.Add(transformedBeatmapText);
        groupBox2.Location = new Point(405, 12);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(387, 644);
        groupBox2.TabIndex = 1;
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
        revertTransformedBeatmapButton.Click += revertTransformedBeatmapButton_Click;
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
        saveTransformedBeatmapButton.Click += saveTransformedBeatmapButton_Click;
        // 
        // transformedBeatmapText
        // 
        transformedBeatmapText.Location = new Point(6, 53);
        transformedBeatmapText.MaxLength = 9999999;
        transformedBeatmapText.Multiline = true;
        transformedBeatmapText.Name = "transformedBeatmapText";
        transformedBeatmapText.ScrollBars = ScrollBars.Both;
        transformedBeatmapText.Size = new Size(375, 585);
        transformedBeatmapText.TabIndex = 0;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(groupBox4);
        groupBox3.Location = new Point(798, 12);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(340, 644);
        groupBox3.TabIndex = 2;
        groupBox3.TabStop = false;
        groupBox3.Text = "Transformations";
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
        applyTimingPointResnapButton.Click += applyTimingPointResnapButton_Click;
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
        // loadBeatmapDialog
        // 
        loadBeatmapDialog.InitialDirectory = "%localappdata%/osu!";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1150, 668);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Name = "MainForm";
        Text = "osu! Beatmap Transformer";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox3.ResumeLayout(false);
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)timingPointResnapperPreviousBeatLength).EndInit();
        ((System.ComponentModel.ISupportInitialize)timingPointResnapperDivisor).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox1;
    private TextBox sourceBeatmapText;
    private GroupBox groupBox2;
    private TextBox transformedBeatmapText;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private Label label1;
    private Label label3;
    private NumericUpDown timingPointResnapperDivisor;
    private Label label2;
    private Button applyTimingPointResnapButton;
    private NumericUpDown timingPointResnapperPreviousBeatLength;
    private Button loadSourceBeatmapButton;
    private Button saveTransformedBeatmapButton;
    private Button revertTransformedBeatmapButton;
    private OpenFileDialog loadBeatmapDialog;
    private SaveFileDialog saveDialogBeatmap;
}
