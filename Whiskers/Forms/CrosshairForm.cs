using Windows.Win32;
using Whiskers.Managers;
using Timer = System.Windows.Forms.Timer;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32.UI.Input.KeyboardAndMouse;

namespace Whiskers.Forms;

public partial class CrosshairForm : Form
{
    private Point _cursorPos = Point.Empty;
    private bool  _clickHeld;
    
    private readonly Pen   _pen;
    private readonly Timer _cursorPositionTimer;
    
    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;
            #if RELEASE
            cp.ExStyle |= (int)WINDOW_EX_STYLE.WS_EX_NOACTIVATE;
            #endif
            
            cp.ExStyle |= (int)WINDOW_EX_STYLE.WS_EX_LAYERED;
            cp.ExStyle |= (int)WINDOW_EX_STYLE.WS_EX_TRANSPARENT;

            return cp;
        }
    }

    public CrosshairForm()
    {
        _pen                 = new Pen(Color.White, 2f);
        _cursorPositionTimer = new Timer { Interval = 1 };
        
        InitializeComponent();
        
        SettingsManager.SettingsChanged += SettingsManagerOnSettingsChanged;
        
        var ps = Screen.PrimaryScreen!;
        
        Size     = ps.Bounds.Size;
        Location = new Point(ps.WorkingArea.X + Bounds.X, ps.WorkingArea.Y + Bounds.Y);
        #if DEBUG
        ShowInTaskbar = true;
        #endif
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        UpdateStyles();

        Paint     += OnPaint;
        MouseUp   += (_, _) => _clickHeld = false;
        MouseDown += (_, _) => _clickHeld = true;

        _cursorPositionTimer.Tick += (_, _) =>
        {
            var leftClickHeld  = PInvoke.GetAsyncKeyState((int)VIRTUAL_KEY.VK_LBUTTON) < 0;
            var rightClickHeld = PInvoke.GetAsyncKeyState((int)VIRTUAL_KEY.VK_RBUTTON) < 0;
        
            _clickHeld = leftClickHeld || rightClickHeld;
            
            PInvoke.GetCursorPos(out _cursorPos);

            Invalidate();
        };
        _cursorPositionTimer.Start();

        UpdateLineStyleFromSettings();
    }

    private void SettingsManagerOnSettingsChanged(object? sender, EventArgs e) => UpdateLineStyleFromSettings();

    private void OnPaint(object? sender, PaintEventArgs e)
    {
        if (_clickHeld || !CrosshairManager.Enabled) return;

        var x = _cursorPos.X;
        var y = _cursorPos.Y;
        
        e.Graphics.DrawLine(_pen, x, 0, x, Height);
        e.Graphics.DrawLine(_pen, 0, y, Width, y);
    }

    private void UpdateLineStyleFromSettings()
    {
        var settings = SettingsManager.Settings;

        Opacity = settings.LineOpacity / 100f;
        
        _pen.Color = ColorTranslator.FromHtml(settings.LineColor);
        _pen.Width = settings.LineWidth;
    }
}
