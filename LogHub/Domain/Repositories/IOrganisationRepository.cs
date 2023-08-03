using Domain.Entities.Organisations;
using Domain.Entities.Users;

namespace Domain.Repositories;

public interface IOrganisationRepository
{
    Task<Organisation?> GetByIdAsync(OrganisationId id);

    Task<Organisation?> GetByManagerIdAsync(UserId managerId);

    void Add(Organisation organisation);

    void Update(Organisation organisation);
}
