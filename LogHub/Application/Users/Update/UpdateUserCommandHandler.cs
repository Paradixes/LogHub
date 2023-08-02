using LogHub.Application.Abstracts;
using LogHub.Application.Abstracts.Messaging;
using LogHub.Application.Enums;
using LogHub.Domain.Repositories;
using LogHub.Domain.Shared;

namespace LogHub.Application.Users.Update;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
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

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure(new Error(
                "User.NotFound",
                $"The user with Id {request.UserId} was not found"));
        }

        if (request.Avatar is not null)
        {
            var avatarUri = await _blobStorageProvider.UploadAsync(
                ContainerName.UserAvatars,
                request.UserId.ToString(),
                request.Avatar,
                cancellationToken);
        }

        user.UpdateProfile(request.Name, request.Profession, request.Orcid);

        _userRepository.Update(user);

        return Result.Success();
    }
}
