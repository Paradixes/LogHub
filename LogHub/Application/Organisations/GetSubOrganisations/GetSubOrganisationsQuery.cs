using Domain.Entities.Organisations;
using MediatR;

namespace Application.Organisations.GetSubOrganisations;

public record GetSubOrganisationsQuery(OrganisationId OrganisationId) : IRequest<List<OrganisationMembershipResponse>>;