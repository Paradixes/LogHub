using Domain.Exceptions.Users;
using Domain.Repositories;
using MediatR;

namespace Application.Users.Users.GetById;

public class GetUserByIdQueryHandler :
    IRequestHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> Handle(
        GetUserByIdQuery query,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.UserId);

        if (user is null)
        {
            throw new UserNotFoundException(query.UserId);
        }

        var response = new UserResponse(
            user.Id.Value,
            user.Email,
            user.Name,
            user.AvatarUri,
            user.Profession,
            user.Orcid,
            user.Role
        );

        return response;
    }
}