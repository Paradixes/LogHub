using Shared.Enums;

namespace Application.Users.UserPreference.Update;

public record UpdateUserPreferenceRequest(
    Theme Theme,
    bool EmailNotification,
    bool AutoSave,
    int FontSize);