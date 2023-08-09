using Application.Abstracts.Messaging;
using Domain.Entities.Organisations;

namespace Application.Organisations.GetById;

public sealed record GetOrganisationByIdQuery(OrganisationId OrganisationId) : IQuery<OrganisationResponse>;
