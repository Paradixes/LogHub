using Domain.Exceptions.Users;
using Domain.Repositories;
using MediatR;

namespace Application.UserPreference.GetById;

public class GetUserPreferenceByIdQueryHandler :
    IRequestHandler<GetUserPreferenceByIdQuery, UserPreferenceResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserPreferenceByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserPreferenceResponse> Handle(
        GetUserPreferenceByIdQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user is null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        var response = new UserPreferenceResponse(
            user.Id.Value,
            user.UserPreference.Theme,
            user.UserPreference.EmailNotification,
            user.UserPreference.AutoSave,
            user.UserPreference.FontSize);

        return response;
    }
}
