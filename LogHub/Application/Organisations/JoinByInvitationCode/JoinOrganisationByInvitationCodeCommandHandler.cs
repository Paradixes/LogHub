using Application.Abstracts.Messaging;
using Domain.Repositories;
using Domain.Shared;
using Shared.Enums;

namespace Application.Organisations.JoinByInvitationCode;

public class
    JoinOrganisationByInvitationCodeCommandHandler : ICommandHandler<JoinOrganisationByInvitationCodeCommand, Guid>
{
    private readonly IOrganisationRepository _organisationRepository;

    public JoinOrganisationByInvitationCodeCommandHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task<Result<Guid>> Handle(JoinOrganisationByInvitationCodeCommand request,
        CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByInvitationCodeAsync(request.InvitationCode);

        if (organisation is null)
        {
            return Result.Failure<Guid>(new Error("Organisation.NotFound", "Organisation not found."));
        }

        organisation.AddMembership(request.UserId, OrganisationRole.Guest);

        return organisation.Id.Value;
    }
}
