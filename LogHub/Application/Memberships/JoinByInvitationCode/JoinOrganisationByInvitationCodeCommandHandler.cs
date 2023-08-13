using Domain.Exceptions.Organisations;
using Domain.Repositories;
using MediatR;
using Shared.Enums;

namespace Application.Memberships.JoinByInvitationCode;

public class
    JoinOrganisationByInvitationCodeCommandHandler : IRequestHandler<JoinOrganisationByInvitationCodeCommand>
{
    private readonly IOrganisationRepository _organisationRepository;

    public JoinOrganisationByInvitationCodeCommandHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task Handle(JoinOrganisationByInvitationCodeCommand request,
        CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByInvitationCodeAsync(request.InvitationCode);

        if (organisation is null)
        {
            throw new OrganisationNotFoundException(request.InvitationCode);
        }

        organisation.AddMembership(request.UserId, OrganisationRole.Guest);
    }
}