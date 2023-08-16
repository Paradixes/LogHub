using Shared.Enums;

namespace Application.Users.UserPreference.GetById;

public record UserPreferenceResponse(
    Guid Id,
    Theme Theme,
    bool EmailNotification,
    bool AutoSave,
    int FontSize);