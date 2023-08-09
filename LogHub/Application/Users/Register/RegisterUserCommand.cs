using MediatR;
using Shared.Enums;

namespace Application.Users.Register;

public record RegisterUserCommand(
    string Email,
    string Name,
    string Profession,
    string? Orcid,
    UserRole Role,
    string Password) : IRequest<Guid>;