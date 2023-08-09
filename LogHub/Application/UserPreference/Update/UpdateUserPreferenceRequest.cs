using Shared.Enums;

namespace Application.UserPreference.Update;

public record UpdateUserPreferenceRequest(
    Theme Theme,
    bool EmailNotification,
    bool AutoSave,
    int FontSize);