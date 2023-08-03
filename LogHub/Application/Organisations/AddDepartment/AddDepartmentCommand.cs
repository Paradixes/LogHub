using Domain.Entities.Organisations;
using Domain.Entities.Users;
using MediatR;

namespace Application.Organisations.AddDepartment;

public record AddDepartmentCommand(
    OrganisationId OrganisationId,
    UserId ManagerId,
    string? Logo,
    string Name,
    string Description) : IRequest;