namespace OsuRealDifficulty.UI.WinForms;

partial class SettingsForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        contentPanel = new Panel();
        openSettingsFileButton = new Button();
        saveButton = new Button();
        resetButton = new Button();
        pathsGroupBox = new GroupBox();
        label4 = new Label();
        beatmapDirectoryTextBox = new TextBox();
        label3 = new Label();
        label2 = new Label();
        baseOsuDirectoryTextBox = new TextBox();
        generalGroupBox = new GroupBox();
        splitter1 = new PictureBox();
        splitter2 = new PictureBox();
        invalidateCachedCalculationsOnRefreshCheckBox = new CheckBox();
        label1 = new Label();
        analyzeBeatmapSetOnSelection = new CheckBox();
        analyzeSingleBeatmapOnSelectionCheckBox = new CheckBox();
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox = new CheckBox();
        analyzeAllBeatmapsOnStartupCheckBox = new CheckBox();
        contentPanel.SuspendLayout();
        pathsGroupBox.SuspendLayout();
        generalGroupBox.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitter1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)splitter2).BeginInit();
        SuspendLayout();
        // 
        // contentPanel
        // 
        contentPanel.Controls.Add(openSettingsFileButton);
        contentPanel.Controls.Add(saveButton);
        contentPanel.Controls.Add(resetButton);
        contentPanel.Controls.Add(pathsGroupBox);
        contentPanel.Controls.Add(generalGroupBox);
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Location = new Point(0, 0);
        contentPanel.Name = "contentPanel";
        contentPanel.Size = new Size(433, 551);
        contentPanel.TabIndex = 0;
        // 
        // openSettingsFileButton
        // 
        openSettingsFileButton.BackColor = Color.FromArgb(40, 40, 40);
        openSettingsFileButton.FlatAppearance.BorderColor = Color.Silver;
        openSettingsFileButton.FlatAppearance.MouseDownBackColor = Color.Gray;
        openSettingsFileButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 72, 72);
        openSettingsFileButton.FlatStyle = FlatStyle.Flat;
        openSettingsFileButton.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        openSettingsFileButton.ForeColor = Color.FromArgb(192, 192, 218);
        openSettingsFileButton.Location = new Point(12, 451);
        openSettingsFileButton.Name = "openSettingsFileButton";
        openSettingsFileButton.Size = new Size(140, 41);
        openSettingsFileButton.TabIndex = 47;
        openSettingsFileButton.Text = "open settings file";
        openSettingsFileButton.UseVisualStyleBackColor = false;
        openSettingsFileButton.Click += openSettingsFileButton_Click;
        // 
        // saveButton
        // 
        saveButton.BackColor = Color.FromArgb(40, 40, 40);
        saveButton.FlatAppearance.BorderColor = Color.Silver;
        saveButton.FlatAppearance.MouseDownBackColor = Color.Gray;
        saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 72, 72);
        saveButton.FlatStyle = FlatStyle.Flat;
        saveButton.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        saveButton.ForeColor = Color.FromArgb(192, 218, 192);
        saveButton.Location = new Point(12, 498);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(256, 41);
        saveButton.TabIndex = 45;
        saveButton.Text = "save";
        saveButton.UseVisualStyleBackColor = false;
        saveButton.Click += saveButton_Click;
        // 
        // resetButton
        // 
        resetButton.BackColor = Color.FromArgb(40, 40, 40);
        resetButton.FlatAppearance.BorderColor = Color.Silver;
        resetButton.FlatAppearance.MouseDownBackColor = Color.Gray;
        resetButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 72, 72);
        resetButton.FlatStyle = FlatStyle.Flat;
        resetButton.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        resetButton.ForeColor = Color.FromArgb(218, 192, 192);
        resetButton.Location = new Point(311, 498);
        resetButton.Name = "resetButton";
        resetButton.Size = new Size(110, 41);
        resetButton.TabIndex = 44;
        resetButton.Text = "reset changes";
        resetButton.UseVisualStyleBackColor = false;
        resetButton.Click += resetButton_Click;
        // 
        // pathsGroupBox
        // 
        pathsGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pathsGroupBox.Controls.Add(label4);
        pathsGroupBox.Controls.Add(beatmapDirectoryTextBox);
        pathsGroupBox.Controls.Add(label3);
        pathsGroupBox.Controls.Add(label2);
        pathsGroupBox.Controls.Add(baseOsuDirectoryTextBox);
        pathsGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        pathsGroupBox.ForeColor = Color.Silver;
        pathsGroupBox.Location = new Point(12, 250);
        pathsGroupBox.Name = "pathsGroupBox";
        pathsGroupBox.Size = new Size(409, 195);
        pathsGroupBox.TabIndex = 7;
        pathsGroupBox.TabStop = false;
        pathsGroupBox.Text = "paths";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Aptos Display", 10F);
        label4.ForeColor = SystemColors.ControlLight;
        label4.Location = new Point(6, 141);
        label4.Name = "label4";
        label4.Size = new Size(187, 18);
        label4.TabIndex = 11;
        label4.Text = "custom osu! beatmaps directory";
        label4.TextAlign = ContentAlignment.BottomRight;
        // 
        // beatmapDirectoryTextBox
        // 
        beatmapDirectoryTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        beatmapDirectoryTextBox.BackColor = Color.FromArgb(40, 40, 40);
        beatmapDirectoryTextBox.Font = new Font("Aptos Display", 11F);
        beatmapDirectoryTextBox.ForeColor = SystemColors.ControlLight;
        beatmapDirectoryTextBox.Location = new Point(6, 162);
        beatmapDirectoryTextBox.Name = "beatmapDirectoryTextBox";
        beatmapDirectoryTextBox.PlaceholderText = "no custom path";
        beatmapDirectoryTextBox.Size = new Size(397, 25);
        beatmapDirectoryTextBox.TabIndex = 10;
        beatmapDirectoryTextBox.TextChanged += beatmapDirectoryTextBox_TextChanged;
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        label3.Font = new Font("Aptos Display", 10F);
        label3.ForeColor = Color.Silver;
        label3.Location = new Point(6, 21);
        label3.Name = "label3";
        label3.Size = new Size(397, 61);
        label3.TabIndex = 9;
        label3.Text = "these settings affect the paths that are used to read the files\r\nfor the osu! database and the songs of the game\r\nin most cases you don't have to change anything here";
        label3.TextAlign = ContentAlignment.TopCenter;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Aptos Display", 10F);
        label2.ForeColor = SystemColors.ControlLight;
        label2.Location = new Point(6, 82);
        label2.Name = "label2";
        label2.Size = new Size(186, 18);
        label2.TabIndex = 8;
        label2.Text = "custom base osu! data directory";
        label2.TextAlign = ContentAlignment.BottomRight;
        // 
        // baseOsuDirectoryTextBox
        // 
        baseOsuDirectoryTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        baseOsuDirectoryTextBox.BackColor = Color.FromArgb(40, 40, 40);
        baseOsuDirectoryTextBox.Font = new Font("Aptos Display", 11F);
        baseOsuDirectoryTextBox.ForeColor = SystemColors.ControlLight;
        baseOsuDirectoryTextBox.Location = new Point(6, 103);
        baseOsuDirectoryTextBox.Name = "baseOsuDirectoryTextBox";
        baseOsuDirectoryTextBox.PlaceholderText = "no custom path";
        baseOsuDirectoryTextBox.Size = new Size(397, 25);
        baseOsuDirectoryTextBox.TabIndex = 0;
        baseOsuDirectoryTextBox.TextChanged += baseOsuDirectoryTextBox_TextChanged;
        // 
        // generalGroupBox
        // 
        generalGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        generalGroupBox.Controls.Add(splitter1);
        generalGroupBox.Controls.Add(splitter2);
        generalGroupBox.Controls.Add(invalidateCachedCalculationsOnRefreshCheckBox);
        generalGroupBox.Controls.Add(label1);
        generalGroupBox.Controls.Add(analyzeBeatmapSetOnSelection);
        generalGroupBox.Controls.Add(analyzeSingleBeatmapOnSelectionCheckBox);
        generalGroupBox.Controls.Add(analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox);
        generalGroupBox.Controls.Add(analyzeAllBeatmapsOnStartupCheckBox);
        generalGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        generalGroupBox.ForeColor = Color.Silver;
        generalGroupBox.Location = new Point(12, 12);
        generalGroupBox.Name = "generalGroupBox";
        generalGroupBox.Size = new Size(409, 232);
        generalGroupBox.TabIndex = 5;
        generalGroupBox.TabStop = false;
        generalGroupBox.Text = "general";
        // 
        // splitter1
        // 
        splitter1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        splitter1.BackColor = SystemColors.ControlLight;
        splitter1.Location = new Point(6, 99);
        splitter1.Name = "splitter1";
        splitter1.Size = new Size(396, 1);
        splitter1.TabIndex = 9;
        splitter1.TabStop = false;
        // 
        // splitter2
        // 
        splitter2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        splitter2.BackColor = Color.FromArgb(218, 192, 192);
        splitter2.Location = new Point(6, 161);
        splitter2.Name = "splitter2";
        splitter2.Size = new Size(396, 1);
        splitter2.TabIndex = 8;
        splitter2.TabStop = false;
        // 
        // invalidateCachedCalculationsOnRefreshCheckBox
        // 
        invalidateCachedCalculationsOnRefreshCheckBox.AutoSize = true;
        invalidateCachedCalculationsOnRefreshCheckBox.Font = new Font("Aptos Display", 10F);
        invalidateCachedCalculationsOnRefreshCheckBox.ForeColor = SystemColors.ControlLight;
        invalidateCachedCalculationsOnRefreshCheckBox.Location = new Point(15, 71);
        invalidateCachedCalculationsOnRefreshCheckBox.Margin = new Padding(12, 0, 6, 3);
        invalidateCachedCalculationsOnRefreshCheckBox.Name = "invalidateCachedCalculationsOnRefreshCheckBox";
        invalidateCachedCalculationsOnRefreshCheckBox.Size = new Size(256, 22);
        invalidateCachedCalculationsOnRefreshCheckBox.TabIndex = 4;
        invalidateCachedCalculationsOnRefreshCheckBox.Text = "invalidate cached calculations on refresh";
        invalidateCachedCalculationsOnRefreshCheckBox.UseVisualStyleBackColor = true;
        invalidateCachedCalculationsOnRefreshCheckBox.CheckedChanged += invalidateCachedCalculationsOnRefreshCheckBox_CheckedChanged;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        label1.AutoSize = true;
        label1.Font = new Font("Aptos Display", 10F);
        label1.ForeColor = Color.FromArgb(218, 192, 192);
        label1.Location = new Point(121, 169);
        label1.Margin = new Padding(3, 6, 3, 6);
        label1.Name = "label1";
        label1.Size = new Size(282, 54);
        label1.TabIndex = 6;
        label1.Text = "settings tinted with red are subject to significantly\r\nreduce performance of the application\r\nand must be used with consideration";
        label1.TextAlign = ContentAlignment.BottomRight;
        // 
        // analyzeBeatmapSetOnSelection
        // 
        analyzeBeatmapSetOnSelection.AutoSize = true;
        analyzeBeatmapSetOnSelection.Font = new Font("Aptos Display", 10F);
        analyzeBeatmapSetOnSelection.ForeColor = SystemColors.ControlLight;
        analyzeBeatmapSetOnSelection.Location = new Point(15, 46);
        analyzeBeatmapSetOnSelection.Margin = new Padding(12, 0, 6, 3);
        analyzeBeatmapSetOnSelection.Name = "analyzeBeatmapSetOnSelection";
        analyzeBeatmapSetOnSelection.Size = new Size(214, 22);
        analyzeBeatmapSetOnSelection.TabIndex = 3;
        analyzeBeatmapSetOnSelection.Text = "analyze beatmap set on selection";
        analyzeBeatmapSetOnSelection.UseVisualStyleBackColor = true;
        analyzeBeatmapSetOnSelection.CheckedChanged += analyzeBeatmapSetOnSelection_CheckedChanged;
        // 
        // analyzeSingleBeatmapOnSelectionCheckBox
        // 
        analyzeSingleBeatmapOnSelectionCheckBox.AutoSize = true;
        analyzeSingleBeatmapOnSelectionCheckBox.Font = new Font("Aptos Display", 10F);
        analyzeSingleBeatmapOnSelectionCheckBox.ForeColor = SystemColors.ControlLight;
        analyzeSingleBeatmapOnSelectionCheckBox.Location = new Point(15, 21);
        analyzeSingleBeatmapOnSelectionCheckBox.Margin = new Padding(12, 0, 6, 3);
        analyzeSingleBeatmapOnSelectionCheckBox.Name = "analyzeSingleBeatmapOnSelectionCheckBox";
        analyzeSingleBeatmapOnSelectionCheckBox.Size = new Size(229, 22);
        analyzeSingleBeatmapOnSelectionCheckBox.TabIndex = 2;
        analyzeSingleBeatmapOnSelectionCheckBox.Text = "analyze single beatmap on selection";
        analyzeSingleBeatmapOnSelectionCheckBox.UseVisualStyleBackColor = true;
        analyzeSingleBeatmapOnSelectionCheckBox.CheckedChanged += analyzeSingleBeatmapOnSelectionCheckBox_CheckedChanged;
        // 
        // analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox
        // 
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.AutoSize = true;
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.Font = new Font("Aptos Display", 10F);
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.ForeColor = Color.FromArgb(218, 192, 192);
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.Location = new Point(15, 133);
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.Margin = new Padding(12, 0, 6, 3);
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.Name = "analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox";
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.Size = new Size(310, 22);
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.TabIndex = 1;
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.Text = "analyze all beatmaps upon refreshing the database";
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.TextAlign = ContentAlignment.MiddleCenter;
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.UseVisualStyleBackColor = true;
        analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox.CheckedChanged += analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox_CheckedChanged;
        // 
        // analyzeAllBeatmapsOnStartupCheckBox
        // 
        analyzeAllBeatmapsOnStartupCheckBox.AutoSize = true;
        analyzeAllBeatmapsOnStartupCheckBox.Font = new Font("Aptos Display", 10F);
        analyzeAllBeatmapsOnStartupCheckBox.ForeColor = Color.FromArgb(218, 192, 192);
        analyzeAllBeatmapsOnStartupCheckBox.Location = new Point(15, 108);
        analyzeAllBeatmapsOnStartupCheckBox.Margin = new Padding(12, 0, 6, 3);
        analyzeAllBeatmapsOnStartupCheckBox.Name = "analyzeAllBeatmapsOnStartupCheckBox";
        analyzeAllBeatmapsOnStartupCheckBox.Size = new Size(204, 22);
        analyzeAllBeatmapsOnStartupCheckBox.TabIndex = 0;
        analyzeAllBeatmapsOnStartupCheckBox.Text = "analyze all beatmaps on startup";
        analyzeAllBeatmapsOnStartupCheckBox.UseVisualStyleBackColor = true;
        analyzeAllBeatmapsOnStartupCheckBox.CheckedChanged += analyzeAllBeatmapsOnStartupCheckBox_CheckedChanged;
        // 
        // SettingsForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(30, 30, 30);
        ClientSize = new Size(433, 551);
        Controls.Add(contentPanel);
        Font = new Font("Aptos Display", 10F);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "SettingsForm";
        Text = "settings";
        contentPanel.ResumeLayout(false);
        pathsGroupBox.ResumeLayout(false);
        pathsGroupBox.PerformLayout();
        generalGroupBox.ResumeLayout(false);
        generalGroupBox.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitter1).EndInit();
        ((System.ComponentModel.ISupportInitialize)splitter2).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel contentPanel;
    private GroupBox generalGroupBox;
    private Label label1;
    private CheckBox analyzeAllBeatmapsUponRefreshingTheDatabaseCheckBox;
    private CheckBox analyzeAllBeatmapsOnStartupCheckBox;
    private CheckBox invalidateCachedCalculationsOnRefreshCheckBox;
    private CheckBox analyzeBeatmapSetOnSelection;
    private CheckBox analyzeSingleBeatmapOnSelectionCheckBox;
    private GroupBox pathsGroupBox;
    private PictureBox splitter1;
    private PictureBox splitter2;
    private Label label3;
    private Label label2;
    private TextBox baseOsuDirectoryTextBox;
    private Label label4;
    private TextBox beatmapDirectoryTextBox;
    private Button resetButton;
    private Button saveButton;
    private Button openSettingsFileButton;
}