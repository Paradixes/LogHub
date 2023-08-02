using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using MediatR;

namespace LogHub.Application.Organisations.AddDepartment;

public record AddDepartmentCommand(
    OrganisationId OrganisationId,
    UserId ManagerId,
    string? Logo,
    string Name,
    string Description) : IRequest;
