using Application.Abstracts;
using Application.Enums;
using Domain.Entities.Organisations;
using Domain.Repositories;
using MediatR;

namespace Application.Departments.Create;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand>
{
    private readonly IBlobStorageProvider _blobStorageProvider;
    private readonly IDepartmentRepository _departmentRepository;

    public CreateDepartmentCommandHandler(
        IBlobStorageProvider blobStorageProvider,
        IDepartmentRepository departmentRepository)
    {
        _blobStorageProvider = blobStorageProvider;
        _departmentRepository = departmentRepository;
    }

    public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
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
