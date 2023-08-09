using Domain.Entities.Users;
using MediatR;

namespace Application.Organisations.JoinByInvitationCode;

public record JoinOrganisationByInvitationCodeCommand(
    UserId UserId,
    string InvitationCode
) : IRequest;
