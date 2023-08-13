using Application.Abstracts;
using Application.Enums;
using Domain.Exceptions.Organisations;
using Domain.Repositories;
using MediatR;
using Shared.Enums;

namespace Application.Organisations.Update;

public class UpdateOrganisationCommandHandler :
    IRequestHandler<UpdateOrganisationCommand>
{
    private readonly IBlobStorageProvider _blobStorageProvider;
    private readonly IOrganisationRepository _organisationRepository;

    public UpdateOrganisationCommandHandler(
        IOrganisationRepository organisationRepository,
        IBlobStorageProvider blobStorageProvider)
    {
        _organisationRepository = organisationRepository;
        _blobStorageProvider = blobStorageProvider;
    }

    public async Task Handle(
        UpdateOrganisationCommand request,
        CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByIdAsync(request.OrganisationId);
        if (organisation is null)
        {
            throw new OrganisationNotFoundException(request.OrganisationId);
        }

        organisation.UpdateDetails(request.Name, request.Description);

        if (request.Logo is not null)
        {
            await _blobStorageProvider.DeleteAsync(ContainerName.OrganisationLogos, organisation.LogoUri?.ToString());
            var logoUri = await _blobStorageProvider.UploadAsync(
                ContainerName.OrganisationLogos,
                request.Logo);

            organisation.SetLogo(logoUri);
        }

        organisation.UpdateMembership(request.OwnerId, OrganisationRole.Owner);
    }
}
