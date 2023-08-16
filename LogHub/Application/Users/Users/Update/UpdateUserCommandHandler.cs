using Application.Abstracts;
using Application.Enums;
using Domain.Exceptions.Users;
using Domain.Repositories;
using MediatR;

namespace Application.Users.Users.Update;

public class UpdateUserCommandHandler :
    IRequestHandler<UpdateUserCommand>
{
    private readonly IBlobStorageProvider _blobStorageProvider;
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(
        IUserRepository userRepository,
        IBlobStorageProvider blobStorageProvider)
    {
        _userRepository = userRepository;
        _blobStorageProvider = blobStorageProvider;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user is null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        if (request.Avatar is not null)
        {
            await _blobStorageProvider.DeleteAsync(ContainerName.UserAvatars, user.AvatarUri?.ToString());
            var avatarUri = await _blobStorageProvider.UploadAsync(
                ContainerName.UserAvatars,
                request.Avatar);

            user.UpdateAvatar(avatarUri);
        }

        user.UpdateProfile(request.Name, request.Profession, request.Orcid);
    }
}