using LogHub.Application.Abstracts.Messaging;
using LogHub.Domain.Entities.Users;
using LogHub.Shared.Enums;

namespace LogHub.Application.UserPreference.Update;

public record UpdateUserPreferenceCommand(
    UserId UserId,
    Theme Theme,
    bool EmailNotification,
    bool AutoSave,
    int FontSize) : ICommand;