using Application.Abstracts;
using Application.Enums;
using Domain.Entities.Organisations;
using Domain.Exceptions.Organisations;
using Domain.Repositories;
using MediatR;

namespace Application.Organisations.Create;

public class CreateOrganisationCommandHandler :
    IRequestHandler<CreateOrganisationCommand>
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

    public async Task Handle(CreateOrganisationCommand request, CancellationToken cancellationToken)
    {
        if (request.ParentId is not null)
        {
            var parent = await _organisationRepository.GetByIdAsync(request.ParentId);

            if (parent is null)
            {
                throw new OrganisationNotFoundException(request.ParentId);
            }

            parent.AddSubOrganisation(request.ManagerId, request.Name, request.Description);
        }

        var organisation = Organisation.Create(
            request.ManagerId,
            request.Name,
            request.Description,
            request.ParentId);

        var logoUri = await _blobStorageProvider.UploadAsync(
            ContainerName.OrganisationLogos,
            organisation.Id.Value + ".png",
            request.Logo);

        organisation.SetLogo(logoUri);

        _organisationRepository.Add(organisation);
    }
}
