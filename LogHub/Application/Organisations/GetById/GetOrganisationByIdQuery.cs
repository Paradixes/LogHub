using Application.Abstracts.Messaging;

namespace Application.Organisations.GetById;

public sealed record GetOrganisationByIdQuery(Guid OrganisationId) : IQuery<OrganisationResponse>;