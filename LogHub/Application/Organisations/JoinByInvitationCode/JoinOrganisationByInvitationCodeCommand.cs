using Application.Abstracts.Messaging;
using Domain.Entities.Users;

namespace Application.Organisations.JoinByInvitationCode;

public record JoinOrganisationByInvitationCodeCommand(
    UserId UserId,
    string InvitationCode
) : ICommand<Guid>;
