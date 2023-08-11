using Application.Organisations.GetById;
using Domain.Exceptions.Organisations;
using Domain.Repositories;
using MediatR;

namespace Application.Organisations.GetByInvitationCode;

public class GetOrganisationByInvitationCodeQueryHandler :
    IRequestHandler<GetOrganisationByInvitationCodeQuery, OrganisationResponse>
{
    private readonly IOrganisationRepository _organisationRepository;

    public GetOrganisationByInvitationCodeQueryHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task<OrganisationResponse> Handle(GetOrganisationByInvitationCodeQuery request,
        CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByInvitationCodeAsync(request.InvitationCode);

        if (organisation is null)
        {
            throw new OrganisationNotFoundException(request.InvitationCode);
        }

        var response = new OrganisationResponse(
            organisation.Id.Value,
            organisation.Name,
            organisation.LogoUri,
            organisation.Description,
            organisation.InvitationCode);

        return response;
    }
}
