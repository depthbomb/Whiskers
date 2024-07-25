﻿namespace Whiskers.Forms;

partial class CrosshairForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrosshairForm));
        SuspendLayout();
        // 
        // CrosshairForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Lime;
        ClientSize = new Size(284, 261);
        FormBorderStyle = FormBorderStyle.None;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "CrosshairForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.Manual;
        Text = "Whiskers";
        TopMost = true;
        TransparencyKey = Color.Lime;
        WindowState = FormWindowState.Maximized;
        ResumeLayout(false);
    }

    #endregion
}
