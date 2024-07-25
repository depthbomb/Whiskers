namespace Whiskers.Forms
{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            c_MainTableLayout = new TableLayoutPanel();
            c_SettingsInputsLayout = new TableLayoutPanel();
            c_LineOpacityLabel = new Label();
            c_LineColorLabel = new Label();
            c_LineColorInput = new TextBox();
            c_LineOpacityInput = new TrackBar();
            c_LineWidthLabel = new Label();
            c_LineWidthInput = new TrackBar();
            c_PreviewPanel = new Panel();
            c_WatchedProcessesLabel = new Label();
            c_WatchedProcessesInput = new TextBox();
            c_MainTableLayout.SuspendLayout();
            c_SettingsInputsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)c_LineOpacityInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c_LineWidthInput).BeginInit();
            SuspendLayout();
            // 
            // c_MainTableLayout
            // 
            c_MainTableLayout.ColumnCount = 1;
            c_MainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            c_MainTableLayout.Controls.Add(c_SettingsInputsLayout, 0, 0);
            c_MainTableLayout.Controls.Add(c_PreviewPanel, 0, 1);
            c_MainTableLayout.Dock = DockStyle.Fill;
            c_MainTableLayout.Location = new Point(0, 0);
            c_MainTableLayout.Name = "c_MainTableLayout";
            c_MainTableLayout.RowCount = 2;
            c_MainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            c_MainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            c_MainTableLayout.Size = new Size(784, 561);
            c_MainTableLayout.TabIndex = 0;
            // 
            // c_SettingsInputsLayout
            // 
            c_SettingsInputsLayout.ColumnCount = 3;
            c_SettingsInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            c_SettingsInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            c_SettingsInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            c_SettingsInputsLayout.Controls.Add(c_LineOpacityLabel, 0, 0);
            c_SettingsInputsLayout.Controls.Add(c_LineColorLabel, 0, 1);
            c_SettingsInputsLayout.Controls.Add(c_LineColorInput, 1, 1);
            c_SettingsInputsLayout.Controls.Add(c_LineOpacityInput, 1, 0);
            c_SettingsInputsLayout.Controls.Add(c_LineWidthLabel, 0, 2);
            c_SettingsInputsLayout.Controls.Add(c_LineWidthInput, 1, 2);
            c_SettingsInputsLayout.Controls.Add(c_WatchedProcessesLabel, 0, 3);
            c_SettingsInputsLayout.Controls.Add(c_WatchedProcessesInput, 1, 3);
            c_SettingsInputsLayout.Dock = DockStyle.Fill;
            c_SettingsInputsLayout.Location = new Point(0, 0);
            c_SettingsInputsLayout.Margin = new Padding(0);
            c_SettingsInputsLayout.Name = "c_SettingsInputsLayout";
            c_SettingsInputsLayout.RowCount = 4;
            c_SettingsInputsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25.0006237F));
            c_SettingsInputsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25.0006275F));
            c_SettingsInputsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25.0006275F));
            c_SettingsInputsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 24.9981289F));
            c_SettingsInputsLayout.Size = new Size(784, 392);
            c_SettingsInputsLayout.TabIndex = 0;
            // 
            // c_LineOpacityLabel
            // 
            c_LineOpacityLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            c_LineOpacityLabel.AutoSize = true;
            c_LineOpacityLabel.Location = new Point(3, 41);
            c_LineOpacityLabel.Name = "c_LineOpacityLabel";
            c_LineOpacityLabel.Size = new Size(144, 15);
            c_LineOpacityLabel.TabIndex = 0;
            c_LineOpacityLabel.Text = "Line Opacity";
            c_LineOpacityLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // c_LineColorLabel
            // 
            c_LineColorLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            c_LineColorLabel.AutoSize = true;
            c_LineColorLabel.Location = new Point(3, 139);
            c_LineColorLabel.Name = "c_LineColorLabel";
            c_LineColorLabel.Size = new Size(144, 15);
            c_LineColorLabel.TabIndex = 2;
            c_LineColorLabel.Text = "Line Color";
            c_LineColorLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // c_LineColorInput
            // 
            c_LineColorInput.Anchor = AnchorStyles.Left;
            c_LineColorInput.Location = new Point(153, 135);
            c_LineColorInput.Name = "c_LineColorInput";
            c_LineColorInput.Size = new Size(120, 23);
            c_LineColorInput.TabIndex = 3;
            // 
            // c_LineOpacityInput
            // 
            c_LineOpacityInput.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            c_LineOpacityInput.Location = new Point(153, 26);
            c_LineOpacityInput.Maximum = 100;
            c_LineOpacityInput.Minimum = 1;
            c_LineOpacityInput.Name = "c_LineOpacityInput";
            c_LineOpacityInput.Size = new Size(311, 45);
            c_LineOpacityInput.TabIndex = 4;
            c_LineOpacityInput.Value = 25;
            // 
            // c_LineWidthLabel
            // 
            c_LineWidthLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            c_LineWidthLabel.AutoSize = true;
            c_LineWidthLabel.Location = new Point(3, 234);
            c_LineWidthLabel.Margin = new Padding(3);
            c_LineWidthLabel.Name = "c_LineWidthLabel";
            c_LineWidthLabel.Padding = new Padding(3);
            c_LineWidthLabel.Size = new Size(144, 21);
            c_LineWidthLabel.TabIndex = 5;
            c_LineWidthLabel.Text = "Line Width";
            c_LineWidthLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // c_LineWidthInput
            // 
            c_LineWidthInput.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            c_LineWidthInput.Location = new Point(153, 222);
            c_LineWidthInput.Minimum = 1;
            c_LineWidthInput.Name = "c_LineWidthInput";
            c_LineWidthInput.Size = new Size(311, 45);
            c_LineWidthInput.TabIndex = 6;
            c_LineWidthInput.Value = 1;
            // 
            // c_PreviewPanel
            // 
            c_PreviewPanel.Dock = DockStyle.Fill;
            c_PreviewPanel.Location = new Point(3, 395);
            c_PreviewPanel.Name = "c_PreviewPanel";
            c_PreviewPanel.Size = new Size(778, 163);
            c_PreviewPanel.TabIndex = 1;
            // 
            // c_WatchedProcessesLabel
            // 
            c_WatchedProcessesLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            c_WatchedProcessesLabel.AutoSize = true;
            c_WatchedProcessesLabel.Location = new Point(3, 332);
            c_WatchedProcessesLabel.Margin = new Padding(3);
            c_WatchedProcessesLabel.Name = "c_WatchedProcessesLabel";
            c_WatchedProcessesLabel.Padding = new Padding(3);
            c_WatchedProcessesLabel.Size = new Size(144, 21);
            c_WatchedProcessesLabel.TabIndex = 7;
            c_WatchedProcessesLabel.Text = "Watched Processes";
            // 
            // c_WatchedProcessesInput
            // 
            c_WatchedProcessesInput.Dock = DockStyle.Fill;
            c_WatchedProcessesInput.Location = new Point(153, 297);
            c_WatchedProcessesInput.Multiline = true;
            c_WatchedProcessesInput.Name = "c_WatchedProcessesInput";
            c_WatchedProcessesInput.Size = new Size(311, 92);
            c_WatchedProcessesInput.TabIndex = 8;
            c_WatchedProcessesInput.WordWrap = false;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(c_MainTableLayout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            c_MainTableLayout.ResumeLayout(false);
            c_SettingsInputsLayout.ResumeLayout(false);
            c_SettingsInputsLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)c_LineOpacityInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)c_LineWidthInput).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel c_MainTableLayout;
        private TableLayoutPanel c_SettingsInputsLayout;
        private Label c_LineOpacityLabel;
        private Label c_LineColorLabel;
        private TextBox c_LineColorInput;
        private TrackBar c_LineOpacityInput;
        private Panel c_PreviewPanel;
        private Label c_LineWidthLabel;
        private TrackBar c_LineWidthInput;
        private Label c_WatchedProcessesLabel;
        private TextBox c_WatchedProcessesInput;
    }
}