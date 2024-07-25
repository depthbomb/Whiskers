namespace Whiskers;

public static class GlobalShared
{
    public const           string CompanyName   = "Caprine Logic";
    public static readonly string DataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), CompanyName, "Whiskers");
    public static readonly string SettingsFile  = Path.Combine(DataDirectory, "settings.w");
}
