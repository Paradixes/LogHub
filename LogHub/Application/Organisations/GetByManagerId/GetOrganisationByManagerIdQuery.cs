using Application.Abstracts.Messaging;
using Application.Organisations.GetById;

namespace Application.Organisations.GetByManagerId;

public record GetOrganisationByManagerIdQuery(Guid ManagerId) : IQuery<OrganisationResponse>;
