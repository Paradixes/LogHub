using Shared.Enums;

namespace Client.ViewModel;

public class SystemSettingsModel
{
    public Theme Theme { get; set; }

    public bool IsDarkMode
    {
        get => Theme == Theme.Dark;
        set => Theme = value ? Theme.Dark : Theme.Light;
    }

    public bool EmailNotification { get; set; }
    public bool AutoSave { get; set; }
    public int FontSize { get; set; }
}
