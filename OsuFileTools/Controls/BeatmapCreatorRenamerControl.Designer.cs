namespace OsuFileTools.Controls;

partial class BeatmapCreatorRenamerControl
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
        groupBox1 = new GroupBox();
        totalCountLabel = new Label();
        skippedCountLabel = new Label();
        updatedCountLabel = new Label();
        label4 = new Label();
        label3 = new Label();
        label2 = new Label();
        progressBar = new ProgressBar();
        renameButton = new Button();
        groupBox4 = new GroupBox();
        browseDirectoryButton = new Button();
        beatmapsDirectoryText = new TextBox();
        label5 = new Label();
        generateBackupsCheck = new CheckBox();
        newValueText = new TextBox();
        label1 = new Label();
        oldValueText = new TextBox();
        label6 = new Label();
        groupBox3.SuspendLayout();
        groupBox1.SuspendLayout();
        groupBox4.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(groupBox1);
        groupBox3.Controls.Add(renameButton);
        groupBox3.Controls.Add(groupBox4);
        groupBox3.Location = new Point(0, 0);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(340, 592);
        groupBox3.TabIndex = 10;
        groupBox3.TabStop = false;
        groupBox3.Text = "Operation";
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(totalCountLabel);
        groupBox1.Controls.Add(skippedCountLabel);
        groupBox1.Controls.Add(updatedCountLabel);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(progressBar);
        groupBox1.Location = new Point(6, 284);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(328, 106);
        groupBox1.TabIndex = 11;
        groupBox1.TabStop = false;
        groupBox1.Text = "Progress";
        // 
        // totalCountLabel
        // 
        totalCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        totalCountLabel.Location = new Point(6, 49);
        totalCountLabel.Name = "totalCountLabel";
        totalCountLabel.Size = new Size(146, 15);
        totalCountLabel.TabIndex = 6;
        totalCountLabel.Text = "0 / 0";
        totalCountLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // skippedCountLabel
        // 
        skippedCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        skippedCountLabel.Location = new Point(6, 34);
        skippedCountLabel.Name = "skippedCountLabel";
        skippedCountLabel.Size = new Size(146, 15);
        skippedCountLabel.TabIndex = 5;
        skippedCountLabel.Text = "0";
        skippedCountLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // updatedCountLabel
        // 
        updatedCountLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        updatedCountLabel.Location = new Point(6, 19);
        updatedCountLabel.Name = "updatedCountLabel";
        updatedCountLabel.Size = new Size(146, 15);
        updatedCountLabel.TabIndex = 4;
        updatedCountLabel.Text = "0";
        updatedCountLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(155, 49);
        label4.Name = "label4";
        label4.Size = new Size(32, 15);
        label4.TabIndex = 3;
        label4.Text = "Total";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(155, 34);
        label3.Name = "label3";
        label3.Size = new Size(49, 15);
        label3.TabIndex = 2;
        label3.Text = "Skipped";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(155, 19);
        label2.Name = "label2";
        label2.Size = new Size(52, 15);
        label2.TabIndex = 1;
        label2.Text = "Updated";
        // 
        // progressBar
        // 
        progressBar.Location = new Point(6, 77);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(316, 23);
        progressBar.TabIndex = 0;
        // 
        // renameButton
        // 
        renameButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        renameButton.Location = new Point(5, 249);
        renameButton.Name = "renameButton";
        renameButton.Size = new Size(330, 29);
        renameButton.TabIndex = 10;
        renameButton.Text = "Rename All Beatmaps' Creator";
        renameButton.UseVisualStyleBackColor = true;
        renameButton.Click += renameButton_Click;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(browseDirectoryButton);
        groupBox4.Controls.Add(beatmapsDirectoryText);
        groupBox4.Controls.Add(label5);
        groupBox4.Controls.Add(generateBackupsCheck);
        groupBox4.Controls.Add(newValueText);
        groupBox4.Controls.Add(label1);
        groupBox4.Controls.Add(oldValueText);
        groupBox4.Controls.Add(label6);
        groupBox4.Location = new Point(6, 22);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(328, 201);
        groupBox4.TabIndex = 0;
        groupBox4.TabStop = false;
        groupBox4.Text = "Options";
        // 
        // browseDirectoryButton
        // 
        browseDirectoryButton.Location = new Point(169, 16);
        browseDirectoryButton.Name = "browseDirectoryButton";
        browseDirectoryButton.Size = new Size(75, 23);
        browseDirectoryButton.TabIndex = 15;
        browseDirectoryButton.Text = "Browse";
        browseDirectoryButton.UseVisualStyleBackColor = true;
        browseDirectoryButton.Click += browseDirectoryButton_Click;
        // 
        // beatmapsDirectoryText
        // 
        beatmapsDirectoryText.Location = new Point(8, 42);
        beatmapsDirectoryText.Name = "beatmapsDirectoryText";
        beatmapsDirectoryText.Size = new Size(314, 23);
        beatmapsDirectoryText.TabIndex = 14;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(54, 19);
        label5.Name = "label5";
        label5.Size = new Size(109, 15);
        label5.TabIndex = 13;
        label5.Text = "Beatmaps directory";
        // 
        // generateBackupsCheck
        // 
        generateBackupsCheck.AutoSize = true;
        generateBackupsCheck.Location = new Point(8, 173);
        generateBackupsCheck.Name = "generateBackupsCheck";
        generateBackupsCheck.Size = new Size(314, 19);
        generateBackupsCheck.TabIndex = 12;
        generateBackupsCheck.Text = "Generate backups for beatmaps with renamed creators";
        generateBackupsCheck.UseVisualStyleBackColor = true;
        // 
        // newValueText
        // 
        newValueText.Location = new Point(139, 123);
        newValueText.Name = "newValueText";
        newValueText.Size = new Size(183, 23);
        newValueText.TabIndex = 11;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(29, 126);
        label1.Name = "label1";
        label1.Size = new Size(104, 15);
        label1.TabIndex = 10;
        label1.Text = "New creator name";
        // 
        // oldValueText
        // 
        oldValueText.Location = new Point(139, 94);
        oldValueText.Name = "oldValueText";
        oldValueText.Size = new Size(183, 23);
        oldValueText.TabIndex = 9;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(34, 97);
        label6.Name = "label6";
        label6.Size = new Size(99, 15);
        label6.TabIndex = 8;
        label6.Text = "Old creator name";
        // 
        // BeatmapCreatorRenamerControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(groupBox3);
        Name = "BeatmapCreatorRenamerControl";
        Size = new Size(341, 592);
        groupBox3.ResumeLayout(false);
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox3;
    private Button renameButton;
    private GroupBox groupBox4;
    private Label label6;
    private GroupBox groupBox1;
    private Label updatedCountLabel;
    private Label label4;
    private Label label3;
    private Label label2;
    private ProgressBar progressBar;
    private CheckBox generateBackupsCheck;
    private TextBox newValueText;
    private Label label1;
    private TextBox oldValueText;
    private Label totalCountLabel;
    private Label skippedCountLabel;
    private Button browseDirectoryButton;
    private TextBox beatmapsDirectoryText;
    private Label label5;
}
