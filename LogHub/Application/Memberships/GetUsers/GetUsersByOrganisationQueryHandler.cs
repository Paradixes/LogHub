using Application.Memberships.GetSubOrganisations;
using Application.Organisations.GetById;
using Application.Users.GetById;
using Domain.Repositories;
using MediatR;

namespace Application.Memberships.GetUsers;

public class GetUsersByOrganisationQueryHandler :
    IRequestHandler<GetUsersByOrganisationQuery, List<OrganisationMembershipResponse>>
{
    private readonly IMembershipRepository _membershipRepository;

    public GetUsersByOrganisationQueryHandler(IMembershipRepository membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }

    public async Task<List<OrganisationMembershipResponse>> Handle(
        GetUsersByOrganisationQuery request,
        CancellationToken cancellationToken)
    {
        var memberships = await _membershipRepository.GetByOrganisationIdAsync(request.OrganisationId);

        var response = memberships
            .Where(m => m.User is not null && m.Organisation is not null)
            .Select(m => new OrganisationMembershipResponse(
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
                    m.Organisation.Description,
                    m.Organisation.InvitationCode
                ),
                m.Role
            )).ToList();

        return response;
    }
}
