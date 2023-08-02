using LogHub.Application.Abstracts.Messaging;

namespace LogHub.Application.Organisations.GetOrganisationById;

public sealed record GetOrganisationByIdQuery(Guid OrganisationId) : IQuery<OrganisationResponse>;