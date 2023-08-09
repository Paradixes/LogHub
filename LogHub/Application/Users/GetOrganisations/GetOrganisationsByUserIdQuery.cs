using Application.Organisations.GetById;
using MediatR;

namespace Application.Users.GetOrganisations;

public record GetOrganisationsByUserIdQuery(Guid UserId) : IRequest<List<OrganisationResponse>>;