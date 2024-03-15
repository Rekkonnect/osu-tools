namespace OsuRealDifficulty.UI.WinForms.Controls;

partial class AnalysisResultDisplay
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
        outerGroupBox = new GroupBox();
        overallGroupBox = new GroupBox();
        label30 = new Label();
        instabilityLabel = new DifficultyResultLabel();
        label29 = new Label();
        overallLabel = new DifficultyResultLabel();
        longNotesGroupBox = new GroupBox();
        shieldLabel = new DifficultyResultLabel();
        label25 = new Label();
        riceMixLabel = new DifficultyResultLabel();
        label26 = new Label();
        longNotesCategoryLabel = new CategoryDifficultyResultLabel();
        riceLnLabel = new DifficultyResultLabel();
        label2 = new Label();
        inverseLabel = new DifficultyResultLabel();
        label3 = new Label();
        lnShieldLabel = new DifficultyResultLabel();
        label5 = new Label();
        scrollingGroupBox = new GroupBox();
        visualDensityLabel = new DifficultyResultLabel();
        label27 = new Label();
        burstLabel = new DifficultyResultLabel();
        label28 = new Label();
        scrollingCategoryLabel = new CategoryDifficultyResultLabel();
        stutterLabel = new DifficultyResultLabel();
        label13 = new Label();
        slowLabel = new DifficultyResultLabel();
        label15 = new Label();
        fastLabel = new DifficultyResultLabel();
        label17 = new Label();
        techGroupBox = new GroupBox();
        techCategoryLabel = new CategoryDifficultyResultLabel();
        rhythmIrregularityLabel = new DifficultyResultLabel();
        label7 = new Label();
        patternSwitchLabel = new DifficultyResultLabel();
        label9 = new Label();
        flamLabel = new DifficultyResultLabel();
        label11 = new Label();
        staminaGroupBox = new GroupBox();
        staminaCategoryLabel = new CategoryDifficultyResultLabel();
        steadyRateStreamLabel = new DifficultyResultLabel();
        label19 = new Label();
        singleHandTrillLabel = new DifficultyResultLabel();
        label21 = new Label();
        longBurstLabel = new DifficultyResultLabel();
        label23 = new Label();
        jackGroupBox = new GroupBox();
        jackCategoryLabel = new CategoryDifficultyResultLabel();
        fieldjackLabel = new DifficultyResultLabel();
        label14 = new Label();
        doubleHandJackLabel = new DifficultyResultLabel();
        label16 = new Label();
        chordjackLabel = new DifficultyResultLabel();
        label18 = new Label();
        jackstreamLabel = new DifficultyResultLabel();
        label20 = new Label();
        anchorLabel = new DifficultyResultLabel();
        label22 = new Label();
        minijackLabel = new DifficultyResultLabel();
        label24 = new Label();
        dexterityGroupBox = new GroupBox();
        dexterityCategoryLabel = new CategoryDifficultyResultLabel();
        chordGapLabel = new DifficultyResultLabel();
        label12 = new Label();
        trillLabel = new DifficultyResultLabel();
        label10 = new Label();
        speedLabel = new DifficultyResultLabel();
        label8 = new Label();
        chordLabel = new DifficultyResultLabel();
        label6 = new Label();
        singlestreamLabel = new DifficultyResultLabel();
        label4 = new Label();
        dumpLabel = new DifficultyResultLabel();
        label1 = new Label();
        warningLabel = new Label();
        outerGroupBox.SuspendLayout();
        overallGroupBox.SuspendLayout();
        longNotesGroupBox.SuspendLayout();
        scrollingGroupBox.SuspendLayout();
        techGroupBox.SuspendLayout();
        staminaGroupBox.SuspendLayout();
        jackGroupBox.SuspendLayout();
        dexterityGroupBox.SuspendLayout();
        SuspendLayout();
        // 
        // outerGroupBox
        // 
        outerGroupBox.BackColor = Color.FromArgb(30, 30, 30);
        outerGroupBox.Controls.Add(overallGroupBox);
        outerGroupBox.Controls.Add(longNotesGroupBox);
        outerGroupBox.Controls.Add(scrollingGroupBox);
        outerGroupBox.Controls.Add(techGroupBox);
        outerGroupBox.Controls.Add(staminaGroupBox);
        outerGroupBox.Controls.Add(jackGroupBox);
        outerGroupBox.Controls.Add(dexterityGroupBox);
        outerGroupBox.Controls.Add(warningLabel);
        outerGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        outerGroupBox.ForeColor = Color.Silver;
        outerGroupBox.Location = new Point(0, 0);
        outerGroupBox.Name = "outerGroupBox";
        outerGroupBox.Padding = new Padding(6);
        outerGroupBox.Size = new Size(368, 450);
        outerGroupBox.TabIndex = 2;
        outerGroupBox.TabStop = false;
        outerGroupBox.Text = "analysis name";
        // 
        // overallGroupBox
        // 
        overallGroupBox.BackColor = Color.FromArgb(30, 30, 30);
        overallGroupBox.Controls.Add(label30);
        overallGroupBox.Controls.Add(instabilityLabel);
        overallGroupBox.Controls.Add(label29);
        overallGroupBox.Controls.Add(overallLabel);
        overallGroupBox.Dock = DockStyle.Bottom;
        overallGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        overallGroupBox.ForeColor = Color.Silver;
        overallGroupBox.Location = new Point(6, 372);
        overallGroupBox.Margin = new Padding(6);
        overallGroupBox.Name = "overallGroupBox";
        overallGroupBox.Padding = new Padding(4, 3, 4, 3);
        overallGroupBox.Size = new Size(356, 72);
        overallGroupBox.TabIndex = 20;
        overallGroupBox.TabStop = false;
        overallGroupBox.Text = "overall";
        // 
        // label30
        // 
        label30.AutoSize = true;
        label30.Font = new Font("Aptos Display", 15F, FontStyle.Bold);
        label30.ForeColor = Color.Silver;
        label30.Location = new Point(182, 18);
        label30.Margin = new Padding(4, 0, 4, 0);
        label30.Name = "label30";
        label30.Size = new Size(99, 25);
        label30.TabIndex = 20;
        label30.Text = "instability";
        // 
        // instabilityLabel
        // 
        instabilityLabel.AutoSize = true;
        instabilityLabel.DifficultyValue = 117.56D;
        instabilityLabel.Font = new Font("Aptos Display", 15F, FontStyle.Bold);
        instabilityLabel.ForeColor = Color.Silver;
        instabilityLabel.Location = new Point(271, 40);
        instabilityLabel.Margin = new Padding(4, 0, 4, 0);
        instabilityLabel.Name = "instabilityLabel";
        instabilityLabel.Size = new Size(72, 25);
        instabilityLabel.TabIndex = 21;
        instabilityLabel.Text = "117.56";
        // 
        // label29
        // 
        label29.AutoSize = true;
        label29.Font = new Font("Aptos Display", 15F, FontStyle.Bold);
        label29.ForeColor = Color.Silver;
        label29.Location = new Point(10, 18);
        label29.Margin = new Padding(4, 0, 4, 0);
        label29.Name = "label29";
        label29.Size = new Size(89, 25);
        label29.TabIndex = 18;
        label29.Text = "difficulty";
        // 
        // overallLabel
        // 
        overallLabel.AutoSize = true;
        overallLabel.DifficultyValue = 321.456D;
        overallLabel.Font = new Font("Aptos Display", 15F, FontStyle.Bold);
        overallLabel.ForeColor = Color.Silver;
        overallLabel.Location = new Point(90, 40);
        overallLabel.Margin = new Padding(4, 0, 4, 0);
        overallLabel.Name = "overallLabel";
        overallLabel.Size = new Size(72, 25);
        overallLabel.TabIndex = 19;
        overallLabel.Text = "321.46";
        // 
        // longNotesGroupBox
        // 
        longNotesGroupBox.BackColor = Color.FromArgb(30, 30, 30);
        longNotesGroupBox.Controls.Add(shieldLabel);
        longNotesGroupBox.Controls.Add(label25);
        longNotesGroupBox.Controls.Add(riceMixLabel);
        longNotesGroupBox.Controls.Add(label26);
        longNotesGroupBox.Controls.Add(longNotesCategoryLabel);
        longNotesGroupBox.Controls.Add(riceLnLabel);
        longNotesGroupBox.Controls.Add(label2);
        longNotesGroupBox.Controls.Add(inverseLabel);
        longNotesGroupBox.Controls.Add(label3);
        longNotesGroupBox.Controls.Add(lnShieldLabel);
        longNotesGroupBox.Controls.Add(label5);
        longNotesGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        longNotesGroupBox.ForeColor = Color.Silver;
        longNotesGroupBox.Location = new Point(6, 247);
        longNotesGroupBox.Name = "longNotesGroupBox";
        longNotesGroupBox.Size = new Size(175, 116);
        longNotesGroupBox.TabIndex = 5;
        longNotesGroupBox.TabStop = false;
        longNotesGroupBox.Text = "long notes";
        // 
        // shieldLabel
        // 
        shieldLabel.AutoSize = true;
        shieldLabel.DifficultyValue = 9.99D;
        shieldLabel.Font = new Font("Aptos Display", 10F);
        shieldLabel.ForeColor = Color.Silver;
        shieldLabel.Location = new Point(124, 74);
        shieldLabel.Margin = new Padding(4, 0, 4, 0);
        shieldLabel.Name = "shieldLabel";
        shieldLabel.Size = new Size(32, 18);
        shieldLabel.TabIndex = 29;
        shieldLabel.Text = "9.99";
        // 
        // label25
        // 
        label25.AutoSize = true;
        label25.Font = new Font("Aptos Display", 10F);
        label25.ForeColor = Color.Silver;
        label25.Location = new Point(5, 74);
        label25.Margin = new Padding(4, 0, 4, 0);
        label25.Name = "label25";
        label25.Size = new Size(41, 18);
        label25.TabIndex = 28;
        label25.Text = "shield";
        // 
        // riceMixLabel
        // 
        riceMixLabel.AutoSize = true;
        riceMixLabel.DifficultyValue = 9.99D;
        riceMixLabel.Font = new Font("Aptos Display", 10F);
        riceMixLabel.ForeColor = Color.Silver;
        riceMixLabel.Location = new Point(124, 20);
        riceMixLabel.Margin = new Padding(4, 0, 4, 0);
        riceMixLabel.Name = "riceMixLabel";
        riceMixLabel.Size = new Size(32, 18);
        riceMixLabel.TabIndex = 27;
        riceMixLabel.Text = "9.99";
        // 
        // label26
        // 
        label26.AutoSize = true;
        label26.Font = new Font("Aptos Display", 10F);
        label26.ForeColor = Color.Silver;
        label26.Location = new Point(5, 20);
        label26.Margin = new Padding(4, 0, 4, 0);
        label26.Name = "label26";
        label26.Size = new Size(52, 18);
        label26.TabIndex = 26;
        label26.Text = "rice mix";
        // 
        // longNotesCategoryLabel
        // 
        longNotesCategoryLabel.AutoSize = true;
        longNotesCategoryLabel.DifficultyValue = 10D;
        longNotesCategoryLabel.ForeColor = Color.Silver;
        longNotesCategoryLabel.Location = new Point(124, 0);
        longNotesCategoryLabel.Margin = new Padding(4, 0, 4, 0);
        longNotesCategoryLabel.Name = "longNotesCategoryLabel";
        longNotesCategoryLabel.Size = new Size(45, 19);
        longNotesCategoryLabel.TabIndex = 25;
        longNotesCategoryLabel.Text = "10.00";
        // 
        // riceLnLabel
        // 
        riceLnLabel.AutoSize = true;
        riceLnLabel.DifficultyValue = 9.99D;
        riceLnLabel.Font = new Font("Aptos Display", 10F);
        riceLnLabel.ForeColor = Color.Silver;
        riceLnLabel.Location = new Point(124, 38);
        riceLnLabel.Margin = new Padding(4, 0, 4, 0);
        riceLnLabel.Name = "riceLnLabel";
        riceLnLabel.Size = new Size(32, 18);
        riceLnLabel.TabIndex = 18;
        riceLnLabel.Text = "9.99";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Aptos Display", 10F);
        label2.ForeColor = Color.Silver;
        label2.Location = new Point(5, 38);
        label2.Margin = new Padding(4, 0, 4, 0);
        label2.Name = "label2";
        label2.Size = new Size(42, 18);
        label2.TabIndex = 17;
        label2.Text = "rice ln";
        // 
        // inverseLabel
        // 
        inverseLabel.AutoSize = true;
        inverseLabel.DifficultyValue = 9.99D;
        inverseLabel.Font = new Font("Aptos Display", 10F);
        inverseLabel.ForeColor = Color.Silver;
        inverseLabel.Location = new Point(124, 56);
        inverseLabel.Margin = new Padding(4, 0, 4, 0);
        inverseLabel.Name = "inverseLabel";
        inverseLabel.Size = new Size(32, 18);
        inverseLabel.TabIndex = 16;
        inverseLabel.Text = "9.99";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Aptos Display", 10F);
        label3.ForeColor = Color.Silver;
        label3.Location = new Point(5, 56);
        label3.Margin = new Padding(4, 0, 4, 0);
        label3.Name = "label3";
        label3.Size = new Size(48, 18);
        label3.TabIndex = 15;
        label3.Text = "inverse";
        // 
        // lnShieldLabel
        // 
        lnShieldLabel.AutoSize = true;
        lnShieldLabel.DifficultyValue = 12D;
        lnShieldLabel.Font = new Font("Aptos Display", 10F);
        lnShieldLabel.ForeColor = Color.Silver;
        lnShieldLabel.Location = new Point(124, 92);
        lnShieldLabel.Margin = new Padding(4, 0, 4, 0);
        lnShieldLabel.Name = "lnShieldLabel";
        lnShieldLabel.Size = new Size(39, 18);
        lnShieldLabel.TabIndex = 14;
        lnShieldLabel.Text = "12.00";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Aptos Display", 10F);
        label5.ForeColor = Color.Silver;
        label5.Location = new Point(5, 92);
        label5.Margin = new Padding(4, 0, 4, 0);
        label5.Name = "label5";
        label5.Size = new Size(54, 18);
        label5.TabIndex = 13;
        label5.Text = "ln shield";
        // 
        // scrollingGroupBox
        // 
        scrollingGroupBox.Controls.Add(visualDensityLabel);
        scrollingGroupBox.Controls.Add(label27);
        scrollingGroupBox.Controls.Add(burstLabel);
        scrollingGroupBox.Controls.Add(label28);
        scrollingGroupBox.Controls.Add(scrollingCategoryLabel);
        scrollingGroupBox.Controls.Add(stutterLabel);
        scrollingGroupBox.Controls.Add(label13);
        scrollingGroupBox.Controls.Add(slowLabel);
        scrollingGroupBox.Controls.Add(label15);
        scrollingGroupBox.Controls.Add(fastLabel);
        scrollingGroupBox.Controls.Add(label17);
        scrollingGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        scrollingGroupBox.ForeColor = Color.Silver;
        scrollingGroupBox.Location = new Point(187, 247);
        scrollingGroupBox.Name = "scrollingGroupBox";
        scrollingGroupBox.Size = new Size(175, 116);
        scrollingGroupBox.TabIndex = 4;
        scrollingGroupBox.TabStop = false;
        scrollingGroupBox.Text = "scrolling";
        // 
        // visualDensityLabel
        // 
        visualDensityLabel.AutoSize = true;
        visualDensityLabel.DifficultyValue = 17.3D;
        visualDensityLabel.Font = new Font("Aptos Display", 10F);
        visualDensityLabel.ForeColor = Color.Silver;
        visualDensityLabel.Location = new Point(124, 92);
        visualDensityLabel.Margin = new Padding(4, 0, 4, 0);
        visualDensityLabel.Name = "visualDensityLabel";
        visualDensityLabel.Size = new Size(39, 18);
        visualDensityLabel.TabIndex = 17;
        visualDensityLabel.Text = "17.30";
        // 
        // label27
        // 
        label27.AutoSize = true;
        label27.Font = new Font("Aptos Display", 10F);
        label27.ForeColor = Color.Silver;
        label27.Location = new Point(5, 92);
        label27.Margin = new Padding(4, 0, 4, 0);
        label27.Name = "label27";
        label27.Size = new Size(83, 18);
        label27.TabIndex = 16;
        label27.Text = "visual density";
        // 
        // burstLabel
        // 
        burstLabel.AutoSize = true;
        burstLabel.DifficultyValue = 9.99D;
        burstLabel.Font = new Font("Aptos Display", 10F);
        burstLabel.ForeColor = Color.Silver;
        burstLabel.Location = new Point(124, 56);
        burstLabel.Margin = new Padding(4, 0, 4, 0);
        burstLabel.Name = "burstLabel";
        burstLabel.Size = new Size(32, 18);
        burstLabel.TabIndex = 15;
        burstLabel.Text = "9.99";
        // 
        // label28
        // 
        label28.AutoSize = true;
        label28.Font = new Font("Aptos Display", 10F);
        label28.ForeColor = Color.Silver;
        label28.Location = new Point(5, 56);
        label28.Margin = new Padding(4, 0, 4, 0);
        label28.Name = "label28";
        label28.Size = new Size(36, 18);
        label28.TabIndex = 14;
        label28.Text = "burst";
        // 
        // scrollingCategoryLabel
        // 
        scrollingCategoryLabel.AutoSize = true;
        scrollingCategoryLabel.DifficultyValue = 10D;
        scrollingCategoryLabel.ForeColor = Color.Silver;
        scrollingCategoryLabel.Location = new Point(124, 0);
        scrollingCategoryLabel.Margin = new Padding(4, 0, 4, 0);
        scrollingCategoryLabel.Name = "scrollingCategoryLabel";
        scrollingCategoryLabel.Size = new Size(45, 19);
        scrollingCategoryLabel.TabIndex = 13;
        scrollingCategoryLabel.Text = "10.00";
        // 
        // stutterLabel
        // 
        stutterLabel.AutoSize = true;
        stutterLabel.DifficultyValue = 9.99D;
        stutterLabel.Font = new Font("Aptos Display", 10F);
        stutterLabel.ForeColor = Color.Silver;
        stutterLabel.Location = new Point(124, 74);
        stutterLabel.Margin = new Padding(4, 0, 4, 0);
        stutterLabel.Name = "stutterLabel";
        stutterLabel.Size = new Size(32, 18);
        stutterLabel.TabIndex = 6;
        stutterLabel.Text = "9.99";
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Font = new Font("Aptos Display", 10F);
        label13.ForeColor = Color.Silver;
        label13.Location = new Point(5, 74);
        label13.Margin = new Padding(4, 0, 4, 0);
        label13.Name = "label13";
        label13.Size = new Size(44, 18);
        label13.TabIndex = 5;
        label13.Text = "stutter";
        // 
        // slowLabel
        // 
        slowLabel.AutoSize = true;
        slowLabel.DifficultyValue = 9.99D;
        slowLabel.Font = new Font("Aptos Display", 10F);
        slowLabel.ForeColor = Color.Silver;
        slowLabel.Location = new Point(124, 20);
        slowLabel.Margin = new Padding(4, 0, 4, 0);
        slowLabel.Name = "slowLabel";
        slowLabel.Size = new Size(32, 18);
        slowLabel.TabIndex = 4;
        slowLabel.Text = "9.99";
        // 
        // label15
        // 
        label15.AutoSize = true;
        label15.Font = new Font("Aptos Display", 10F);
        label15.ForeColor = Color.Silver;
        label15.Location = new Point(5, 20);
        label15.Margin = new Padding(4, 0, 4, 0);
        label15.Name = "label15";
        label15.Size = new Size(34, 18);
        label15.TabIndex = 3;
        label15.Text = "slow";
        // 
        // fastLabel
        // 
        fastLabel.AutoSize = true;
        fastLabel.DifficultyValue = 9.99D;
        fastLabel.Font = new Font("Aptos Display", 10F);
        fastLabel.ForeColor = Color.Silver;
        fastLabel.Location = new Point(124, 38);
        fastLabel.Margin = new Padding(4, 0, 4, 0);
        fastLabel.Name = "fastLabel";
        fastLabel.Size = new Size(32, 18);
        fastLabel.TabIndex = 2;
        fastLabel.Text = "9.99";
        // 
        // label17
        // 
        label17.AutoSize = true;
        label17.Font = new Font("Aptos Display", 10F);
        label17.ForeColor = Color.Silver;
        label17.Location = new Point(5, 38);
        label17.Margin = new Padding(4, 0, 4, 0);
        label17.Name = "label17";
        label17.Size = new Size(29, 18);
        label17.TabIndex = 1;
        label17.Text = "fast";
        // 
        // techGroupBox
        // 
        techGroupBox.BackColor = Color.FromArgb(30, 30, 30);
        techGroupBox.Controls.Add(techCategoryLabel);
        techGroupBox.Controls.Add(rhythmIrregularityLabel);
        techGroupBox.Controls.Add(label7);
        techGroupBox.Controls.Add(patternSwitchLabel);
        techGroupBox.Controls.Add(label9);
        techGroupBox.Controls.Add(flamLabel);
        techGroupBox.Controls.Add(label11);
        techGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        techGroupBox.ForeColor = Color.Silver;
        techGroupBox.Location = new Point(6, 160);
        techGroupBox.Name = "techGroupBox";
        techGroupBox.Size = new Size(175, 81);
        techGroupBox.TabIndex = 3;
        techGroupBox.TabStop = false;
        techGroupBox.Text = "tech";
        // 
        // techCategoryLabel
        // 
        techCategoryLabel.AutoSize = true;
        techCategoryLabel.DifficultyValue = 10D;
        techCategoryLabel.ForeColor = Color.Silver;
        techCategoryLabel.Location = new Point(124, 0);
        techCategoryLabel.Margin = new Padding(4, 0, 4, 0);
        techCategoryLabel.Name = "techCategoryLabel";
        techCategoryLabel.Size = new Size(45, 19);
        techCategoryLabel.TabIndex = 25;
        techCategoryLabel.Text = "10.00";
        // 
        // rhythmIrregularityLabel
        // 
        rhythmIrregularityLabel.AutoSize = true;
        rhythmIrregularityLabel.DifficultyValue = 9.99D;
        rhythmIrregularityLabel.Font = new Font("Aptos Display", 10F);
        rhythmIrregularityLabel.ForeColor = Color.Silver;
        rhythmIrregularityLabel.Location = new Point(124, 38);
        rhythmIrregularityLabel.Margin = new Padding(4, 0, 4, 0);
        rhythmIrregularityLabel.Name = "rhythmIrregularityLabel";
        rhythmIrregularityLabel.Size = new Size(32, 18);
        rhythmIrregularityLabel.TabIndex = 18;
        rhythmIrregularityLabel.Text = "9.99";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Aptos Display", 10F);
        label7.ForeColor = Color.Silver;
        label7.Location = new Point(5, 38);
        label7.Margin = new Padding(4, 0, 4, 0);
        label7.Name = "label7";
        label7.Size = new Size(108, 18);
        label7.TabIndex = 17;
        label7.Text = "rhythm irregularity";
        // 
        // patternSwitchLabel
        // 
        patternSwitchLabel.AutoSize = true;
        patternSwitchLabel.DifficultyValue = 9.99D;
        patternSwitchLabel.Font = new Font("Aptos Display", 10F);
        patternSwitchLabel.ForeColor = Color.Silver;
        patternSwitchLabel.Location = new Point(124, 20);
        patternSwitchLabel.Margin = new Padding(4, 0, 4, 0);
        patternSwitchLabel.Name = "patternSwitchLabel";
        patternSwitchLabel.Size = new Size(32, 18);
        patternSwitchLabel.TabIndex = 16;
        patternSwitchLabel.Text = "9.99";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Font = new Font("Aptos Display", 10F);
        label9.ForeColor = Color.Silver;
        label9.Location = new Point(5, 20);
        label9.Margin = new Padding(4, 0, 4, 0);
        label9.Name = "label9";
        label9.Size = new Size(88, 18);
        label9.TabIndex = 15;
        label9.Text = "pattern switch";
        // 
        // flamLabel
        // 
        flamLabel.AutoSize = true;
        flamLabel.DifficultyValue = 12D;
        flamLabel.Font = new Font("Aptos Display", 10F);
        flamLabel.ForeColor = Color.Silver;
        flamLabel.Location = new Point(124, 56);
        flamLabel.Margin = new Padding(4, 0, 4, 0);
        flamLabel.Name = "flamLabel";
        flamLabel.Size = new Size(39, 18);
        flamLabel.TabIndex = 14;
        flamLabel.Text = "12.00";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Font = new Font("Aptos Display", 10F);
        label11.ForeColor = Color.Silver;
        label11.Location = new Point(5, 56);
        label11.Margin = new Padding(4, 0, 4, 0);
        label11.Name = "label11";
        label11.Size = new Size(33, 18);
        label11.TabIndex = 13;
        label11.Text = "flam";
        // 
        // staminaGroupBox
        // 
        staminaGroupBox.Controls.Add(staminaCategoryLabel);
        staminaGroupBox.Controls.Add(steadyRateStreamLabel);
        staminaGroupBox.Controls.Add(label19);
        staminaGroupBox.Controls.Add(singleHandTrillLabel);
        staminaGroupBox.Controls.Add(label21);
        staminaGroupBox.Controls.Add(longBurstLabel);
        staminaGroupBox.Controls.Add(label23);
        staminaGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        staminaGroupBox.ForeColor = Color.Silver;
        staminaGroupBox.Location = new Point(187, 160);
        staminaGroupBox.Name = "staminaGroupBox";
        staminaGroupBox.Size = new Size(175, 81);
        staminaGroupBox.TabIndex = 2;
        staminaGroupBox.TabStop = false;
        staminaGroupBox.Text = "stamina";
        // 
        // staminaCategoryLabel
        // 
        staminaCategoryLabel.AutoSize = true;
        staminaCategoryLabel.DifficultyValue = 10D;
        staminaCategoryLabel.ForeColor = Color.Silver;
        staminaCategoryLabel.Location = new Point(124, 0);
        staminaCategoryLabel.Margin = new Padding(4, 0, 4, 0);
        staminaCategoryLabel.Name = "staminaCategoryLabel";
        staminaCategoryLabel.Size = new Size(45, 19);
        staminaCategoryLabel.TabIndex = 13;
        staminaCategoryLabel.Text = "10.00";
        // 
        // steadyRateStreamLabel
        // 
        steadyRateStreamLabel.AutoSize = true;
        steadyRateStreamLabel.DifficultyValue = 9.99D;
        steadyRateStreamLabel.Font = new Font("Aptos Display", 10F);
        steadyRateStreamLabel.ForeColor = Color.Silver;
        steadyRateStreamLabel.Location = new Point(124, 38);
        steadyRateStreamLabel.Margin = new Padding(4, 0, 4, 0);
        steadyRateStreamLabel.Name = "steadyRateStreamLabel";
        steadyRateStreamLabel.Size = new Size(32, 18);
        steadyRateStreamLabel.TabIndex = 6;
        steadyRateStreamLabel.Text = "9.99";
        // 
        // label19
        // 
        label19.AutoSize = true;
        label19.Font = new Font("Aptos Display", 10F);
        label19.ForeColor = Color.Silver;
        label19.Location = new Point(5, 38);
        label19.Margin = new Padding(4, 0, 4, 0);
        label19.Name = "label19";
        label19.Size = new Size(112, 18);
        label19.TabIndex = 5;
        label19.Text = "steady rate stream";
        // 
        // singleHandTrillLabel
        // 
        singleHandTrillLabel.AutoSize = true;
        singleHandTrillLabel.DifficultyValue = 9.99D;
        singleHandTrillLabel.Font = new Font("Aptos Display", 10F);
        singleHandTrillLabel.ForeColor = Color.Silver;
        singleHandTrillLabel.Location = new Point(124, 56);
        singleHandTrillLabel.Margin = new Padding(4, 0, 4, 0);
        singleHandTrillLabel.Name = "singleHandTrillLabel";
        singleHandTrillLabel.Size = new Size(32, 18);
        singleHandTrillLabel.TabIndex = 4;
        singleHandTrillLabel.Text = "9.99";
        // 
        // label21
        // 
        label21.AutoSize = true;
        label21.Font = new Font("Aptos Display", 10F);
        label21.ForeColor = Color.Silver;
        label21.Location = new Point(5, 56);
        label21.Margin = new Padding(4, 0, 4, 0);
        label21.Name = "label21";
        label21.Size = new Size(91, 18);
        label21.TabIndex = 3;
        label21.Text = "single hand trill";
        // 
        // longBurstLabel
        // 
        longBurstLabel.AutoSize = true;
        longBurstLabel.DifficultyValue = 9.99D;
        longBurstLabel.Font = new Font("Aptos Display", 10F);
        longBurstLabel.ForeColor = Color.Silver;
        longBurstLabel.Location = new Point(124, 20);
        longBurstLabel.Margin = new Padding(4, 0, 4, 0);
        longBurstLabel.Name = "longBurstLabel";
        longBurstLabel.Size = new Size(32, 18);
        longBurstLabel.TabIndex = 2;
        longBurstLabel.Text = "9.99";
        // 
        // label23
        // 
        label23.AutoSize = true;
        label23.Font = new Font("Aptos Display", 10F);
        label23.ForeColor = Color.Silver;
        label23.Location = new Point(5, 20);
        label23.Margin = new Padding(4, 0, 4, 0);
        label23.Name = "label23";
        label23.Size = new Size(62, 18);
        label23.TabIndex = 1;
        label23.Text = "long burst";
        // 
        // jackGroupBox
        // 
        jackGroupBox.BackColor = Color.FromArgb(30, 30, 30);
        jackGroupBox.Controls.Add(jackCategoryLabel);
        jackGroupBox.Controls.Add(fieldjackLabel);
        jackGroupBox.Controls.Add(label14);
        jackGroupBox.Controls.Add(doubleHandJackLabel);
        jackGroupBox.Controls.Add(label16);
        jackGroupBox.Controls.Add(chordjackLabel);
        jackGroupBox.Controls.Add(label18);
        jackGroupBox.Controls.Add(jackstreamLabel);
        jackGroupBox.Controls.Add(label20);
        jackGroupBox.Controls.Add(anchorLabel);
        jackGroupBox.Controls.Add(label22);
        jackGroupBox.Controls.Add(minijackLabel);
        jackGroupBox.Controls.Add(label24);
        jackGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        jackGroupBox.ForeColor = Color.Silver;
        jackGroupBox.Location = new Point(187, 19);
        jackGroupBox.Name = "jackGroupBox";
        jackGroupBox.Size = new Size(175, 135);
        jackGroupBox.TabIndex = 1;
        jackGroupBox.TabStop = false;
        jackGroupBox.Text = "jack";
        // 
        // jackCategoryLabel
        // 
        jackCategoryLabel.AutoSize = true;
        jackCategoryLabel.DifficultyValue = 10D;
        jackCategoryLabel.ForeColor = Color.Silver;
        jackCategoryLabel.Location = new Point(124, 0);
        jackCategoryLabel.Margin = new Padding(4, 0, 4, 0);
        jackCategoryLabel.Name = "jackCategoryLabel";
        jackCategoryLabel.Size = new Size(45, 19);
        jackCategoryLabel.TabIndex = 25;
        jackCategoryLabel.Text = "10.00";
        // 
        // fieldjackLabel
        // 
        fieldjackLabel.AutoSize = true;
        fieldjackLabel.DifficultyValue = 18.99D;
        fieldjackLabel.Font = new Font("Aptos Display", 10F);
        fieldjackLabel.ForeColor = Color.Silver;
        fieldjackLabel.Location = new Point(124, 92);
        fieldjackLabel.Margin = new Padding(4, 0, 4, 0);
        fieldjackLabel.Name = "fieldjackLabel";
        fieldjackLabel.Size = new Size(39, 18);
        fieldjackLabel.TabIndex = 24;
        fieldjackLabel.Text = "18.99";
        // 
        // label14
        // 
        label14.AutoSize = true;
        label14.Font = new Font("Aptos Display", 10F);
        label14.ForeColor = Color.Silver;
        label14.Location = new Point(5, 92);
        label14.Margin = new Padding(4, 0, 4, 0);
        label14.Name = "label14";
        label14.Size = new Size(55, 18);
        label14.TabIndex = 23;
        label14.Text = "fieldjack";
        // 
        // doubleHandJackLabel
        // 
        doubleHandJackLabel.AutoSize = true;
        doubleHandJackLabel.DifficultyValue = 9.99D;
        doubleHandJackLabel.Font = new Font("Aptos Display", 10F);
        doubleHandJackLabel.ForeColor = Color.Silver;
        doubleHandJackLabel.Location = new Point(124, 110);
        doubleHandJackLabel.Margin = new Padding(4, 0, 4, 0);
        doubleHandJackLabel.Name = "doubleHandJackLabel";
        doubleHandJackLabel.Size = new Size(32, 18);
        doubleHandJackLabel.TabIndex = 22;
        doubleHandJackLabel.Text = "9.99";
        // 
        // label16
        // 
        label16.AutoSize = true;
        label16.Font = new Font("Aptos Display", 10F);
        label16.ForeColor = Color.Silver;
        label16.Location = new Point(5, 110);
        label16.Margin = new Padding(4, 0, 4, 0);
        label16.Name = "label16";
        label16.Size = new Size(103, 18);
        label16.TabIndex = 21;
        label16.Text = "double hand jack";
        // 
        // chordjackLabel
        // 
        chordjackLabel.AutoSize = true;
        chordjackLabel.DifficultyValue = 9.99D;
        chordjackLabel.Font = new Font("Aptos Display", 10F);
        chordjackLabel.ForeColor = Color.Silver;
        chordjackLabel.Location = new Point(124, 38);
        chordjackLabel.Margin = new Padding(4, 0, 4, 0);
        chordjackLabel.Name = "chordjackLabel";
        chordjackLabel.Size = new Size(32, 18);
        chordjackLabel.TabIndex = 20;
        chordjackLabel.Text = "9.99";
        // 
        // label18
        // 
        label18.AutoSize = true;
        label18.Font = new Font("Aptos Display", 10F);
        label18.ForeColor = Color.Silver;
        label18.Location = new Point(5, 38);
        label18.Margin = new Padding(4, 0, 4, 0);
        label18.Name = "label18";
        label18.Size = new Size(63, 18);
        label18.TabIndex = 19;
        label18.Text = "chordjack";
        // 
        // jackstreamLabel
        // 
        jackstreamLabel.AutoSize = true;
        jackstreamLabel.DifficultyValue = 9.99D;
        jackstreamLabel.Font = new Font("Aptos Display", 10F);
        jackstreamLabel.ForeColor = Color.Silver;
        jackstreamLabel.Location = new Point(124, 74);
        jackstreamLabel.Margin = new Padding(4, 0, 4, 0);
        jackstreamLabel.Name = "jackstreamLabel";
        jackstreamLabel.Size = new Size(32, 18);
        jackstreamLabel.TabIndex = 18;
        jackstreamLabel.Text = "9.99";
        // 
        // label20
        // 
        label20.AutoSize = true;
        label20.Font = new Font("Aptos Display", 10F);
        label20.ForeColor = Color.Silver;
        label20.Location = new Point(5, 74);
        label20.Margin = new Padding(4, 0, 4, 0);
        label20.Name = "label20";
        label20.Size = new Size(70, 18);
        label20.TabIndex = 17;
        label20.Text = "jackstream";
        // 
        // anchorLabel
        // 
        anchorLabel.AutoSize = true;
        anchorLabel.DifficultyValue = 9.99D;
        anchorLabel.Font = new Font("Aptos Display", 10F);
        anchorLabel.ForeColor = Color.Silver;
        anchorLabel.Location = new Point(124, 56);
        anchorLabel.Margin = new Padding(4, 0, 4, 0);
        anchorLabel.Name = "anchorLabel";
        anchorLabel.Size = new Size(32, 18);
        anchorLabel.TabIndex = 16;
        anchorLabel.Text = "9.99";
        // 
        // label22
        // 
        label22.AutoSize = true;
        label22.Font = new Font("Aptos Display", 10F);
        label22.ForeColor = Color.Silver;
        label22.Location = new Point(5, 56);
        label22.Margin = new Padding(4, 0, 4, 0);
        label22.Name = "label22";
        label22.Size = new Size(47, 18);
        label22.TabIndex = 15;
        label22.Text = "anchor";
        // 
        // minijackLabel
        // 
        minijackLabel.AutoSize = true;
        minijackLabel.DifficultyValue = 12D;
        minijackLabel.Font = new Font("Aptos Display", 10F);
        minijackLabel.ForeColor = Color.Silver;
        minijackLabel.Location = new Point(124, 20);
        minijackLabel.Margin = new Padding(4, 0, 4, 0);
        minijackLabel.Name = "minijackLabel";
        minijackLabel.Size = new Size(39, 18);
        minijackLabel.TabIndex = 14;
        minijackLabel.Text = "12.00";
        // 
        // label24
        // 
        label24.AutoSize = true;
        label24.Font = new Font("Aptos Display", 10F);
        label24.ForeColor = Color.Silver;
        label24.Location = new Point(5, 20);
        label24.Margin = new Padding(4, 0, 4, 0);
        label24.Name = "label24";
        label24.Size = new Size(55, 18);
        label24.TabIndex = 13;
        label24.Text = "minijack";
        // 
        // dexterityGroupBox
        // 
        dexterityGroupBox.Controls.Add(dexterityCategoryLabel);
        dexterityGroupBox.Controls.Add(chordGapLabel);
        dexterityGroupBox.Controls.Add(label12);
        dexterityGroupBox.Controls.Add(trillLabel);
        dexterityGroupBox.Controls.Add(label10);
        dexterityGroupBox.Controls.Add(speedLabel);
        dexterityGroupBox.Controls.Add(label8);
        dexterityGroupBox.Controls.Add(chordLabel);
        dexterityGroupBox.Controls.Add(label6);
        dexterityGroupBox.Controls.Add(singlestreamLabel);
        dexterityGroupBox.Controls.Add(label4);
        dexterityGroupBox.Controls.Add(dumpLabel);
        dexterityGroupBox.Controls.Add(label1);
        dexterityGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        dexterityGroupBox.ForeColor = Color.Silver;
        dexterityGroupBox.Location = new Point(6, 19);
        dexterityGroupBox.Name = "dexterityGroupBox";
        dexterityGroupBox.Size = new Size(175, 135);
        dexterityGroupBox.TabIndex = 0;
        dexterityGroupBox.TabStop = false;
        dexterityGroupBox.Text = "dexterity";
        // 
        // dexterityCategoryLabel
        // 
        dexterityCategoryLabel.AutoSize = true;
        dexterityCategoryLabel.DifficultyValue = 10D;
        dexterityCategoryLabel.ForeColor = Color.Silver;
        dexterityCategoryLabel.Location = new Point(124, 0);
        dexterityCategoryLabel.Margin = new Padding(4, 0, 4, 0);
        dexterityCategoryLabel.Name = "dexterityCategoryLabel";
        dexterityCategoryLabel.Size = new Size(45, 19);
        dexterityCategoryLabel.TabIndex = 13;
        dexterityCategoryLabel.Text = "10.00";
        // 
        // chordGapLabel
        // 
        chordGapLabel.AutoSize = true;
        chordGapLabel.DifficultyValue = 18.99D;
        chordGapLabel.Font = new Font("Aptos Display", 10F);
        chordGapLabel.ForeColor = Color.Silver;
        chordGapLabel.Location = new Point(124, 92);
        chordGapLabel.Margin = new Padding(4, 0, 4, 0);
        chordGapLabel.Name = "chordGapLabel";
        chordGapLabel.Size = new Size(39, 18);
        chordGapLabel.TabIndex = 12;
        chordGapLabel.Text = "18.99";
        // 
        // label12
        // 
        label12.AutoSize = true;
        label12.Font = new Font("Aptos Display", 10F);
        label12.ForeColor = Color.Silver;
        label12.Location = new Point(5, 92);
        label12.Margin = new Padding(4, 0, 4, 0);
        label12.Name = "label12";
        label12.Size = new Size(63, 18);
        label12.TabIndex = 11;
        label12.Text = "chord gap";
        // 
        // trillLabel
        // 
        trillLabel.AutoSize = true;
        trillLabel.DifficultyValue = 9.99D;
        trillLabel.Font = new Font("Aptos Display", 10F);
        trillLabel.ForeColor = Color.Silver;
        trillLabel.Location = new Point(124, 74);
        trillLabel.Margin = new Padding(4, 0, 4, 0);
        trillLabel.Name = "trillLabel";
        trillLabel.Size = new Size(32, 18);
        trillLabel.TabIndex = 10;
        trillLabel.Text = "9.99";
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Font = new Font("Aptos Display", 10F);
        label10.ForeColor = Color.Silver;
        label10.Location = new Point(5, 74);
        label10.Margin = new Padding(4, 0, 4, 0);
        label10.Name = "label10";
        label10.Size = new Size(25, 18);
        label10.TabIndex = 9;
        label10.Text = "trill";
        // 
        // speedLabel
        // 
        speedLabel.AutoSize = true;
        speedLabel.DifficultyValue = 9.99D;
        speedLabel.Font = new Font("Aptos Display", 10F);
        speedLabel.ForeColor = Color.Silver;
        speedLabel.Location = new Point(124, 20);
        speedLabel.Margin = new Padding(4, 0, 4, 0);
        speedLabel.Name = "speedLabel";
        speedLabel.Size = new Size(32, 18);
        speedLabel.TabIndex = 8;
        speedLabel.Text = "9.99";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Font = new Font("Aptos Display", 10F);
        label8.ForeColor = Color.Silver;
        label8.Location = new Point(5, 20);
        label8.Margin = new Padding(4, 0, 4, 0);
        label8.Name = "label8";
        label8.Size = new Size(42, 18);
        label8.TabIndex = 7;
        label8.Text = "speed";
        // 
        // chordLabel
        // 
        chordLabel.AutoSize = true;
        chordLabel.DifficultyValue = 9.99D;
        chordLabel.Font = new Font("Aptos Display", 10F);
        chordLabel.ForeColor = Color.Silver;
        chordLabel.Location = new Point(124, 38);
        chordLabel.Margin = new Padding(4, 0, 4, 0);
        chordLabel.Name = "chordLabel";
        chordLabel.Size = new Size(32, 18);
        chordLabel.TabIndex = 6;
        chordLabel.Text = "9.99";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Font = new Font("Aptos Display", 10F);
        label6.ForeColor = Color.Silver;
        label6.Location = new Point(5, 38);
        label6.Margin = new Padding(4, 0, 4, 0);
        label6.Name = "label6";
        label6.Size = new Size(40, 18);
        label6.TabIndex = 5;
        label6.Text = "chord";
        // 
        // singlestreamLabel
        // 
        singlestreamLabel.AutoSize = true;
        singlestreamLabel.DifficultyValue = 9.99D;
        singlestreamLabel.Font = new Font("Aptos Display", 10F);
        singlestreamLabel.ForeColor = Color.Silver;
        singlestreamLabel.Location = new Point(124, 110);
        singlestreamLabel.Margin = new Padding(4, 0, 4, 0);
        singlestreamLabel.Name = "singlestreamLabel";
        singlestreamLabel.Size = new Size(32, 18);
        singlestreamLabel.TabIndex = 4;
        singlestreamLabel.Text = "9.99";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Aptos Display", 10F);
        label4.ForeColor = Color.Silver;
        label4.Location = new Point(5, 110);
        label4.Margin = new Padding(4, 0, 4, 0);
        label4.Name = "label4";
        label4.Size = new Size(79, 18);
        label4.TabIndex = 3;
        label4.Text = "singlestream";
        // 
        // dumpLabel
        // 
        dumpLabel.AutoSize = true;
        dumpLabel.DifficultyValue = 9.99D;
        dumpLabel.Font = new Font("Aptos Display", 10F);
        dumpLabel.ForeColor = Color.Silver;
        dumpLabel.Location = new Point(124, 56);
        dumpLabel.Margin = new Padding(4, 0, 4, 0);
        dumpLabel.Name = "dumpLabel";
        dumpLabel.Size = new Size(32, 18);
        dumpLabel.TabIndex = 2;
        dumpLabel.Text = "9.99";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Aptos Display", 10F);
        label1.ForeColor = Color.Silver;
        label1.Location = new Point(5, 56);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(40, 18);
        label1.TabIndex = 1;
        label1.Text = "dump";
        // 
        // warningLabel
        // 
        warningLabel.Dock = DockStyle.Fill;
        warningLabel.Location = new Point(6, 24);
        warningLabel.Name = "warningLabel";
        warningLabel.Size = new Size(356, 420);
        warningLabel.TabIndex = 21;
        warningLabel.Text = "please select a beatmap\r\nto view its difficulty";
        warningLabel.TextAlign = ContentAlignment.MiddleCenter;
        warningLabel.Visible = false;
        // 
        // AnalysisResultDisplay
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(30, 30, 30);
        Controls.Add(outerGroupBox);
        DoubleBuffered = true;
        Font = new Font("Aptos Display", 10F);
        ForeColor = SystemColors.ControlLight;
        Name = "AnalysisResultDisplay";
        Size = new Size(368, 450);
        outerGroupBox.ResumeLayout(false);
        overallGroupBox.ResumeLayout(false);
        overallGroupBox.PerformLayout();
        longNotesGroupBox.ResumeLayout(false);
        longNotesGroupBox.PerformLayout();
        scrollingGroupBox.ResumeLayout(false);
        scrollingGroupBox.PerformLayout();
        techGroupBox.ResumeLayout(false);
        techGroupBox.PerformLayout();
        staminaGroupBox.ResumeLayout(false);
        staminaGroupBox.PerformLayout();
        jackGroupBox.ResumeLayout(false);
        jackGroupBox.PerformLayout();
        dexterityGroupBox.ResumeLayout(false);
        dexterityGroupBox.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox outerGroupBox;
    private DifficultyResultLabel overallLabel;
    private Label label29;
    private GroupBox longNotesGroupBox;
    private DifficultyResultLabel shieldLabel;
    private Label label25;
    private DifficultyResultLabel riceMixLabel;
    private Label label26;
    private CategoryDifficultyResultLabel longNotesCategoryLabel;
    private DifficultyResultLabel riceLnLabel;
    private Label label2;
    private DifficultyResultLabel inverseLabel;
    private Label label3;
    private DifficultyResultLabel lnShieldLabel;
    private Label label5;
    private GroupBox scrollingGroupBox;
    private DifficultyResultLabel visualDensityLabel;
    private Label label27;
    private DifficultyResultLabel burstLabel;
    private Label label28;
    private CategoryDifficultyResultLabel scrollingCategoryLabel;
    private DifficultyResultLabel stutterLabel;
    private Label label13;
    private DifficultyResultLabel slowLabel;
    private Label label15;
    private DifficultyResultLabel fastLabel;
    private Label label17;
    private GroupBox techGroupBox;
    private CategoryDifficultyResultLabel techCategoryLabel;
    private DifficultyResultLabel rhythmIrregularityLabel;
    private Label label7;
    private DifficultyResultLabel patternSwitchLabel;
    private Label label9;
    private DifficultyResultLabel flamLabel;
    private Label label11;
    private GroupBox staminaGroupBox;
    private CategoryDifficultyResultLabel staminaCategoryLabel;
    private DifficultyResultLabel steadyRateStreamLabel;
    private Label label19;
    private DifficultyResultLabel singleHandTrillLabel;
    private Label label21;
    private DifficultyResultLabel longBurstLabel;
    private Label label23;
    private GroupBox jackGroupBox;
    private CategoryDifficultyResultLabel jackCategoryLabel;
    private DifficultyResultLabel fieldjackLabel;
    private Label label14;
    private DifficultyResultLabel doubleHandJackLabel;
    private Label label16;
    private DifficultyResultLabel chordjackLabel;
    private Label label18;
    private DifficultyResultLabel jackstreamLabel;
    private Label label20;
    private DifficultyResultLabel anchorLabel;
    private Label label22;
    private DifficultyResultLabel minijackLabel;
    private Label label24;
    private GroupBox dexterityGroupBox;
    private CategoryDifficultyResultLabel dexterityCategoryLabel;
    private DifficultyResultLabel chordGapLabel;
    private Label label12;
    private DifficultyResultLabel trillLabel;
    private Label label10;
    private DifficultyResultLabel speedLabel;
    private Label label8;
    private DifficultyResultLabel chordLabel;
    private Label label6;
    private DifficultyResultLabel singlestreamLabel;
    private Label label4;
    private DifficultyResultLabel dumpLabel;
    private Label label1;
    private GroupBox overallGroupBox;
    private Label label30;
    private DifficultyResultLabel instabilityLabel;
    private Label warningLabel;
}
