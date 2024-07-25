using Whiskers.Forms;
using Whiskers.Managers;

namespace Whiskers;

internal static class Program
{
    [STAThread]
    private static async Task Main()
    {
        using (new Mutex(true, "WhiskersMutex", out _))
        {
            await SettingsManager.LoadSettingsAsync();

            ApplicationConfiguration.Initialize();
            
            TrayManager.TrayIcon.Visible = true;
            
            Application.ApplicationExit += (_, _) =>
            {
                WatcherManager.Stop();
                TrayManager.Destroy();
            };
            Application.Run(new CrosshairForm());
        }
    }
}
