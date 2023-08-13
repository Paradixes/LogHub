using Domain.Entities.Organisations;
using MediatR;

namespace Application.Organisations.GetById;

public sealed record GetOrganisationByIdQuery(OrganisationId OrganisationId) : IRequest<OrganisationResponse>;
