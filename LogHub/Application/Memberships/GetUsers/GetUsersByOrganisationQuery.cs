using Application.Memberships.GetSubOrganisations;
using Domain.Entities.Organisations;
using MediatR;

namespace Application.Memberships.GetUsers;

public record GetUsersByOrganisationQuery(OrganisationId OrganisationId) :
    IRequest<List<OrganisationMembershipResponse>>;