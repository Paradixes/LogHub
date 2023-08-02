using LogHub.Application.Abstracts.Messaging;
using LogHub.Domain.Repositories;
using LogHub.Domain.Shared;

namespace LogHub.Application.UserPreference.Update;

public class UpdateUserPreferenceCommandHandler : ICommandHandler<UpdateUserPreferenceCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserPreferenceCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(UpdateUserPreferenceCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

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