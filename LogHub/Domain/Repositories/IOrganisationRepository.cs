using Domain.Entities.Organisations;

namespace Domain.Repositories;

public interface IOrganisationRepository
{
    Task<Organisation?> GetByIdAsync(OrganisationId id);

    void Add(Organisation organisation);

    void Update(Organisation organisation);
}
