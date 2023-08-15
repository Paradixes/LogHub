using Domain.Entities.Organisations;
using Domain.Entities.Users;
using MediatR;
using Shared.Enums;

namespace Application.Memberships.GetById;

public record GetMembershipByIdQuery(UserId UserId, OrganisationId OrganisationId) :
    IRequest<OrganisationRole>;
