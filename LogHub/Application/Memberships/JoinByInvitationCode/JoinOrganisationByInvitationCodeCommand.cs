using Domain.Entities.Users;
using MediatR;

namespace Application.Memberships.JoinByInvitationCode;

public record JoinOrganisationByInvitationCodeCommand(
    UserId UserId,
    string InvitationCode
) : IRequest;