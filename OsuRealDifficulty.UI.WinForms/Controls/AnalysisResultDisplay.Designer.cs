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
        groupBox1 = new GroupBox();
        label30 = new Label();
        instabilityLabel = new DifficultyResultLabel();
        label29 = new Label();
        overallLabel = new DifficultyResultLabel();
        groupBox4 = new GroupBox();
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
        groupBox5 = new GroupBox();
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
        groupBox2 = new GroupBox();
        techCategoryLabel = new CategoryDifficultyResultLabel();
        rhythmIrregularityLabel = new DifficultyResultLabel();
        label7 = new Label();
        patternSwitchLabel = new DifficultyResultLabel();
        label9 = new Label();
        flamLabel = new DifficultyResultLabel();
        label11 = new Label();
        groupBox3 = new GroupBox();
        staminaCategoryLabel = new CategoryDifficultyResultLabel();
        steadyRateStreamLabel = new DifficultyResultLabel();
        label19 = new Label();
        singleHandTrillLabel = new DifficultyResultLabel();
        label21 = new Label();
        longBurstLabel = new DifficultyResultLabel();
        label23 = new Label();
        jackDifficultyCategoryGroupBox = new GroupBox();
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
        dexterityDifficultyCategoryGroupBox = new GroupBox();
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
        outerGroupBox.SuspendLayout();
        groupBox1.SuspendLayout();
        groupBox4.SuspendLayout();
        groupBox5.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox3.SuspendLayout();
        jackDifficultyCategoryGroupBox.SuspendLayout();
        dexterityDifficultyCategoryGroupBox.SuspendLayout();
        SuspendLayout();
        // 
        // outerGroupBox
        // 
        outerGroupBox.BackColor = Color.FromArgb(30, 30, 30);
        outerGroupBox.Controls.Add(groupBox1);
        outerGroupBox.Controls.Add(groupBox4);
        outerGroupBox.Controls.Add(groupBox5);
        outerGroupBox.Controls.Add(groupBox2);
        outerGroupBox.Controls.Add(groupBox3);
        outerGroupBox.Controls.Add(jackDifficultyCategoryGroupBox);
        outerGroupBox.Controls.Add(dexterityDifficultyCategoryGroupBox);
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
        // groupBox1
        // 
        groupBox1.BackColor = Color.FromArgb(30, 30, 30);
        groupBox1.Controls.Add(label30);
        groupBox1.Controls.Add(instabilityLabel);
        groupBox1.Controls.Add(label29);
        groupBox1.Controls.Add(overallLabel);
        groupBox1.Dock = DockStyle.Bottom;
        groupBox1.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        groupBox1.ForeColor = Color.Silver;
        groupBox1.Location = new Point(6, 372);
        groupBox1.Margin = new Padding(6);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(4, 3, 4, 3);
        groupBox1.Size = new Size(356, 72);
        groupBox1.TabIndex = 20;
        groupBox1.TabStop = false;
        groupBox1.Text = "overall";
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
        // groupBox4
        // 
        groupBox4.BackColor = Color.FromArgb(30, 30, 30);
        groupBox4.Controls.Add(shieldLabel);
        groupBox4.Controls.Add(label25);
        groupBox4.Controls.Add(riceMixLabel);
        groupBox4.Controls.Add(label26);
        groupBox4.Controls.Add(longNotesCategoryLabel);
        groupBox4.Controls.Add(riceLnLabel);
        groupBox4.Controls.Add(label2);
        groupBox4.Controls.Add(inverseLabel);
        groupBox4.Controls.Add(label3);
        groupBox4.Controls.Add(lnShieldLabel);
        groupBox4.Controls.Add(label5);
        groupBox4.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        groupBox4.ForeColor = Color.Silver;
        groupBox4.Location = new Point(6, 247);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(175, 116);
        groupBox4.TabIndex = 5;
        groupBox4.TabStop = false;
        groupBox4.Text = "long notes";
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
        // groupBox5
        // 
        groupBox5.Controls.Add(visualDensityLabel);
        groupBox5.Controls.Add(label27);
        groupBox5.Controls.Add(burstLabel);
        groupBox5.Controls.Add(label28);
        groupBox5.Controls.Add(scrollingCategoryLabel);
        groupBox5.Controls.Add(stutterLabel);
        groupBox5.Controls.Add(label13);
        groupBox5.Controls.Add(slowLabel);
        groupBox5.Controls.Add(label15);
        groupBox5.Controls.Add(fastLabel);
        groupBox5.Controls.Add(label17);
        groupBox5.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        groupBox5.ForeColor = Color.Silver;
        groupBox5.Location = new Point(187, 247);
        groupBox5.Name = "groupBox5";
        groupBox5.Size = new Size(175, 116);
        groupBox5.TabIndex = 4;
        groupBox5.TabStop = false;
        groupBox5.Text = "scrolling";
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
        // groupBox2
        // 
        groupBox2.BackColor = Color.FromArgb(30, 30, 30);
        groupBox2.Controls.Add(techCategoryLabel);
        groupBox2.Controls.Add(rhythmIrregularityLabel);
        groupBox2.Controls.Add(label7);
        groupBox2.Controls.Add(patternSwitchLabel);
        groupBox2.Controls.Add(label9);
        groupBox2.Controls.Add(flamLabel);
        groupBox2.Controls.Add(label11);
        groupBox2.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        groupBox2.ForeColor = Color.Silver;
        groupBox2.Location = new Point(6, 160);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(175, 81);
        groupBox2.TabIndex = 3;
        groupBox2.TabStop = false;
        groupBox2.Text = "tech";
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
        // groupBox3
        // 
        groupBox3.Controls.Add(staminaCategoryLabel);
        groupBox3.Controls.Add(steadyRateStreamLabel);
        groupBox3.Controls.Add(label19);
        groupBox3.Controls.Add(singleHandTrillLabel);
        groupBox3.Controls.Add(label21);
        groupBox3.Controls.Add(longBurstLabel);
        groupBox3.Controls.Add(label23);
        groupBox3.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        groupBox3.ForeColor = Color.Silver;
        groupBox3.Location = new Point(187, 160);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(175, 81);
        groupBox3.TabIndex = 2;
        groupBox3.TabStop = false;
        groupBox3.Text = "stamina";
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
        // jackDifficultyCategoryGroupBox
        // 
        jackDifficultyCategoryGroupBox.BackColor = Color.FromArgb(30, 30, 30);
        jackDifficultyCategoryGroupBox.Controls.Add(jackCategoryLabel);
        jackDifficultyCategoryGroupBox.Controls.Add(fieldjackLabel);
        jackDifficultyCategoryGroupBox.Controls.Add(label14);
        jackDifficultyCategoryGroupBox.Controls.Add(doubleHandJackLabel);
        jackDifficultyCategoryGroupBox.Controls.Add(label16);
        jackDifficultyCategoryGroupBox.Controls.Add(chordjackLabel);
        jackDifficultyCategoryGroupBox.Controls.Add(label18);
        jackDifficultyCategoryGroupBox.Controls.Add(jackstreamLabel);
        jackDifficultyCategoryGroupBox.Controls.Add(label20);
        jackDifficultyCategoryGroupBox.Controls.Add(anchorLabel);
        jackDifficultyCategoryGroupBox.Controls.Add(label22);
        jackDifficultyCategoryGroupBox.Controls.Add(minijackLabel);
        jackDifficultyCategoryGroupBox.Controls.Add(label24);
        jackDifficultyCategoryGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        jackDifficultyCategoryGroupBox.ForeColor = Color.Silver;
        jackDifficultyCategoryGroupBox.Location = new Point(187, 19);
        jackDifficultyCategoryGroupBox.Name = "jackDifficultyCategoryGroupBox";
        jackDifficultyCategoryGroupBox.Size = new Size(175, 135);
        jackDifficultyCategoryGroupBox.TabIndex = 1;
        jackDifficultyCategoryGroupBox.TabStop = false;
        jackDifficultyCategoryGroupBox.Text = "jack";
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
        // dexterityDifficultyCategoryGroupBox
        // 
        dexterityDifficultyCategoryGroupBox.Controls.Add(dexterityCategoryLabel);
        dexterityDifficultyCategoryGroupBox.Controls.Add(chordGapLabel);
        dexterityDifficultyCategoryGroupBox.Controls.Add(label12);
        dexterityDifficultyCategoryGroupBox.Controls.Add(trillLabel);
        dexterityDifficultyCategoryGroupBox.Controls.Add(label10);
        dexterityDifficultyCategoryGroupBox.Controls.Add(speedLabel);
        dexterityDifficultyCategoryGroupBox.Controls.Add(label8);
        dexterityDifficultyCategoryGroupBox.Controls.Add(chordLabel);
        dexterityDifficultyCategoryGroupBox.Controls.Add(label6);
        dexterityDifficultyCategoryGroupBox.Controls.Add(singlestreamLabel);
        dexterityDifficultyCategoryGroupBox.Controls.Add(label4);
        dexterityDifficultyCategoryGroupBox.Controls.Add(dumpLabel);
        dexterityDifficultyCategoryGroupBox.Controls.Add(label1);
        dexterityDifficultyCategoryGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        dexterityDifficultyCategoryGroupBox.ForeColor = Color.Silver;
        dexterityDifficultyCategoryGroupBox.Location = new Point(6, 19);
        dexterityDifficultyCategoryGroupBox.Name = "dexterityDifficultyCategoryGroupBox";
        dexterityDifficultyCategoryGroupBox.Size = new Size(175, 135);
        dexterityDifficultyCategoryGroupBox.TabIndex = 0;
        dexterityDifficultyCategoryGroupBox.TabStop = false;
        dexterityDifficultyCategoryGroupBox.Text = "dexterity";
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
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        groupBox5.ResumeLayout(false);
        groupBox5.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        jackDifficultyCategoryGroupBox.ResumeLayout(false);
        jackDifficultyCategoryGroupBox.PerformLayout();
        dexterityDifficultyCategoryGroupBox.ResumeLayout(false);
        dexterityDifficultyCategoryGroupBox.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox outerGroupBox;
    private DifficultyResultLabel overallLabel;
    private Label label29;
    private GroupBox groupBox4;
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
    private GroupBox groupBox5;
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
    private GroupBox groupBox2;
    private CategoryDifficultyResultLabel techCategoryLabel;
    private DifficultyResultLabel rhythmIrregularityLabel;
    private Label label7;
    private DifficultyResultLabel patternSwitchLabel;
    private Label label9;
    private DifficultyResultLabel flamLabel;
    private Label label11;
    private GroupBox groupBox3;
    private CategoryDifficultyResultLabel staminaCategoryLabel;
    private DifficultyResultLabel steadyRateStreamLabel;
    private Label label19;
    private DifficultyResultLabel singleHandTrillLabel;
    private Label label21;
    private DifficultyResultLabel longBurstLabel;
    private Label label23;
    private GroupBox jackDifficultyCategoryGroupBox;
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
    private GroupBox dexterityDifficultyCategoryGroupBox;
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
    private GroupBox groupBox1;
    private Label label30;
    private DifficultyResultLabel instabilityLabel;
}
