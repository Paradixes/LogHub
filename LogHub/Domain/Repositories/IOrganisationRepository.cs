using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;

namespace LogHub.Persistence.Repositories;

public interface IOrganisationRepository
{
    Task<Organisation?> GetByIdAsync(OrganisationId id, CancellationToken cancellationToken = default);

    Task<Organisation?> GetByManagerIdAsync(UserId managerId, CancellationToken cancellationToken = default);

    void Add(Organisation organisation);

    void Update(Organisation organisation);
}
