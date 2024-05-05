namespace OsuFileTools.TimingPointCreation;

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
        groupBox3 = new GroupBox();
        createTimingPointsButton = new Button();
        groupBox4 = new GroupBox();
        normalizedBpmNumeric = new NumericUpDown();
        label3 = new Label();
        normalBeatDivisorNumeric = new NumericUpDown();
        label2 = new Label();
        label1 = new Label();
        groupBox2 = new GroupBox();
        outputTimingPointsText = new TextBox();
        groupBox1 = new GroupBox();
        loadSourceNotationButton = new Button();
        sourceNotationText = new TextBox();
        loadNotationDialog = new OpenFileDialog();
        groupBox3.SuspendLayout();
        groupBox4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)normalizedBpmNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)normalBeatDivisorNumeric).BeginInit();
        groupBox2.SuspendLayout();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(createTimingPointsButton);
        groupBox3.Controls.Add(groupBox4);
        groupBox3.Location = new Point(910, 13);
        groupBox3.Margin = new Padding(3, 4, 3, 4);
        groupBox3.Name = "groupBox3";
        groupBox3.Padding = new Padding(3, 4, 3, 4);
        groupBox3.Size = new Size(389, 723);
        groupBox3.TabIndex = 5;
        groupBox3.TabStop = false;
        groupBox3.Text = "Options";
        // 
        // createTimingPointsButton
        // 
        createTimingPointsButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        createTimingPointsButton.Location = new Point(6, 188);
        createTimingPointsButton.Margin = new Padding(3, 4, 3, 4);
        createTimingPointsButton.Name = "createTimingPointsButton";
        createTimingPointsButton.Size = new Size(377, 39);
        createTimingPointsButton.TabIndex = 5;
        createTimingPointsButton.Text = "Create Timing Points";
        createTimingPointsButton.UseVisualStyleBackColor = true;
        createTimingPointsButton.Click += createTimingPointsButton_Click;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(normalizedBpmNumeric);
        groupBox4.Controls.Add(label3);
        groupBox4.Controls.Add(normalBeatDivisorNumeric);
        groupBox4.Controls.Add(label2);
        groupBox4.Controls.Add(label1);
        groupBox4.Location = new Point(7, 29);
        groupBox4.Margin = new Padding(3, 4, 3, 4);
        groupBox4.Name = "groupBox4";
        groupBox4.Padding = new Padding(3, 4, 3, 4);
        groupBox4.Size = new Size(375, 104);
        groupBox4.TabIndex = 0;
        groupBox4.TabStop = false;
        groupBox4.Text = "Options";
        // 
        // normalizedBpmNumeric
        // 
        normalizedBpmNumeric.DecimalPlaces = 6;
        normalizedBpmNumeric.Location = new Point(159, 29);
        normalizedBpmNumeric.Margin = new Padding(3, 4, 3, 4);
        normalizedBpmNumeric.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        normalizedBpmNumeric.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
        normalizedBpmNumeric.Name = "normalizedBpmNumeric";
        normalizedBpmNumeric.Size = new Size(209, 27);
        normalizedBpmNumeric.TabIndex = 4;
        normalizedBpmNumeric.Value = new decimal(new int[] { 165, 0, 0, 0 });
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(159, 66);
        label3.Name = "label3";
        label3.Size = new Size(27, 20);
        label3.TabIndex = 3;
        label3.Text = "1 /";
        // 
        // normalBeatDivisorNumeric
        // 
        normalBeatDivisorNumeric.Location = new Point(189, 64);
        normalBeatDivisorNumeric.Margin = new Padding(3, 4, 3, 4);
        normalBeatDivisorNumeric.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
        normalBeatDivisorNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        normalBeatDivisorNumeric.Name = "normalBeatDivisorNumeric";
        normalBeatDivisorNumeric.Size = new Size(67, 27);
        normalBeatDivisorNumeric.TabIndex = 2;
        normalBeatDivisorNumeric.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(10, 66);
        label2.Name = "label2";
        label2.Size = new Size(143, 20);
        label2.TabIndex = 1;
        label2.Text = "Normal Beat Divisor";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(32, 31);
        label1.Name = "label1";
        label1.Size = new Size(121, 20);
        label1.TabIndex = 0;
        label1.Text = "Normalized BPM";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(outputTimingPointsText);
        groupBox2.Location = new Point(461, 13);
        groupBox2.Margin = new Padding(3, 4, 3, 4);
        groupBox2.Name = "groupBox2";
        groupBox2.Padding = new Padding(3, 4, 3, 4);
        groupBox2.Size = new Size(442, 723);
        groupBox2.TabIndex = 4;
        groupBox2.TabStop = false;
        groupBox2.Text = "Output Timing Points";
        // 
        // outputTimingPointsText
        // 
        outputTimingPointsText.Location = new Point(7, 28);
        outputTimingPointsText.Margin = new Padding(3, 4, 3, 4);
        outputTimingPointsText.MaxLength = 9999999;
        outputTimingPointsText.Multiline = true;
        outputTimingPointsText.Name = "outputTimingPointsText";
        outputTimingPointsText.ReadOnly = true;
        outputTimingPointsText.ScrollBars = ScrollBars.Both;
        outputTimingPointsText.Size = new Size(428, 687);
        outputTimingPointsText.TabIndex = 0;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(loadSourceNotationButton);
        groupBox1.Controls.Add(sourceNotationText);
        groupBox1.Location = new Point(12, 13);
        groupBox1.Margin = new Padding(3, 4, 3, 4);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(3, 4, 3, 4);
        groupBox1.Size = new Size(442, 723);
        groupBox1.TabIndex = 3;
        groupBox1.TabStop = false;
        groupBox1.Text = "Source Notation";
        // 
        // loadSourceNotationButton
        // 
        loadSourceNotationButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        loadSourceNotationButton.Location = new Point(7, 29);
        loadSourceNotationButton.Margin = new Padding(3, 4, 3, 4);
        loadSourceNotationButton.Name = "loadSourceNotationButton";
        loadSourceNotationButton.Size = new Size(110, 33);
        loadSourceNotationButton.TabIndex = 6;
        loadSourceNotationButton.Text = "Load";
        loadSourceNotationButton.UseVisualStyleBackColor = true;
        loadSourceNotationButton.Click += loadSourceNotationButton_Click;
        // 
        // sourceNotationText
        // 
        sourceNotationText.Location = new Point(7, 71);
        sourceNotationText.Margin = new Padding(3, 4, 3, 4);
        sourceNotationText.MaxLength = 9999999;
        sourceNotationText.Multiline = true;
        sourceNotationText.Name = "sourceNotationText";
        sourceNotationText.ScrollBars = ScrollBars.Both;
        sourceNotationText.Size = new Size(428, 644);
        sourceNotationText.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1317, 749);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Name = "MainForm";
        Text = "osu! Polyrhythm Timing Point Creator";
        groupBox3.ResumeLayout(false);
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)normalizedBpmNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)normalBeatDivisorNumeric).EndInit();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private Button createTimingPointsButton;
    private NumericUpDown normalizedBpmNumeric;
    private Label label3;
    private NumericUpDown normalBeatDivisorNumeric;
    private Label label2;
    private Label label1;
    private GroupBox groupBox2;
    private TextBox outputTimingPointsText;
    private GroupBox groupBox1;
    private Button loadSourceNotationButton;
    private TextBox sourceNotationText;
    private OpenFileDialog loadNotationDialog;
}
