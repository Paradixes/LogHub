using Domain.Exceptions.Memberships;
using Domain.Repositories;
using MediatR;

namespace Application.Memberships.Update;

public class UpdateMembershipCommandHandler : IRequestHandler<UpdateMembershipCommand>
{
    private readonly IMembershipRepository _membershipRepository;

    public UpdateMembershipCommandHandler(IMembershipRepository membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }

    public async Task Handle(UpdateMembershipCommand request, CancellationToken cancellationToken)
    {
        var membership = await _membershipRepository.GetByIdAsync(request.UserId, request.OrganisationId);

        if (membership is null)
        {
            throw new MembershipNotFoundException(request.UserId, request.OrganisationId);
        }

        membership.UpdateRole(request.Role);
    }
}
