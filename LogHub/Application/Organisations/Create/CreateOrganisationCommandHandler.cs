using Application.Abstracts;
using Application.Abstracts.Messaging;
using Application.Enums;
using Domain.Entities.Organisations;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Organisations.Create;

public class CreateOrganisationCommandHandler : ICommandHandler<CreateOrganisationCommand, Guid>
{
    private readonly IBlobStorageProvider _blobStorageProvider;

    private readonly IOrganisationRepository _organisationRepository;

    private readonly IUserRepository _userRepository;

    public CreateOrganisationCommandHandler(
        IBlobStorageProvider blobStorageProvider,
        IOrganisationRepository organisationRepository,
        IUserRepository userRepository)
    {
        _blobStorageProvider = blobStorageProvider;
        _organisationRepository = organisationRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<Guid>> Handle(CreateOrganisationCommand request, CancellationToken cancellationToken)
    {
        var organisation = Organisation.Create(
            request.ManagerId,
            request.Name,
            request.Description);

        if (request.Logo is not null)
        {
            var logoUri = await _blobStorageProvider.UploadAsync(
                ContainerName.OrganisationLogos,
                organisation.Id.Value + ".png",
                request.Logo,
                cancellationToken);

            organisation.SetLogo(logoUri);
        }

        var manager = await _userRepository.GetByIdAsync(request.ManagerId, cancellationToken);

        if (manager is null)
        {
            return Result.Failure<Guid>(new Error(
                "User.NotFound",
                $"The user with Id {request.ManagerId} was not found"));
        }

        manager.SetOrganisation(organisation.Id);

        _userRepository.Update(manager);

        _organisationRepository.Add(organisation);

        return Result.Success(organisation.Id.Value);
    }
}
