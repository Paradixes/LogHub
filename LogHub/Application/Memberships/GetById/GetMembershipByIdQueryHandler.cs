using Domain.Repositories;
using MediatR;
using Shared.Enums;

namespace Application.Memberships.GetById;

public class GetMembershipByIdQueryHandler : IRequestHandler<GetMembershipByIdQuery, OrganisationRole>
{
    private readonly IMembershipRepository _membershipRepository;

    public GetMembershipByIdQueryHandler(IMembershipRepository membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }

    public async Task<OrganisationRole> Handle(
        GetMembershipByIdQuery request,
        CancellationToken cancellationToken)
    {
        var membership = await _membershipRepository.GetByIdAsync(request.UserId, request.OrganisationId);
        return membership?.Role ?? OrganisationRole.Guest;
    }
}
