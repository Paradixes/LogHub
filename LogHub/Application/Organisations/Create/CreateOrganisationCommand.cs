using Application.Abstracts.Messaging;
using Domain.Entities.Organisations;
using Domain.Entities.Users;

namespace Application.Organisations.Create;

public record CreateOrganisationCommand(
    UserId ManagerId,
    string? Logo,
    string Name,
    string? Description,
    OrganisationId ParentId
) : ICommand<Guid>;
