namespace Whiskers.Models;

[Serializable]
public record UserSettings
{
    public int          LineOpacity      { get; set; } = 25;
    public float        LineWidth        { get; set; } = 1f;
    public string       LineColor        { get; set; } = "#ffffff";
    public List<string> WatchedProcesses { get; set; } = [];
}
