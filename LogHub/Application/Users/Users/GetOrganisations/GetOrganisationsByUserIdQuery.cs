using Application.Organisations.GetById;
using MediatR;

namespace Application.Users.Users.GetOrganisations;

public record GetOrganisationsByUserIdQuery(Guid UserId) : IRequest<List<OrganisationResponse>>;