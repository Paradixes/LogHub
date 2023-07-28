using LogHub.Application.Abstracts.Messaging;
using LogHub.Domain.Enums;

namespace LogHub.Application.Users.Register;

public record RegisterUserCommand(
    string Email,
    string Name,
    string Profession,
    string? Orcid,
    UserRole Role,
    string Password) : ICommand<Guid>;
