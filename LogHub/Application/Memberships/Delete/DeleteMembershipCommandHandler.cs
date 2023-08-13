using Domain.Exceptions.Memberships;
using Domain.Repositories;
using MediatR;

namespace Application.Memberships.Delete;

public class DeleteMembershipCommandHandler : IRequestHandler<DeleteMembershipCommand>
{
    private readonly IMembershipRepository _membershipRepository;

    public DeleteMembershipCommandHandler(IMembershipRepository membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }

    public async Task Handle(DeleteMembershipCommand request, CancellationToken cancellationToken)
    {
        var membership = await _membershipRepository.GetByIdAsync(request.UserId, request.OrganisationId);

        if (membership is null)
        {
            throw new MembershipNotFoundException(request.UserId, request.OrganisationId);
        }

        _membershipRepository.Delete(membership);
    }
}
