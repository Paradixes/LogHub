using LogHub.Application.Abstracts.Messaging;
using LogHub.Domain.Entities.Users;

namespace LogHub.Application.Organisations.Create;

public record CreateOrganisationCommand(
    UserId ManagerId,
    string? Logo,
    string Name,
    string Description
) : ICommand<Guid>;
