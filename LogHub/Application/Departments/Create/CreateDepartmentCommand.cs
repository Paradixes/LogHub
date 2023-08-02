using Domain.Entities.Organisations;
using Domain.Entities.Users;
using MediatR;

namespace Application.Departments.Create;

public record CreateDepartmentCommand(
    OrganisationId OrganisationId,
    UserId ManagerId,
    string? Logo,
    string Name,
    string Description) : IRequest;
