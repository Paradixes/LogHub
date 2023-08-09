using Application.Abstracts.Messaging;
using Application.Organisations.GetById;
using Application.Users.GetById;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Organisations.GetSubOrganisations;

public class
    GetSubOrganisationsQueryHandler : IQueryHandler<GetSubOrganisationsQuery, List<OrganisationMembershipResponse>>
{
    private readonly IOrganisationRepository _organisationRepository;

    public GetSubOrganisationsQueryHandler(IOrganisationRepository organisationRepository)
    {
        _organisationRepository = organisationRepository;
    }

    public async Task<Result<List<OrganisationMembershipResponse>>> Handle(GetSubOrganisationsQuery request,
        CancellationToken cancellationToken)
    {
        var memberships =
            await _organisationRepository.GetSubOrganisationOwnerMembershipsAsync(request.OrganisationId);

        var response = memberships.Select(
            m => new OrganisationMembershipResponse(
                new UserResponse(
                    m.User.Id.Value,
                    m.User.Email,
                    m.User.Name,
                    m.User.AvatarUri,
                    m.User.Profession,
                    m.User.Orcid,
                    m.User.Role
                ),
                new OrganisationResponse(
                    m.Organisation.Id.Value,
                    m.Organisation.Name,
                    m.Organisation.LogoUri,
                    m.Organisation.Description),
                m.Role
            )).ToList();

        return Result.Success(response);
    }
}
