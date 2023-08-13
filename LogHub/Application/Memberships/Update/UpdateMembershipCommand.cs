using Domain.Entities.Organisations;
using Domain.Entities.Users;
using MediatR;
using Shared.Enums;

namespace Application.Memberships.Update;

public record UpdateMembershipCommand(
    UserId UserId,
    OrganisationId OrganisationId,
    OrganisationRole Role) : IRequest;
