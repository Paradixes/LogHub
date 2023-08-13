using Domain.Entities.Organisations;
using Domain.Entities.Users;
using MediatR;

namespace Application.Organisations.Create;

public record CreateOrganisationCommand(
    UserId CreatorId,
    string? Logo,
    string Name,
    string? Description,
    OrganisationId? ParentId
) : IRequest;
