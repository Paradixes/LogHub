using Domain.Entities.Organisations;
using Domain.Entities.Records.Repositories;
using Domain.Entities.Users;

namespace Domain.Repositories;

public interface IRepositoryRepository
{
    Task<Repository?> GetByIdAsync(RepositoryId id);

    Task<List<Repository>> GetByOrganisationIdAsync(OrganisationId organisationId);

    Task<List<Repository>> GetByUserIdAsync(UserId userId);

    void Add(Repository repository);

    void Delete(Repository repository);
}
