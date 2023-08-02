using LogHub.Shared.Enums;

namespace LogHub.Application.UserPreference.Update;

public record UpdateUserPreferenceRequest(
    Theme Theme,
    bool EmailNotification,
    bool AutoSave,
    int FontSize);