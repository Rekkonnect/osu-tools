namespace OsuRealDifficulty.UI.WinForms;

partial class LogViewForm
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
        label1 = new Label();
        openLogFolderButton = new Button();
        contentTextBox = new TextBox();
        contentPanel.SuspendLayout();
        SuspendLayout();
        // 
        // contentPanel
        // 
        contentPanel.Controls.Add(label1);
        contentPanel.Controls.Add(openLogFolderButton);
        contentPanel.Controls.Add(contentTextBox);
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Location = new Point(0, 0);
        contentPanel.Name = "contentPanel";
        contentPanel.Padding = new Padding(3);
        contentPanel.Size = new Size(800, 288);
        contentPanel.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.ForeColor = Color.Silver;
        label1.Location = new Point(188, 242);
        label1.Name = "label1";
        label1.Size = new Size(425, 36);
        label1.TabIndex = 46;
        label1.Text = "keeping the logs view open may cause frequent stutters,\r\nmake sure to close this view before performing database-wide calculations";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // openLogFolderButton
        // 
        openLogFolderButton.BackColor = Color.FromArgb(40, 40, 40);
        openLogFolderButton.FlatAppearance.BorderColor = Color.Silver;
        openLogFolderButton.FlatAppearance.MouseDownBackColor = Color.Gray;
        openLogFolderButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 72, 72);
        openLogFolderButton.FlatStyle = FlatStyle.Flat;
        openLogFolderButton.Font = new Font("Aptos Display", 11F, FontStyle.Bold);
        openLogFolderButton.ForeColor = Color.FromArgb(192, 192, 218);
        openLogFolderButton.Location = new Point(6, 242);
        openLogFolderButton.Name = "openLogFolderButton";
        openLogFolderButton.Size = new Size(151, 40);
        openLogFolderButton.TabIndex = 45;
        openLogFolderButton.Text = "open log folder";
        openLogFolderButton.UseVisualStyleBackColor = false;
        openLogFolderButton.Click += openLogFolderButton_Click;
        // 
        // contentTextBox
        // 
        contentTextBox.BackColor = Color.FromArgb(40, 40, 40);
        contentTextBox.Dock = DockStyle.Top;
        contentTextBox.Font = new Font("Consolas", 9F);
        contentTextBox.ForeColor = SystemColors.ControlLight;
        contentTextBox.Location = new Point(3, 3);
        contentTextBox.MaxLength = 99999999;
        contentTextBox.Multiline = true;
        contentTextBox.Name = "contentTextBox";
        contentTextBox.PlaceholderText = "nothing noteworthy here";
        contentTextBox.ReadOnly = true;
        contentTextBox.ScrollBars = ScrollBars.Vertical;
        contentTextBox.Size = new Size(794, 233);
        contentTextBox.TabIndex = 1;
        // 
        // LogViewForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(30, 30, 30);
        ClientSize = new Size(800, 288);
        Controls.Add(contentPanel);
        Font = new Font("Aptos Display", 10F);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "LogViewForm";
        Text = "program logs";
        contentPanel.ResumeLayout(false);
        contentPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel contentPanel;
    private TextBox contentTextBox;
    private Button openLogFolderButton;
    private Label label1;
}