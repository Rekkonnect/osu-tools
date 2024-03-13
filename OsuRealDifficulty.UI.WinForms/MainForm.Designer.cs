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
        var listViewItem1 = new ListViewItem(new string[] { "Sakazuki", "BEMANI Sound Team HuMeR feat Fernweh", "Nicknem_" }, -1);
        var listViewItem2 = new ListViewItem(new string[] { "SAtAN", "P*Light", "riunosk" }, -1);
        var listViewItem3 = new ListViewItem(new string[] { "Aruel's HEAVENLY", "4", "8.8", "8.8", "1870", "1664", "206" }, -1);
        var listViewItem4 = new ListViewItem(new string[] { "Ayase's EXHAUST", "4", "8", "8", "1162", "930", "232" }, -1);
        var listViewItem5 = new ListViewItem("DenYi's ADVANCED");
        var listViewItem6 = new ListViewItem("NOVICE");
        var listViewItem7 = new ListViewItem("Ppass' MAXIMUM");
        var listViewItem8 = new ListViewItem("REVERSED");
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        difficultyResultDisplay = new AnalysisResultDisplay();
        beatmapGroupBox = new GroupBox();
        filterGroupBox = new GroupBox();
        tagsFilterCheckBox = new CheckBox();
        sourceFilterCheckBox = new CheckBox();
        resetButton = new Button();
        difficultyFilterCheckBox = new CheckBox();
        mapperFilterCheckBox = new CheckBox();
        artistFilterCheckBox = new CheckBox();
        titleFilterCheckBox = new CheckBox();
        searchTextBox = new TextBox();
        keyCountFilterTextBox = new KeyCountFilterTextBox();
        keyCountFilterCheckBox = new CheckBox();
        beatmapSetListView = new BeatmapSetListView();
        beatmapListViewTitleColumn = new ColumnHeader();
        beatmapListViewArtistColumn = new ColumnHeader();
        beatmapListViewMapperColumn = new ColumnHeader();
        operationsGroupBox = new GroupBox();
        showLogsButton = new Button();
        reloadBeatmapDatabaseButton = new Button();
        settingsButton = new Button();
        cancelCalculationButton = new Button();
        beginCalculationButton = new Button();
        difficultyListView = new BeatmapListView();
        columnHeader1 = new ColumnHeader();
        columnHeader2 = new ColumnHeader();
        columnHeader3 = new ColumnHeader();
        columnHeader4 = new ColumnHeader();
        columnHeader5 = new ColumnHeader();
        columnHeader6 = new ColumnHeader();
        columnHeader7 = new ColumnHeader();
        beatmapGroupBox.SuspendLayout();
        filterGroupBox.SuspendLayout();
        operationsGroupBox.SuspendLayout();
        SuspendLayout();
        // 
        // difficultyResultDisplay
        // 
        difficultyResultDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        difficultyResultDisplay.BackColor = Color.FromArgb(30, 30, 30);
        difficultyResultDisplay.Caption = "difficulty";
        difficultyResultDisplay.Font = new Font("Aptos Display", 10F);
        difficultyResultDisplay.ForeColor = SystemColors.ControlLight;
        difficultyResultDisplay.Location = new Point(538, 190);
        difficultyResultDisplay.Name = "difficultyResultDisplay";
        difficultyResultDisplay.Size = new Size(368, 450);
        difficultyResultDisplay.TabIndex = 0;
        // 
        // beatmapGroupBox
        // 
        beatmapGroupBox.Controls.Add(filterGroupBox);
        beatmapGroupBox.Controls.Add(beatmapSetListView);
        beatmapGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        beatmapGroupBox.ForeColor = Color.Silver;
        beatmapGroupBox.Location = new Point(12, 12);
        beatmapGroupBox.Name = "beatmapGroupBox";
        beatmapGroupBox.Size = new Size(520, 628);
        beatmapGroupBox.TabIndex = 1;
        beatmapGroupBox.TabStop = false;
        beatmapGroupBox.Text = "beatmap";
        // 
        // filterGroupBox
        // 
        filterGroupBox.Controls.Add(tagsFilterCheckBox);
        filterGroupBox.Controls.Add(sourceFilterCheckBox);
        filterGroupBox.Controls.Add(resetButton);
        filterGroupBox.Controls.Add(difficultyFilterCheckBox);
        filterGroupBox.Controls.Add(mapperFilterCheckBox);
        filterGroupBox.Controls.Add(artistFilterCheckBox);
        filterGroupBox.Controls.Add(titleFilterCheckBox);
        filterGroupBox.Controls.Add(searchTextBox);
        filterGroupBox.Controls.Add(keyCountFilterTextBox);
        filterGroupBox.Controls.Add(keyCountFilterCheckBox);
        filterGroupBox.ForeColor = Color.Silver;
        filterGroupBox.Location = new Point(6, 24);
        filterGroupBox.Name = "filterGroupBox";
        filterGroupBox.Size = new Size(508, 116);
        filterGroupBox.TabIndex = 4;
        filterGroupBox.TabStop = false;
        filterGroupBox.Text = "filter";
        // 
        // tagsFilterCheckBox
        // 
        tagsFilterCheckBox.AutoSize = true;
        tagsFilterCheckBox.Checked = true;
        tagsFilterCheckBox.CheckState = CheckState.Checked;
        tagsFilterCheckBox.Font = new Font("Aptos Display", 10F);
        tagsFilterCheckBox.ForeColor = SystemColors.ControlLight;
        tagsFilterCheckBox.Location = new Point(87, 62);
        tagsFilterCheckBox.Name = "tagsFilterCheckBox";
        tagsFilterCheckBox.Size = new Size(50, 22);
        tagsFilterCheckBox.TabIndex = 6;
        tagsFilterCheckBox.Text = "tags";
        tagsFilterCheckBox.UseVisualStyleBackColor = true;
        tagsFilterCheckBox.CheckedChanged += tagsFilterCheckBox_CheckedChanged;
        // 
        // sourceFilterCheckBox
        // 
        sourceFilterCheckBox.AutoSize = true;
        sourceFilterCheckBox.Checked = true;
        sourceFilterCheckBox.CheckState = CheckState.Checked;
        sourceFilterCheckBox.Font = new Font("Aptos Display", 10F);
        sourceFilterCheckBox.ForeColor = SystemColors.ControlLight;
        sourceFilterCheckBox.Location = new Point(87, 43);
        sourceFilterCheckBox.Name = "sourceFilterCheckBox";
        sourceFilterCheckBox.Size = new Size(65, 22);
        sourceFilterCheckBox.TabIndex = 5;
        sourceFilterCheckBox.Text = "source";
        sourceFilterCheckBox.UseVisualStyleBackColor = true;
        sourceFilterCheckBox.CheckedChanged += sourceFilterCheckBox_CheckedChanged;
        // 
        // resetButton
        // 
        resetButton.BackColor = Color.FromArgb(40, 40, 40);
        resetButton.FlatAppearance.BorderColor = Color.Silver;
        resetButton.FlatAppearance.MouseDownBackColor = Color.Gray;
        resetButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 72, 72);
        resetButton.FlatStyle = FlatStyle.Flat;
        resetButton.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        resetButton.Location = new Point(439, 55);
        resetButton.Name = "resetButton";
        resetButton.Size = new Size(63, 30);
        resetButton.TabIndex = 9;
        resetButton.Text = "reset";
        resetButton.UseVisualStyleBackColor = false;
        resetButton.Click += resetButton_Click;
        // 
        // difficultyFilterCheckBox
        // 
        difficultyFilterCheckBox.AutoSize = true;
        difficultyFilterCheckBox.Checked = true;
        difficultyFilterCheckBox.CheckState = CheckState.Checked;
        difficultyFilterCheckBox.Font = new Font("Aptos Display", 10F);
        difficultyFilterCheckBox.ForeColor = SystemColors.ControlLight;
        difficultyFilterCheckBox.Location = new Point(87, 24);
        difficultyFilterCheckBox.Name = "difficultyFilterCheckBox";
        difficultyFilterCheckBox.Size = new Size(75, 22);
        difficultyFilterCheckBox.TabIndex = 4;
        difficultyFilterCheckBox.Text = "difficulty";
        difficultyFilterCheckBox.UseVisualStyleBackColor = true;
        difficultyFilterCheckBox.CheckedChanged += difficultyFilterCheckBox_CheckedChanged;
        // 
        // mapperFilterCheckBox
        // 
        mapperFilterCheckBox.AutoSize = true;
        mapperFilterCheckBox.Checked = true;
        mapperFilterCheckBox.CheckState = CheckState.Checked;
        mapperFilterCheckBox.Font = new Font("Aptos Display", 10F);
        mapperFilterCheckBox.ForeColor = SystemColors.ControlLight;
        mapperFilterCheckBox.Location = new Point(6, 62);
        mapperFilterCheckBox.Name = "mapperFilterCheckBox";
        mapperFilterCheckBox.Size = new Size(70, 22);
        mapperFilterCheckBox.TabIndex = 3;
        mapperFilterCheckBox.Text = "mapper";
        mapperFilterCheckBox.UseVisualStyleBackColor = true;
        mapperFilterCheckBox.CheckedChanged += mapperFilterCheckBox_CheckedChanged;
        // 
        // artistFilterCheckBox
        // 
        artistFilterCheckBox.AutoSize = true;
        artistFilterCheckBox.Checked = true;
        artistFilterCheckBox.CheckState = CheckState.Checked;
        artistFilterCheckBox.Font = new Font("Aptos Display", 10F);
        artistFilterCheckBox.ForeColor = SystemColors.ControlLight;
        artistFilterCheckBox.Location = new Point(6, 43);
        artistFilterCheckBox.Name = "artistFilterCheckBox";
        artistFilterCheckBox.Size = new Size(55, 22);
        artistFilterCheckBox.TabIndex = 2;
        artistFilterCheckBox.Text = "artist";
        artistFilterCheckBox.UseVisualStyleBackColor = true;
        artistFilterCheckBox.CheckedChanged += artistFilterCheckBox_CheckedChanged;
        // 
        // titleFilterCheckBox
        // 
        titleFilterCheckBox.AutoSize = true;
        titleFilterCheckBox.Checked = true;
        titleFilterCheckBox.CheckState = CheckState.Checked;
        titleFilterCheckBox.Font = new Font("Aptos Display", 10F);
        titleFilterCheckBox.ForeColor = SystemColors.ControlLight;
        titleFilterCheckBox.Location = new Point(6, 24);
        titleFilterCheckBox.Name = "titleFilterCheckBox";
        titleFilterCheckBox.Size = new Size(48, 22);
        titleFilterCheckBox.TabIndex = 1;
        titleFilterCheckBox.Text = "title";
        titleFilterCheckBox.UseVisualStyleBackColor = true;
        titleFilterCheckBox.CheckedChanged += titleFilterCheckBox_CheckedChanged;
        // 
        // searchTextBox
        // 
        searchTextBox.BackColor = Color.FromArgb(40, 40, 40);
        searchTextBox.Font = new Font("Aptos Display", 11F);
        searchTextBox.ForeColor = SystemColors.ControlLight;
        searchTextBox.Location = new Point(168, 24);
        searchTextBox.Name = "searchTextBox";
        searchTextBox.PlaceholderText = "type to search";
        searchTextBox.Size = new Size(334, 25);
        searchTextBox.TabIndex = 0;
        searchTextBox.TextChanged += searchTextBox_TextChanged;
        // 
        // keyCountFilterTextBox
        // 
        keyCountFilterTextBox.BackColor = Color.FromArgb(40, 40, 40);
        keyCountFilterTextBox.Enabled = false;
        keyCountFilterTextBox.ForeColor = SystemColors.ControlLight;
        keyCountFilterTextBox.Location = new Point(252, 60);
        keyCountFilterTextBox.MaxLength = 1;
        keyCountFilterTextBox.Name = "keyCountFilterTextBox";
        keyCountFilterTextBox.Size = new Size(30, 25);
        keyCountFilterTextBox.TabIndex = 8;
        keyCountFilterTextBox.Text = "4";
        keyCountFilterTextBox.TextAlign = HorizontalAlignment.Center;
        keyCountFilterTextBox.TextChanged += keyCountFilterTextBox_TextChanged;
        // 
        // keyCountFilterCheckBox
        // 
        keyCountFilterCheckBox.AutoSize = true;
        keyCountFilterCheckBox.Font = new Font("Aptos Display", 10F);
        keyCountFilterCheckBox.ForeColor = SystemColors.ControlLight;
        keyCountFilterCheckBox.Location = new Point(168, 62);
        keyCountFilterCheckBox.Name = "keyCountFilterCheckBox";
        keyCountFilterCheckBox.Size = new Size(81, 22);
        keyCountFilterCheckBox.TabIndex = 7;
        keyCountFilterCheckBox.Text = "key count";
        keyCountFilterCheckBox.UseVisualStyleBackColor = true;
        keyCountFilterCheckBox.CheckedChanged += keyCountFilterCheckBox_CheckedChanged;
        // 
        // beatmapSetListView
        // 
        beatmapSetListView.BackColor = Color.FromArgb(40, 40, 40);
        beatmapSetListView.Columns.AddRange(new ColumnHeader[] { beatmapListViewTitleColumn, beatmapListViewArtistColumn, beatmapListViewMapperColumn });
        beatmapSetListView.Font = new Font("Aptos Display", 11F);
        beatmapSetListView.ForeColor = SystemColors.ControlLight;
        beatmapSetListView.FullRowSelect = true;
        beatmapSetListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
        listViewItem1.StateImageIndex = 0;
        listViewItem2.StateImageIndex = 0;
        beatmapSetListView.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
        beatmapSetListView.Location = new Point(6, 146);
        beatmapSetListView.Name = "beatmapSetListView";
        beatmapSetListView.ShowItemToolTips = true;
        beatmapSetListView.Size = new Size(508, 286);
        beatmapSetListView.Sorting = SortOrder.Ascending;
        beatmapSetListView.TabIndex = 20;
        beatmapSetListView.UseCompatibleStateImageBehavior = false;
        beatmapSetListView.View = View.Details;
        beatmapSetListView.SelectedIndexChanged += beatmapSetListView_SelectedIndexChanged;
        // 
        // beatmapListViewTitleColumn
        // 
        beatmapListViewTitleColumn.Text = "title";
        beatmapListViewTitleColumn.Width = 200;
        // 
        // beatmapListViewArtistColumn
        // 
        beatmapListViewArtistColumn.Text = "artist";
        beatmapListViewArtistColumn.Width = 150;
        // 
        // beatmapListViewMapperColumn
        // 
        beatmapListViewMapperColumn.Text = "mapper";
        beatmapListViewMapperColumn.Width = 120;
        // 
        // operationsGroupBox
        // 
        operationsGroupBox.Controls.Add(showLogsButton);
        operationsGroupBox.Controls.Add(reloadBeatmapDatabaseButton);
        operationsGroupBox.Controls.Add(settingsButton);
        operationsGroupBox.Controls.Add(cancelCalculationButton);
        operationsGroupBox.Controls.Add(beginCalculationButton);
        operationsGroupBox.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        operationsGroupBox.ForeColor = Color.Silver;
        operationsGroupBox.Location = new Point(538, 12);
        operationsGroupBox.Name = "operationsGroupBox";
        operationsGroupBox.Size = new Size(368, 172);
        operationsGroupBox.TabIndex = 5;
        operationsGroupBox.TabStop = false;
        operationsGroupBox.Text = "operations";
        // 
        // showLogsButton
        // 
        showLogsButton.BackColor = Color.FromArgb(40, 40, 40);
        showLogsButton.FlatAppearance.BorderColor = Color.Silver;
        showLogsButton.FlatAppearance.MouseDownBackColor = Color.Gray;
        showLogsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 72, 72);
        showLogsButton.FlatStyle = FlatStyle.Flat;
        showLogsButton.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        showLogsButton.ForeColor = Color.FromArgb(192, 192, 218);
        showLogsButton.Location = new Point(6, 94);
        showLogsButton.Name = "showLogsButton";
        showLogsButton.Size = new Size(128, 46);
        showLogsButton.TabIndex = 42;
        showLogsButton.Text = "show logs";
        showLogsButton.UseVisualStyleBackColor = false;
        showLogsButton.Click += showLogsButton_Click;
        // 
        // reloadBeatmapDatabaseButton
        // 
        reloadBeatmapDatabaseButton.BackColor = Color.FromArgb(40, 40, 40);
        reloadBeatmapDatabaseButton.FlatAppearance.BorderColor = Color.Silver;
        reloadBeatmapDatabaseButton.FlatAppearance.MouseDownBackColor = Color.Gray;
        reloadBeatmapDatabaseButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 72, 72);
        reloadBeatmapDatabaseButton.FlatStyle = FlatStyle.Flat;
        reloadBeatmapDatabaseButton.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        reloadBeatmapDatabaseButton.ForeColor = Color.FromArgb(218, 218, 192);
        reloadBeatmapDatabaseButton.Location = new Point(234, 76);
        reloadBeatmapDatabaseButton.Name = "reloadBeatmapDatabaseButton";
        reloadBeatmapDatabaseButton.Size = new Size(128, 64);
        reloadBeatmapDatabaseButton.TabIndex = 44;
        reloadBeatmapDatabaseButton.Text = "reload beatmap database";
        reloadBeatmapDatabaseButton.UseVisualStyleBackColor = false;
        reloadBeatmapDatabaseButton.Click += reloadBeatmapDatabaseButton_Click;
        // 
        // settingsButton
        // 
        settingsButton.BackColor = Color.FromArgb(40, 40, 40);
        settingsButton.FlatAppearance.BorderColor = Color.Silver;
        settingsButton.FlatAppearance.MouseDownBackColor = Color.Gray;
        settingsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 72, 72);
        settingsButton.FlatStyle = FlatStyle.Flat;
        settingsButton.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        settingsButton.ForeColor = Color.FromArgb(192, 192, 218);
        settingsButton.Location = new Point(234, 24);
        settingsButton.Name = "settingsButton";
        settingsButton.Size = new Size(128, 46);
        settingsButton.TabIndex = 43;
        settingsButton.Text = "settings";
        settingsButton.UseVisualStyleBackColor = false;
        settingsButton.Click += settingsButton_Click;
        // 
        // cancelCalculationButton
        // 
        cancelCalculationButton.BackColor = Color.FromArgb(40, 40, 40);
        cancelCalculationButton.Enabled = false;
        cancelCalculationButton.FlatAppearance.BorderColor = Color.Silver;
        cancelCalculationButton.FlatAppearance.MouseDownBackColor = Color.Gray;
        cancelCalculationButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 72, 72);
        cancelCalculationButton.FlatStyle = FlatStyle.Flat;
        cancelCalculationButton.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        cancelCalculationButton.ForeColor = Color.FromArgb(218, 192, 192);
        cancelCalculationButton.Location = new Point(110, 24);
        cancelCalculationButton.Name = "cancelCalculationButton";
        cancelCalculationButton.Size = new Size(98, 55);
        cancelCalculationButton.TabIndex = 41;
        cancelCalculationButton.Text = "cancel calculation";
        cancelCalculationButton.UseVisualStyleBackColor = false;
        cancelCalculationButton.Click += cancelCalculationButton_Click;
        // 
        // beginCalculationButton
        // 
        beginCalculationButton.BackColor = Color.FromArgb(40, 40, 40);
        beginCalculationButton.FlatAppearance.BorderColor = Color.Silver;
        beginCalculationButton.FlatAppearance.MouseDownBackColor = Color.Gray;
        beginCalculationButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 72, 72);
        beginCalculationButton.FlatStyle = FlatStyle.Flat;
        beginCalculationButton.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        beginCalculationButton.ForeColor = Color.FromArgb(192, 218, 192);
        beginCalculationButton.Location = new Point(6, 24);
        beginCalculationButton.Name = "beginCalculationButton";
        beginCalculationButton.Size = new Size(98, 55);
        beginCalculationButton.TabIndex = 40;
        beginCalculationButton.Text = "begin calculation";
        beginCalculationButton.UseVisualStyleBackColor = false;
        beginCalculationButton.Click += beginCalculationButton_Click;
        // 
        // difficultyListView
        // 
        difficultyListView.BackColor = Color.FromArgb(40, 40, 40);
        difficultyListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
        difficultyListView.Font = new Font("Aptos Display", 11F);
        difficultyListView.ForeColor = SystemColors.ControlLight;
        difficultyListView.FullRowSelect = true;
        difficultyListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
        listViewItem3.StateImageIndex = 0;
        listViewItem4.StateImageIndex = 0;
        difficultyListView.Items.AddRange(new ListViewItem[] { listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8 });
        difficultyListView.Location = new Point(18, 450);
        difficultyListView.Name = "difficultyListView";
        difficultyListView.ShowItemToolTips = true;
        difficultyListView.Size = new Size(508, 184);
        difficultyListView.Sorting = SortOrder.Ascending;
        difficultyListView.TabIndex = 30;
        difficultyListView.UseCompatibleStateImageBehavior = false;
        difficultyListView.View = View.Details;
        difficultyListView.SelectedIndexChanged += difficultyListView_SelectedIndexChanged;
        // 
        // columnHeader1
        // 
        columnHeader1.Text = "difficulty name";
        columnHeader1.Width = 175;
        // 
        // columnHeader2
        // 
        columnHeader2.Text = "keys";
        columnHeader2.TextAlign = HorizontalAlignment.Center;
        columnHeader2.Width = 50;
        // 
        // columnHeader3
        // 
        columnHeader3.Text = "hp";
        columnHeader3.TextAlign = HorizontalAlignment.Center;
        columnHeader3.Width = 35;
        // 
        // columnHeader4
        // 
        columnHeader4.Text = "od";
        columnHeader4.TextAlign = HorizontalAlignment.Center;
        columnHeader4.Width = 35;
        // 
        // columnHeader5
        // 
        columnHeader5.Text = "objects";
        columnHeader5.TextAlign = HorizontalAlignment.Center;
        // 
        // columnHeader6
        // 
        columnHeader6.Text = "rice";
        columnHeader6.TextAlign = HorizontalAlignment.Center;
        // 
        // columnHeader7
        // 
        columnHeader7.Text = "holds";
        columnHeader7.TextAlign = HorizontalAlignment.Center;
        // 
        // MainForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(30, 30, 30);
        ClientSize = new Size(918, 652);
        Controls.Add(difficultyListView);
        Controls.Add(operationsGroupBox);
        Controls.Add(beatmapGroupBox);
        Controls.Add(difficultyResultDisplay);
        DoubleBuffered = true;
        Font = new Font("Aptos Display", 10F);
        ForeColor = SystemColors.ControlLight;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4, 3, 4, 3);
        MaximizeBox = false;
        Name = "MainForm";
        Text = "osu!mania difficulty analyzer";
        Load += MainForm_Load;
        Shown += MainForm_Shown;
        beatmapGroupBox.ResumeLayout(false);
        filterGroupBox.ResumeLayout(false);
        filterGroupBox.PerformLayout();
        operationsGroupBox.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private AnalysisResultDisplay difficultyResultDisplay;
    private GroupBox beatmapGroupBox;
    private BeatmapSetListView beatmapSetListView;
    private ColumnHeader beatmapListViewTitleColumn;
    private ColumnHeader beatmapListViewArtistColumn;
    private ColumnHeader beatmapListViewMapperColumn;
    private TextBox searchTextBox;
    private KeyCountFilterTextBox keyCountFilterTextBox;
    private CheckBox keyCountFilterCheckBox;
    private GroupBox filterGroupBox;
    private CheckBox difficultyFilterCheckBox;
    private CheckBox mapperFilterCheckBox;
    private CheckBox artistFilterCheckBox;
    private CheckBox titleFilterCheckBox;
    private Button resetButton;
    private GroupBox operationsGroupBox;
    private BeatmapListView difficultyListView;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader6;
    private ColumnHeader columnHeader7;
    private Button reloadBeatmapDatabaseButton;
    private Button settingsButton;
    private Button cancelCalculationButton;
    private Button beginCalculationButton;
    private Button showLogsButton;
    private CheckBox tagsFilterCheckBox;
    private CheckBox sourceFilterCheckBox;
}
