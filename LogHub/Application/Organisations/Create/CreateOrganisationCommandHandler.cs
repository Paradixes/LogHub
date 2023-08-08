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

    public CreateOrganisationCommandHandler(
        IBlobStorageProvider blobStorageProvider,
        IOrganisationRepository organisationRepository)
    {
        _blobStorageProvider = blobStorageProvider;
        _organisationRepository = organisationRepository;
    }

    public async Task<Result<Guid>> Handle(CreateOrganisationCommand request, CancellationToken cancellationToken)
    {
        if (request.ParentId is not null)
        {
            var parent = await _organisationRepository.GetByIdAsync(request.ParentId);

            if (parent is null)
            {
                return Result.Failure<Guid>(new Error(
                    "Organisation.NotFound",
                    $"The organisation with Id {request.ParentId} was not found"));
            }

            parent.AddSubOrganisation(request.ManagerId, request.Name, request.Description);

            _organisationRepository.Update(parent);

            return parent.Id.Value;
        }

        var organisation = Organisation.Create(
            request.ManagerId,
            request.Name,
            request.Description,
            request.ParentId);

        if (request.Logo is not null)
        {
            var logoUri = await _blobStorageProvider.UploadAsync(
                ContainerName.OrganisationLogos,
                organisation.Id.Value + ".png",
                request.Logo);

            organisation.SetLogo(logoUri);
        }

        _organisationRepository.Add(organisation);

        return organisation.Id.Value;
    }
}
