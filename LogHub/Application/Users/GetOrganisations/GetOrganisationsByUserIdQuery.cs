using Application.Abstracts.Messaging;
using Application.Organisations.GetById;

namespace Application.Users.GetOrganisations;

public record GetOrganisationsByUserIdQuery(Guid UserId) : IQuery<List<OrganisationResponse>>;
