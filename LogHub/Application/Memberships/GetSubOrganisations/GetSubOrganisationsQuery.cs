using Domain.Entities.Organisations;
using MediatR;

namespace Application.Memberships.GetSubOrganisations;

public record GetSubOrganisationsQuery(OrganisationId OrganisationId) : IRequest<List<OrganisationMembershipResponse>>;