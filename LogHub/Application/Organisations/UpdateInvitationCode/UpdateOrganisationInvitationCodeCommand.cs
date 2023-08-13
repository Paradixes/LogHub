using Domain.Entities.Organisations;
using MediatR;

namespace Application.Organisations.UpdateInvitationCode;

public record UpdateOrganisationInvitationCodeCommand(
    OrganisationId OrganisationId,
    string InvitationCode) : IRequest<string>;
