using Domain.Entities.Users;
using MediatR;
using Shared.Enums;

namespace Application.UserPreference.Update;

public record UpdateUserPreferenceCommand(
    UserId UserId,
    Theme Theme,
    bool EmailNotification,
    bool AutoSave,
    int FontSize) : IRequest;