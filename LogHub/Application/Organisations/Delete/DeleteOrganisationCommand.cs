using Domain.Entities.Organisations;
using MediatR;

namespace Application.Organisations.Delete;

public record DeleteOrganisationCommand(OrganisationId Id) : IRequest;
