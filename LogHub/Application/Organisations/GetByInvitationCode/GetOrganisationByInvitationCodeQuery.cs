using Application.Organisations.GetById;
using MediatR;

namespace Application.Organisations.GetByInvitationCode;

public record GetOrganisationByInvitationCodeQuery(string InvitationCode) : IRequest<OrganisationResponse>;