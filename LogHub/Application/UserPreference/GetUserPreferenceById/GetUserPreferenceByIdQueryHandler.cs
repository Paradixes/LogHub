using LogHub.Application.Abstracts.Messaging;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Repositories;
using LogHub.Domain.Shared;

namespace LogHub.Application.UserPreference.GetUserPreferenceById;

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
        var user = await _userRepository.GetByIdAsync(new UserId(request.UserId), cancellationToken);

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