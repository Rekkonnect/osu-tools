namespace OsuFileTools.Controls;

partial class HitsoundExtractorControl
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
        sourcePathText = new TextBox();
        label1 = new Label();
        label2 = new Label();
        targetPathText = new TextBox();
        sourceBrowseButton = new Button();
        targetBrowseButton = new Button();
        performOperationButton = new Button();
        openFileDialog = new OpenFileDialog();
        includeStoryboardSoundsCheck = new CheckBox();
        keyCountNumeric = new NumericUpDown();
        label3 = new Label();
        convertLongNotesToRiceCheck = new CheckBox();
        hitsoundDifficultyText = new TextBox();
        label4 = new Label();
        ((System.ComponentModel.ISupportInitialize)keyCountNumeric).BeginInit();
        SuspendLayout();
        // 
        // sourcePathText
        // 
        sourcePathText.Location = new Point(71, 23);
        sourcePathText.Name = "sourcePathText";
        sourcePathText.Size = new Size(378, 23);
        sourcePathText.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(22, 26);
        label1.Name = "label1";
        label1.Size = new Size(43, 15);
        label1.TabIndex = 1;
        label1.Text = "Source";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(26, 55);
        label2.Name = "label2";
        label2.Size = new Size(39, 15);
        label2.TabIndex = 3;
        label2.Text = "Target";
        // 
        // targetPathText
        // 
        targetPathText.Location = new Point(71, 52);
        targetPathText.Name = "targetPathText";
        targetPathText.Size = new Size(378, 23);
        targetPathText.TabIndex = 2;
        // 
        // sourceBrowseButton
        // 
        sourceBrowseButton.Location = new Point(455, 23);
        sourceBrowseButton.Name = "sourceBrowseButton";
        sourceBrowseButton.Size = new Size(75, 23);
        sourceBrowseButton.TabIndex = 1;
        sourceBrowseButton.Text = "Browse";
        sourceBrowseButton.UseVisualStyleBackColor = true;
        sourceBrowseButton.Click += sourceBrowseButton_Click;
        // 
        // targetBrowseButton
        // 
        targetBrowseButton.Location = new Point(455, 52);
        targetBrowseButton.Name = "targetBrowseButton";
        targetBrowseButton.Size = new Size(75, 23);
        targetBrowseButton.TabIndex = 3;
        targetBrowseButton.Text = "Browse";
        targetBrowseButton.UseVisualStyleBackColor = true;
        targetBrowseButton.Click += targetBrowseButton_Click;
        // 
        // performOperationButton
        // 
        performOperationButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        performOperationButton.Location = new Point(236, 187);
        performOperationButton.Name = "performOperationButton";
        performOperationButton.Size = new Size(96, 29);
        performOperationButton.TabIndex = 12;
        performOperationButton.Text = "Extract";
        performOperationButton.UseVisualStyleBackColor = true;
        performOperationButton.Click += performOperationButton_Click;
        // 
        // includeStoryboardSoundsCheck
        // 
        includeStoryboardSoundsCheck.AutoSize = true;
        includeStoryboardSoundsCheck.Checked = true;
        includeStoryboardSoundsCheck.CheckState = CheckState.Checked;
        includeStoryboardSoundsCheck.Location = new Point(22, 89);
        includeStoryboardSoundsCheck.Name = "includeStoryboardSoundsCheck";
        includeStoryboardSoundsCheck.Size = new Size(166, 19);
        includeStoryboardSoundsCheck.TabIndex = 4;
        includeStoryboardSoundsCheck.Text = "Include storyboard sounds";
        includeStoryboardSoundsCheck.UseVisualStyleBackColor = true;
        // 
        // keyCountNumeric
        // 
        keyCountNumeric.Location = new Point(378, 88);
        keyCountNumeric.Maximum = new decimal(new int[] { 18, 0, 0, 0 });
        keyCountNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        keyCountNumeric.Name = "keyCountNumeric";
        keyCountNumeric.Size = new Size(152, 23);
        keyCountNumeric.TabIndex = 6;
        keyCountNumeric.Value = new decimal(new int[] { 9, 0, 0, 0 });
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(310, 90);
        label3.Name = "label3";
        label3.Size = new Size(62, 15);
        label3.TabIndex = 10;
        label3.Text = "Key Count";
        // 
        // convertLongNotesToRiceCheck
        // 
        convertLongNotesToRiceCheck.AutoSize = true;
        convertLongNotesToRiceCheck.Checked = true;
        convertLongNotesToRiceCheck.CheckState = CheckState.Checked;
        convertLongNotesToRiceCheck.Location = new Point(22, 119);
        convertLongNotesToRiceCheck.Name = "convertLongNotesToRiceCheck";
        convertLongNotesToRiceCheck.Size = new Size(163, 19);
        convertLongNotesToRiceCheck.TabIndex = 5;
        convertLongNotesToRiceCheck.Text = "Convert long notes to rice";
        convertLongNotesToRiceCheck.UseVisualStyleBackColor = true;
        // 
        // hitsoundDifficultyText
        // 
        hitsoundDifficultyText.Location = new Point(378, 117);
        hitsoundDifficultyText.Name = "hitsoundDifficultyText";
        hitsoundDifficultyText.Size = new Size(152, 23);
        hitsoundDifficultyText.TabIndex = 7;
        hitsoundDifficultyText.Text = "Hitsounds";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(282, 120);
        label4.Name = "label4";
        label4.Size = new Size(90, 15);
        label4.TabIndex = 13;
        label4.Text = "Difficulty Name";
        // 
        // HitsoundExtractorControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(label4);
        Controls.Add(hitsoundDifficultyText);
        Controls.Add(convertLongNotesToRiceCheck);
        Controls.Add(label3);
        Controls.Add(keyCountNumeric);
        Controls.Add(includeStoryboardSoundsCheck);
        Controls.Add(performOperationButton);
        Controls.Add(targetBrowseButton);
        Controls.Add(sourceBrowseButton);
        Controls.Add(label2);
        Controls.Add(targetPathText);
        Controls.Add(label1);
        Controls.Add(sourcePathText);
        Name = "HitsoundExtractorControl";
        Size = new Size(572, 249);
        ((System.ComponentModel.ISupportInitialize)keyCountNumeric).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox sourcePathText;
    private Label label1;
    private Label label2;
    private TextBox targetPathText;
    private Button sourceBrowseButton;
    private Button targetBrowseButton;
    private Button performOperationButton;
    private OpenFileDialog openFileDialog;
    private CheckBox includeStoryboardSoundsCheck;
    private NumericUpDown keyCountNumeric;
    private Label label3;
    private CheckBox convertLongNotesToRiceCheck;
    private TextBox hitsoundDifficultyText;
    private Label label4;
}
