namespace OsuFileTools.Controls;

partial class SimpleGeneratorsControl
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
        label5 = new Label();
        generationOperationCombo = new ComboBox();
        createTimingPointsButton = new Button();
        groupBox4 = new GroupBox();
        endOffsetNumeric = new NumericUpDown();
        label7 = new Label();
        startOffsetNumeric = new NumericUpDown();
        label6 = new Label();
        bpmStepNumeric = new NumericUpDown();
        label4 = new Label();
        bpmChangeNominatorNumeric = new NumericUpDown();
        baseBpmNumeric = new NumericUpDown();
        label3 = new Label();
        bpmChangeDenominatorNumeric = new NumericUpDown();
        label2 = new Label();
        label1 = new Label();
        groupBox2 = new GroupBox();
        outputTimingPointsText = new TextBox();
        groupBox3.SuspendLayout();
        groupBox4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)endOffsetNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)startOffsetNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)bpmStepNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)bpmChangeNominatorNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)baseBpmNumeric).BeginInit();
        ((System.ComponentModel.ISupportInitialize)bpmChangeDenominatorNumeric).BeginInit();
        groupBox2.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(label5);
        groupBox3.Controls.Add(generationOperationCombo);
        groupBox3.Controls.Add(createTimingPointsButton);
        groupBox3.Controls.Add(groupBox4);
        groupBox3.Location = new Point(393, 0);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(340, 643);
        groupBox3.TabIndex = 9;
        groupBox3.TabStop = false;
        groupBox3.Text = "Operation";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(9, 25);
        label5.Name = "label5";
        label5.Size = new Size(121, 15);
        label5.TabIndex = 7;
        label5.Text = "Generation Operation";
        // 
        // generationOperationCombo
        // 
        generationOperationCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        generationOperationCombo.FormattingEnabled = true;
        generationOperationCombo.Items.AddRange(new object[] { "Linear BPM step" });
        generationOperationCombo.Location = new Point(145, 22);
        generationOperationCombo.Name = "generationOperationCombo";
        generationOperationCombo.Size = new Size(183, 23);
        generationOperationCombo.TabIndex = 1;
        // 
        // createTimingPointsButton
        // 
        createTimingPointsButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        createTimingPointsButton.Location = new Point(5, 260);
        createTimingPointsButton.Name = "createTimingPointsButton";
        createTimingPointsButton.Size = new Size(330, 29);
        createTimingPointsButton.TabIndex = 10;
        createTimingPointsButton.Text = "Create Timing Points";
        createTimingPointsButton.UseVisualStyleBackColor = true;
        createTimingPointsButton.Click += createTimingPointsButton_Click;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(endOffsetNumeric);
        groupBox4.Controls.Add(label7);
        groupBox4.Controls.Add(startOffsetNumeric);
        groupBox4.Controls.Add(label6);
        groupBox4.Controls.Add(bpmStepNumeric);
        groupBox4.Controls.Add(label4);
        groupBox4.Controls.Add(bpmChangeNominatorNumeric);
        groupBox4.Controls.Add(baseBpmNumeric);
        groupBox4.Controls.Add(label3);
        groupBox4.Controls.Add(bpmChangeDenominatorNumeric);
        groupBox4.Controls.Add(label2);
        groupBox4.Controls.Add(label1);
        groupBox4.Location = new Point(6, 63);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(328, 170);
        groupBox4.TabIndex = 0;
        groupBox4.TabStop = false;
        groupBox4.Text = "Options";
        // 
        // endOffsetNumeric
        // 
        endOffsetNumeric.DecimalPlaces = 3;
        endOffsetNumeric.Location = new Point(139, 51);
        endOffsetNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
        endOffsetNumeric.Name = "endOffsetNumeric";
        endOffsetNumeric.Size = new Size(183, 23);
        endOffsetNumeric.TabIndex = 3;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(37, 53);
        label7.Name = "label7";
        label7.Size = new Size(87, 15);
        label7.TabIndex = 10;
        label7.Text = "End offset (ms)";
        // 
        // startOffsetNumeric
        // 
        startOffsetNumeric.DecimalPlaces = 3;
        startOffsetNumeric.Location = new Point(139, 22);
        startOffsetNumeric.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
        startOffsetNumeric.Name = "startOffsetNumeric";
        startOffsetNumeric.Size = new Size(183, 23);
        startOffsetNumeric.TabIndex = 2;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(33, 24);
        label6.Name = "label6";
        label6.Size = new Size(91, 15);
        label6.TabIndex = 8;
        label6.Text = "Start offset (ms)";
        // 
        // bpmStepNumeric
        // 
        bpmStepNumeric.DecimalPlaces = 6;
        bpmStepNumeric.Location = new Point(139, 109);
        bpmStepNumeric.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
        bpmStepNumeric.Minimum = new decimal(new int[] { 90, 0, 0, int.MinValue });
        bpmStepNumeric.Name = "bpmStepNumeric";
        bpmStepNumeric.Size = new Size(183, 23);
        bpmStepNumeric.TabIndex = 5;
        bpmStepNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(67, 111);
        label4.Name = "label4";
        label4.Size = new Size(57, 15);
        label4.TabIndex = 6;
        label4.Text = "BPM step";
        // 
        // bpmChangeNominatorNumeric
        // 
        bpmChangeNominatorNumeric.Location = new Point(139, 138);
        bpmChangeNominatorNumeric.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
        bpmChangeNominatorNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        bpmChangeNominatorNumeric.Name = "bpmChangeNominatorNumeric";
        bpmChangeNominatorNumeric.Size = new Size(59, 23);
        bpmChangeNominatorNumeric.TabIndex = 6;
        bpmChangeNominatorNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // baseBpmNumeric
        // 
        baseBpmNumeric.DecimalPlaces = 6;
        baseBpmNumeric.Location = new Point(139, 80);
        baseBpmNumeric.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        baseBpmNumeric.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
        baseBpmNumeric.Name = "baseBpmNumeric";
        baseBpmNumeric.Size = new Size(183, 23);
        baseBpmNumeric.TabIndex = 4;
        baseBpmNumeric.Value = new decimal(new int[] { 165, 0, 0, 0 });
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(204, 140);
        label3.Name = "label3";
        label3.Size = new Size(12, 15);
        label3.TabIndex = 3;
        label3.Text = "/";
        // 
        // bpmChangeDenominatorNumeric
        // 
        bpmChangeDenominatorNumeric.Location = new Point(222, 138);
        bpmChangeDenominatorNumeric.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
        bpmChangeDenominatorNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        bpmChangeDenominatorNumeric.Name = "bpmChangeDenominatorNumeric";
        bpmChangeDenominatorNumeric.Size = new Size(59, 23);
        bpmChangeDenominatorNumeric.TabIndex = 7;
        bpmChangeDenominatorNumeric.Value = new decimal(new int[] { 4, 0, 0, 0 });
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(19, 140);
        label2.Name = "label2";
        label2.Size = new Size(105, 15);
        label2.TabIndex = 1;
        label2.Text = "BPM change every";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(65, 82);
        label1.Name = "label1";
        label1.Size = new Size(59, 15);
        label1.TabIndex = 0;
        label1.Text = "Base BPM";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(outputTimingPointsText);
        groupBox2.Location = new Point(0, 0);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(387, 643);
        groupBox2.TabIndex = 8;
        groupBox2.TabStop = false;
        groupBox2.Text = "Output Timing Points";
        // 
        // outputTimingPointsText
        // 
        outputTimingPointsText.Location = new Point(6, 22);
        outputTimingPointsText.MaxLength = 9999999;
        outputTimingPointsText.Multiline = true;
        outputTimingPointsText.Name = "outputTimingPointsText";
        outputTimingPointsText.ReadOnly = true;
        outputTimingPointsText.ScrollBars = ScrollBars.Both;
        outputTimingPointsText.Size = new Size(375, 615);
        outputTimingPointsText.TabIndex = 0;
        // 
        // SimpleGeneratorsControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Name = "SimpleGeneratorsControl";
        Size = new Size(733, 643);
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)endOffsetNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)startOffsetNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)bpmStepNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)bpmChangeNominatorNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)baseBpmNumeric).EndInit();
        ((System.ComponentModel.ISupportInitialize)bpmChangeDenominatorNumeric).EndInit();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox3;
    private Label label5;
    private ComboBox generationOperationCombo;
    private Button createTimingPointsButton;
    private GroupBox groupBox4;
    private NumericUpDown endOffsetNumeric;
    private Label label7;
    private NumericUpDown startOffsetNumeric;
    private Label label6;
    private NumericUpDown bpmStepNumeric;
    private Label label4;
    private NumericUpDown bpmChangeNominatorNumeric;
    private NumericUpDown baseBpmNumeric;
    private Label label3;
    private NumericUpDown bpmChangeDenominatorNumeric;
    private Label label2;
    private Label label1;
    private GroupBox groupBox2;
    private TextBox outputTimingPointsText;
}
