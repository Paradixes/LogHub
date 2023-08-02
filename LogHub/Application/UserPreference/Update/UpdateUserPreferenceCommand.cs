using Application.Abstracts.Messaging;
using Domain.Entities.Users;
using Shared.Enums;

namespace Application.UserPreference.Update;

public record UpdateUserPreferenceCommand(
    UserId UserId,
    Theme Theme,
    bool EmailNotification,
    bool AutoSave,
    int FontSize) : ICommand;
