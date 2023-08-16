using Domain.Exceptions.Users;
using Domain.Repositories;
using MediatR;

namespace Application.Users.UserPreference.Update;

public class UpdateUserPreferenceCommandHandler : IRequestHandler<UpdateUserPreferenceCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserPreferenceCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UpdateUserPreferenceCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user is null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        user.UpdatePreference(request.Theme, request.EmailNotification, request.AutoSave, request.FontSize);
    }
}