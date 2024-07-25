using Whiskers.Models;
using System.Text.Json;

namespace Whiskers.Managers;

public static class SettingsManager
{
    public static event EventHandler? SettingsChanged;
    
    public static UserSettings Settings { get; private set; } = new();

    public static async Task<UserSettings> SaveSettingsAsync(UserSettings settings)
    {
        if (settings != Settings)
        {
            Settings = settings;
            
            await WriteSettingsAsync(Settings);
            
            SettingsChanged?.Invoke(null, EventArgs.Empty);
        }

        return Settings;
    }
    
    public static async Task<UserSettings> LoadSettingsAsync()
    {
        await EnsureSettingsFilePathAsync();
        await using (var stream = File.OpenRead(GlobalShared.SettingsFile))
        {
            var settings = await JsonSerializer.DeserializeAsync<UserSettings>(stream);

            Settings = settings!;

            return Settings;
        }
    }

    private static async Task EnsureSettingsFilePathAsync()
    {
        if (!Directory.Exists(GlobalShared.DataDirectory))
        {
            Directory.CreateDirectory(GlobalShared.DataDirectory);
        }

        if (!File.Exists(GlobalShared.SettingsFile))
        {
            await WriteSettingsAsync(Settings);
        }
    }

    private static async Task WriteSettingsAsync(UserSettings settings)
    {
        await using (var fs = new FileStream(GlobalShared.SettingsFile, FileMode.Create, FileAccess.Write))
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(settings);

            await fs.WriteAsync(bytes);
        }
    }
}
