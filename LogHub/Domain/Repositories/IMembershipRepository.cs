using Domain.Entities.Middlewares;
using Domain.Entities.Organisations;
using Domain.Entities.Users;

namespace Domain.Repositories;

public interface IMembershipRepository
{
    Task<OrganisationMembership?> GetByIdAsync(UserId userId, OrganisationId organisationId);

    Task<List<OrganisationMembership>> GetByParentOrganisationAsync(OrganisationId organisationId);

    Task<List<OrganisationMembership>> GetByOrganisationIdAsync(OrganisationId organisationId);

    void Delete(OrganisationMembership membership);
}
