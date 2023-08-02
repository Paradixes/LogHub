using LogHub.Application.Abstracts;
using LogHub.Application.Enums;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Repositories;
using MediatR;

namespace LogHub.Application.Organisations.AddDepartment;

public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand>
{
    private readonly IBlobStorageProvider _blobStorageProvider;
    private readonly IDepartmentRepository _departmentRepository;

    public AddDepartmentCommandHandler(
        IBlobStorageProvider blobStorageProvider,
        IDepartmentRepository departmentRepository)
    {
        _blobStorageProvider = blobStorageProvider;
        _departmentRepository = departmentRepository;
    }

    public async Task Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = Department.Create(
            request.Name,
            request.Description,
            request.ManagerId,
            request.OrganisationId
        );

        if (request.Logo is not null)
        {
            var logo = await _blobStorageProvider.UploadAsync(
                ContainerName.DepartmentLogos,
                department.Id.Value + ".png",
                request.Logo,
                cancellationToken);

            department.UpdateLogo(logo);
        }

        _departmentRepository.Add(department);
    }
}
