using Application.Organisations.GetById;
using Application.Organisations.GetSubOrganisations;
using Domain.Entities.Organisations;

namespace Application.Organisations;

public interface IOrganisationReadService
{
    Task<OrganisationResponse?> GetByIdAsync(OrganisationId id);

    Task<OrganisationResponse?> GetRootOrganisationAsync(OrganisationId id);

    Task<List<OrganisationMembershipResponse>> GetSubOrganisationsAsync(OrganisationId id);
}
