using Domain.Entities.Organisations;
using Domain.Entities.Users;
using MediatR;

namespace Application.Memberships.Delete;

public record DeleteMembershipCommand(UserId UserId, OrganisationId OrganisationId) : IRequest;