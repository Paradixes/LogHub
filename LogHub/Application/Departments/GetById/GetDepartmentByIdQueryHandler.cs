using Application.Abstracts.Messaging;
using Domain.Entities.Organisations;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Departments.GetById;

public class GetDepartmentByIdQueryHandler : IQueryHandler<GetDepartmentByIdQuery, DepartmentResponse>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<Result<DepartmentResponse>> Handle(GetDepartmentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var department = await _departmentRepository.GetByIdAsync(new DepartmentId(request.DepartmentId));

        if (department is null)
        {
            return Result.Failure<DepartmentResponse>(new Error(
                "Department.NotFound",
                $"The department with Id {request.DepartmentId} was not found"));
        }

        var response = new DepartmentResponse(
            department.Id.Value,
            department.Name,
            department.Description,
            department.LogoUri,
            department.ManagerId.Value,
            department.OrganisationId.Value
        );

        return response;
    }
}
