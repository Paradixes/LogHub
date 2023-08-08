using Domain.Entities.Middlewares;
using Domain.Entities.Organisations;
using Domain.Entities.Users;

namespace Domain.Repositories;

public interface IOrganisationRepository
{
    Task<Organisation?> GetByIdAsync(OrganisationId id);

    Task<Organisation?> GetRootBySubIdAsync(OrganisationId id);

    Task<List<OrganisationMembership>> GetSubOrganisationOwnerMembershipsAsync(OrganisationId organisationId);

    void Add(Organisation organisation);

    void Update(Organisation organisation);

    Task<User?> GetOwnerAsync(OrganisationId organisationId);

    Task<Organisation?> GetByInvitationCodeAsync(string requestInvitationCode);
}
