using Domain.Entities.Users;
using MediatR;
using Shared.Enums;

namespace Application.Users.UserPreference.Update;

public record UpdateUserPreferenceCommand(
    UserId UserId,
    Theme Theme,
    bool EmailNotification,
    bool AutoSave,
    int FontSize) : IRequest;