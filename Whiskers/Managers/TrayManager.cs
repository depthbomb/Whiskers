using Whiskers.Forms;

namespace Whiskers.Managers;

public enum TrayState
{
    Neutral,
    Active,
    Inactive,
    Watching
}

public static class TrayManager
{
    private static NotifyIcon? _trayIcon;
    
    private static readonly Icon         NeutralIcon  = Resources.Icons.icon_neutral;
    private static readonly Icon         ActiveIcon   = Resources.Icons.icon_active;
    private static readonly Icon         InactiveIcon = Resources.Icons.icon_inactive;
    private static readonly Icon         WatchingIcon = Resources.Icons.icon_watching;
    private static readonly SettingsForm SettingsForm;

    static TrayManager()
    {
        SettingsForm         = new SettingsForm();
        SettingsForm.Visible = false;
        
        CrosshairManager.StateChanged += CrosshairManagerOnStateChanged;
    }

    public static NotifyIcon TrayIcon
    {
        get
        {
            if (_trayIcon == null)
            {
                _trayIcon             =  new NotifyIcon();
                _trayIcon.Visible     =  false;
                _trayIcon.DoubleClick += TrayIconOnDoubleClick;
                
                SetState(TrayState.Inactive);
            }

            return _trayIcon;
        }
    }
    
    public static void SetState(TrayState state)
    {
        if (_trayIcon == null)
        {
            return;
        }

        _trayIcon.Text = state switch
        {
            TrayState.Neutral  => "Cursor Crosshair",
            TrayState.Active   => "Cursor Crosshair (Active)",
            TrayState.Inactive => "Cursor Crosshair (Inactive)",
            TrayState.Watching => "Cursor Crosshair (Watching)",
            _                  => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };
        _trayIcon.Icon = state switch
        {
            TrayState.Neutral  => NeutralIcon,
            TrayState.Active   => ActiveIcon,
            TrayState.Inactive => InactiveIcon,
            TrayState.Watching => WatchingIcon,
            _                  => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };
        
        _trayIcon.ContextMenuStrip = CreateTrayMenu();
    }

    public static void Destroy()
    {
        if (_trayIcon != null)
        {
            _trayIcon.Visible = false;
            _trayIcon.Dispose();
        }
    }
    
    private static void CrosshairManagerOnStateChanged(object? sender, EventArgs e)
    {
        if (CrosshairManager.Enabled)
        {
            SetState(TrayState.Active);
        }
        else
        {
            if (WatcherManager.Enabled)
            {
                SetState(TrayState.Watching);
            }
            else
            {
                SetState(TrayState.Inactive);
            }
        }
    }

    private static void TrayIconOnDoubleClick(object? s, EventArgs e)
    {
        if (WatcherManager.Enabled)
        {
            WatcherManager.Stop();
        }
        
        SetState(CrosshairManager.Toggle() ? TrayState.Active : TrayState.Inactive);
    }

    private static ContextMenuStrip CreateTrayMenu()
    {
        var menu = new ContextMenuStrip();
        menu.Items.Add(new ToolStripMenuItem("Process &Watcher", null, OnToggleProcessWatcherClick)
        {
            Checked = WatcherManager.Enabled,
            Font    = new Font(menu.Font, FontStyle.Bold)
        });
        menu.Items.Add(new ToolStripMenuItem("&Settings", null, OnOpenSettingsClick));
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add("&Exit", null, OnExitClick);

        return menu;
    }

    private static void OnToggleProcessWatcherClick(object? sender, EventArgs e)
    {
        CrosshairManager.Enabled = false;

        if (WatcherManager.Enabled)
        {
            WatcherManager.Stop();
            SetState(TrayState.Inactive);
        }
        else
        {
            WatcherManager.Start();
            SetState(TrayState.Watching);
        }
    }

    private static void OnOpenSettingsClick(object? sender, EventArgs e)
    {
        SettingsForm.Visible = true;
        SettingsForm.BringToFront();
    }

    private static void OnExitClick(object? sender, EventArgs e)
    {
        CrosshairManager.StateChanged -= CrosshairManagerOnStateChanged;
        CrosshairManager.Enabled = false;
        
        Application.Exit();
    }
}
