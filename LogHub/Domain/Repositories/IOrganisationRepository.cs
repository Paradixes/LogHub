using Domain.Entities.Organisations;
using Domain.Entities.Users;

namespace Domain.Repositories;

public interface IOrganisationRepository
{
    Task<Organisation?> GetByIdAsync(OrganisationId id);

    Task<Organisation?> GetRootBySubIdAsync(OrganisationId id);

    void Add(Organisation organisation);

    Task<User?> GetOwnerAsync(OrganisationId organisationId);

    Task<Organisation?> GetByInvitationCodeAsync(string requestInvitationCode);

    void Delete(Organisation organisation);
}