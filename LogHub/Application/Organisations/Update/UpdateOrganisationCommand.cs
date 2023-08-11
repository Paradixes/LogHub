using Domain.Entities.Organisations;
using Domain.Entities.Users;
using MediatR;

namespace Application.Organisations.Update;

public record UpdateOrganisationCommand(
    OrganisationId OrganisationId,
    string Name,
    string? Logo,
    string? Description,
    UserId? OwnerId) : IRequest;