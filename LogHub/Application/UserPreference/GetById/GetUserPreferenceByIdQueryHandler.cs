using Application.Abstracts.Messaging;
using Domain.Entities.Users;
using Domain.Repositories;
using Domain.Shared;

namespace Application.UserPreference.GetById;

public class GetUserPreferenceByIdQueryHandler : IQueryHandler<GetUserPreferenceByIdQuery, UserPreferenceResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserPreferenceByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserPreferenceResponse>> Handle(GetUserPreferenceByIdQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(new UserId(request.UserId));

        if (user is null)
        {
            return Result.Failure<UserPreferenceResponse>(new Error(
                "User.NotFound",
                $"The user with Id {request.UserId} was not found"));
        }

        var response = new UserPreferenceResponse(
            user.Id.Value,
            user.UserPreference.Theme,
            user.UserPreference.EmailNotification,
            user.UserPreference.AutoSave,
            user.UserPreference.FontSize);

        return Result.Success(response);
    }
}
