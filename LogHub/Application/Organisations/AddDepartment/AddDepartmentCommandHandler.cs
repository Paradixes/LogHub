using Application.Abstracts;
using Application.Enums;
using Domain.Repositories;
using MediatR;

namespace Application.Organisations.AddDepartment;

public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand>
{
    private readonly IBlobStorageProvider _blobStorageProvider;
    private readonly IOrganisationRepository _organisationRepository;

    public AddDepartmentCommandHandler(
        IBlobStorageProvider blobStorageProvider,
        IOrganisationRepository organisationRepository)
    {
        _blobStorageProvider = blobStorageProvider;
        _organisationRepository = organisationRepository;
    }

    public async Task Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
    {
        var organisation = await _organisationRepository.GetByIdAsync(request.OrganisationId);

        if (organisation is null)
        {
            return;
        }

        var department = organisation.AddDepartment(request.Name, request.Description, request.ManagerId);

        if (request.Logo is not null)
        {
            var logo = await _blobStorageProvider.UploadAsync(
                ContainerName.DepartmentLogos,
                department.Id.Value + ".png",
                request.Logo);

            department.UpdateLogo(logo);
        }

        _organisationRepository.Update(organisation);
    }
}
