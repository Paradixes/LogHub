using Application.Abstracts.Messaging;
using Application.Organisations.GetById;

namespace Application.Organisations.GetByInvitationCode;

public record GetOrganisationByInvitationCodeQuery(string InvitationCode) : IQuery<OrganisationResponse>;
