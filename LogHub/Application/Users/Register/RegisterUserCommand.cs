using LogHub.Application.Abstracts.Messaging;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Enums;

namespace LogHub.Application.Users.Register;

public record RegisterUserCommand(
    string Email,
    string Name,
    OrganisationId OrganisationId,
    DepartmentId? DepartmentId,
    string Profession,
    string? Orcid,
    UserRole Role,
    string Password) : ICommand<Guid>;
