using LogHub.Shared.Enums;

namespace LogHub.Application.UserPreference.GetUserPreferenceById;

public record UserPreferenceResponse(
    Guid Id,
    Theme Theme,
    bool EmailNotification,
    bool AutoSave,
    int FontSize);