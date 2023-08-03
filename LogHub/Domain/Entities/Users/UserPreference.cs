using Shared.Enums;

namespace Domain.Entities.Users;

public class UserPreference
{
    internal UserPreference() { }

    internal UserPreference(
        Theme theme,
        bool emailNotification,
        bool autoSave,
        int fontSize)
    {
        Theme = theme;
        EmailNotification = emailNotification;
        AutoSave = autoSave;
        FontSize = fontSize;
    }

    public Theme Theme { get; private set; } = Theme.Light;

    public bool EmailNotification { get; private set; } = true;

    public bool AutoSave { get; private set; } = true;

    public int FontSize { get; private set; } = 12;

    public void Update(
        Theme theme,
        bool emailNotification,
        bool autoSave,
        int fontSize)
    {
        Theme = theme;
        EmailNotification = emailNotification;
        AutoSave = autoSave;
        FontSize = fontSize;
    }
}