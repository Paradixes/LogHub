using Application.Abstracts;
using Application.Enums;
using Domain.Exceptions.Users;
using Domain.Repositories;
using MediatR;

namespace Application.Users.Update;

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

        var avatarUri = await _blobStorageProvider.UploadAsync(
            ContainerName.UserAvatars,
            request.UserId.Value + ".png",
            request.Avatar);

        user.UpdateAvatar(avatarUri);

        user.UpdateProfile(request.Name, request.Profession, request.Orcid);
    }
}
