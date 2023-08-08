using Application.Abstracts.Messaging;
using Application.Organisations.GetById;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Organisations.GetByInvitationCode;

public class
    GetOrganisationByInvitationCodeQueryHandler : IQueryHandler<GetOrganisationByInvitationCodeQuery,
        OrganisationResponse>
{
    private readonly IOrganisationRepository _organisationRepository;

    public GetOrganisationByInvitationCodeQueryHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task<Result<OrganisationResponse>> Handle(GetOrganisationByInvitationCodeQuery request,
        CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByInvitationCodeAsync(request.InvitationCode);

        if (organisation is null)
        {
            return Result.Failure<OrganisationResponse>(new Error(
                "Organisation.NotFound",
                $"The organisation with invitation code {request.InvitationCode} was not found"));
        }

        var response = new OrganisationResponse(organisation.Id.Value, organisation.Name, organisation.LogoUri,
            organisation.Description);

        return response;
    }
}
