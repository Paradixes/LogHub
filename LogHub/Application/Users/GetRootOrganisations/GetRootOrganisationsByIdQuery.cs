using Application.Organisations.GetById;
using MediatR;

namespace Application.Users.GetRootOrganisations;

public record GetRootOrganisationsByIdQuery(Guid UserId) : IRequest<List<OrganisationResponse>>;
