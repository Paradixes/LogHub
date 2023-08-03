using Application.Abstracts.Messaging;
using Shared.Enums;

namespace Application.Users.Register;

public record RegisterUserCommand(
    string Email,
    string Name,
    string Profession,
    string? Orcid,
    UserRole Role,
    string Password) : ICommand<Guid>;