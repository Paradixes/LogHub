using Domain.Entities.Organisations;
using Domain.Entities.Users;
using MediatR;

namespace Application.Organisations.Create;

public record CreateOrganisationCommand(
    UserId ManagerId,
    string? Logo,
    string Name,
    string? Description,
    OrganisationId? ParentId
) : IRequest;
