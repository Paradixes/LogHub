using Application.Abstracts.Messaging;
using Application.Organisations.GetById;

namespace Application.Users.GetRootOrganisations;

public record GetRootOrganisationsByIdQuery(Guid UserId) : IQuery<List<OrganisationResponse>>;