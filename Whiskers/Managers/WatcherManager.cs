using System.Timers;
using System.Diagnostics;
using Timer = System.Timers.Timer;

namespace Whiskers.Managers;

public static class WatcherManager
{
    public static bool Enabled => WatcherTimer.Enabled;

    private static readonly List<string> WatchedProcs = [];

    private static readonly Timer WatcherTimer = new()
    {
        Interval = 250,
        Enabled  = false,
    };

    public static void Start()
    {
        SettingsManager.SettingsChanged += SettingsManagerOnSettingsChanged;
        WatchedProcs.AddRange(SettingsManager.Settings.WatchedProcesses);
        WatcherTimer.Elapsed += WatcherTimerOnElapsed;
        WatcherTimer.Start();
    }

    public static void Stop()
    {
        SettingsManager.SettingsChanged -= SettingsManagerOnSettingsChanged;
        WatcherTimer.Elapsed -= WatcherTimerOnElapsed;
        WatcherTimer.Stop();
    }
    
    private static void SettingsManagerOnSettingsChanged(object? sender, EventArgs e)
    {
        WatchedProcs.AddRange(SettingsManager.Settings.WatchedProcesses);
    }
    
    private static void WatcherTimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        CrosshairManager.Enabled = Process.GetProcesses().Any(p => WatchedProcs.Contains(p.ProcessName));
    }
}
