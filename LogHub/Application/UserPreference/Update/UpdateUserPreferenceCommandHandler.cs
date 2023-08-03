using Application.Abstracts.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.UserPreference.Update;

public class UpdateUserPreferenceCommandHandler : ICommandHandler<UpdateUserPreferenceCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserPreferenceCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(UpdateUserPreferenceCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            return Result.Failure(new Error(
                "User.NotFound",
                $"The user with Id {request.UserId} was not found"));
        }

        user.UpdatePreference(request.Theme, request.EmailNotification, request.AutoSave, request.FontSize);

        _userRepository.Update(user);

        return Result.Success();
    }
}
