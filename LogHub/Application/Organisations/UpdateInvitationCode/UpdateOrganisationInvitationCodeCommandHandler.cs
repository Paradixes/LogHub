using Domain.Exceptions.Organisations;
using Domain.Repositories;
using MediatR;

namespace Application.Organisations.UpdateInvitationCode;

public class UpdateOrganisationInvitationCodeCommandHandler :
    IRequestHandler<UpdateOrganisationInvitationCodeCommand, string>
{
    private readonly IOrganisationRepository _organisationRepository;

    public UpdateOrganisationInvitationCodeCommandHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task<string> Handle(
        UpdateOrganisationInvitationCodeCommand request,
        CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByIdAsync(request.OrganisationId);
        if (organisation is null)
        {
            throw new OrganisationNotFoundException(request.OrganisationId);
        }

        organisation.UpdateInvitationCode();
        return organisation.InvitationCode;
    }
}
