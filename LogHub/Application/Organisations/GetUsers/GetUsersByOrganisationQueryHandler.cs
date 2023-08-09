using Application.Users.GetById;
using Domain.Repositories;
using MediatR;

namespace Application.Organisations.GetUsers;

public class GetUsersByOrganisationQueryHandler :
    IRequestHandler<GetUsersByOrganisationQuery, List<UserResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersByOrganisationQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserResponse>> Handle(
        GetUsersByOrganisationQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetByOrganisationIdAsync(request.OrganisationId);

        var userResponses = users.Select(user => new UserResponse(
            user.Id.Value,
            user.Email,
            user.Name,
            user.AvatarUri,
            user.Profession,
            user.Orcid,
            user.Role)).ToList();

        return userResponses;
    }
}
