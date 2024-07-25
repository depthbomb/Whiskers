namespace Whiskers.Managers;

public static class CrosshairManager
{
    public static event EventHandler? StateChanged;

    public static bool Enabled
    {
        get => _enabled;
        set
        {
            _enabled = value;

            StateChanged?.Invoke(null, EventArgs.Empty);
        }
    }

    private static bool _enabled;

    public static bool Toggle()
    {
        Enabled = !Enabled;

        return Enabled;
    }
}
