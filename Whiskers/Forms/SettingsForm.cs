using Whiskers.Models;
using Whiskers.Managers;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Whiskers.Forms;

public partial class SettingsForm : Form
{
    private readonly Pen   _previewPen;
    private readonly Regex _hexColorCodePattern;
    
    public SettingsForm()
    {
        _previewPen = new Pen(Color.White, 1f);
        
        _hexColorCodePattern = new Regex("^#?([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$", RegexOptions.Compiled);

        InitializeComponent();
        PopulateSettingsValues();
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        UpdateStyles();
        
        Closing += OnClosing;

        c_LineOpacityInput.ValueChanged += C_LineOpacityInputOnValueChanged;
        c_LineColorInput.TextChanged    += C_LineColorInputOnTextChanged;
        c_LineWidthInput.ValueChanged   += C_LineWidthInputOnValueChanged;
        c_PreviewPanel.Paint            += OnPaint;

        UpdatePreview();
    }

    private void OnPaint(object? sender, PaintEventArgs e)
    {
        var w = c_PreviewPanel.Width;
        var h = c_PreviewPanel.Height;
        var x = w / 2;
        var y = h / 2;
        
        e.Graphics.DrawLine(_previewPen, x, 0, x, h);
        e.Graphics.DrawLine(_previewPen, 0, y, w, y);
    }

    private async void OnClosing(object? sender, CancelEventArgs e)
    {
        e.Cancel = true;
        
        if (!TryValidateSettings(out var settings))
        {
            MessageBox.Show(this, "One or more of your settings is invalid.", "Settings Error");
        }
        else
        {
            await SettingsManager.SaveSettingsAsync(settings);
            
            Visible  = false;
        }
    }

    private void C_LineOpacityInputOnValueChanged(object? sender, EventArgs e) => UpdatePreview();

    private void C_LineColorInputOnTextChanged(object? sender, EventArgs e) => UpdatePreview();
    
    private void C_LineWidthInputOnValueChanged(object? sender, EventArgs e) => UpdatePreview();

    private void PopulateSettingsValues()
    {
        var settings = SettingsManager.Settings;

        c_LineOpacityInput.Value     = settings.LineOpacity;
        c_LineColorInput.Text        = settings.LineColor;
        c_LineWidthInput.Value       = (int)settings.LineWidth;
        c_WatchedProcessesInput.Text = string.Join('\n', settings.WatchedProcesses);
    }
    
    private void UpdatePreview()
    {
        var colorInput = c_LineColorInput.Text.Trim();
        if (!_hexColorCodePattern.Match(colorInput).Success)
        {
            return;
        }

        var isDark = IsColorDark(colorInput);
        if (!colorInput.StartsWith('#'))
        {
            colorInput = $"#{colorInput}";
        }
        
        var opacityValue     = c_LineOpacityInput.Value;
        var opacity          = (int)((opacityValue - 1) * 2.55);
        var color            = ColorTranslator.FromHtml(colorInput);
        var previewBackColor = isDark ? Color.White : Color.Black;

        _previewPen.Width        = c_LineWidthInput.Value;
        _previewPen.Color        = Color.FromArgb(opacity, color.R, color.G, color.B);
        c_PreviewPanel.BackColor = previewBackColor;
        
        c_PreviewPanel.Invalidate();
    }

    private bool IsColorDark(string color)
    {
        const double threshold = 128;

        if (color.StartsWith('#'))
        {
            color = color[1..];
        }

        if (color.Length == 3)
        {
            color = $"{color[0]}{color[0]}{color[1]}{color[1]}{color[2]}{color[2]}";
        }

        int r = Convert.ToInt32(color.Substring(0, 2), 16);
        int g = Convert.ToInt32(color.Substring(2, 2), 16);
        int b = Convert.ToInt32(color.Substring(4, 2), 16);

        var luminance = 0.299 * r + 0.587 * g + 0.114 * b;

        return luminance < threshold;
    }

    private bool TryValidateSettings(out UserSettings settings)
    {
        settings = new UserSettings();
        
        var opacity      = c_LineOpacityInput.Value;
        var color        = c_LineColorInput.Text;
        var width        = c_LineWidthInput.Value;
        var watchedProcs = c_WatchedProcessesInput.Text.Trim();

        if (opacity is < 1 or > 100)
        {
            return false;
        }

        settings.LineOpacity = opacity;

        if (!_hexColorCodePattern.IsMatch(color))
        {
            return false;
        }
        
        settings.LineColor = color;

        if (width is < 1 or> 10)
        {
            return false;
        }

        settings.LineWidth        = width;
        settings.WatchedProcesses = watchedProcs.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();

        return true;
    }
}
