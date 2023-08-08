using Application.Abstracts.Messaging;
using Domain.Entities.Organisations;

namespace Application.Organisations.GetSubOrganisations;

public record GetSubOrganisationsQuery(OrganisationId OrganisationId) : IQuery<List<OrganisationMembershipResponse>>;
