using LogHub.Application.Abstracts;
using LogHub.Application.Abstracts.Messaging;
using LogHub.Application.Enums;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Shared;
using LogHub.Persistence.Repositories;

namespace LogHub.Application.Organisations.Create;

public class CreateOrganisationCommandHandler : ICommandHandler<CreateOrganisationCommand, Guid>
{
    private readonly IBlobStorageProvider _blobStorageProvider;

    private readonly IOrganisationRepository _organisationRepository;

    public CreateOrganisationCommandHandler(
        IBlobStorageProvider blobStorageProvider,
        IOrganisationRepository organisationRepository)
    {
        _blobStorageProvider = blobStorageProvider;
        _organisationRepository = organisationRepository;
    }

    public async Task<Result<Guid>> Handle(CreateOrganisationCommand request, CancellationToken cancellationToken)
    {
        var organisation = Organisation.Create(
            request.ManagerId,
            request.Name,
            request.Description);

        if (request.Logo != null)
        {
            var logoUri = await _blobStorageProvider.UploadAsync(
                ContainerName.OrganisationLogos,
                organisation.Id.Value + ".png",
                request.Logo,
                cancellationToken);

            organisation.SetLogo(logoUri);
        }

        _organisationRepository.Add(organisation);

        return Result.Success(organisation.Id.Value);
    }
}
