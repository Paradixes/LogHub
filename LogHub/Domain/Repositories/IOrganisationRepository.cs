using Domain.Entities.Organisations;
using Domain.Entities.Users;

namespace Domain.Repositories;

public interface IOrganisationRepository
{
    Task<Organisation?> GetByIdAsync(OrganisationId id, CancellationToken cancellationToken = default);

    Task<Organisation?> GetByManagerIdAsync(UserId managerId, CancellationToken cancellationToken = default);

    void Add(Organisation organisation);

    void Update(Organisation organisation);
}