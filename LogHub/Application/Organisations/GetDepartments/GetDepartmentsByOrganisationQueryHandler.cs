using Application.Abstracts.Messaging;
using Application.Departments.GetById;
using Domain.Entities.Organisations;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Organisations.GetDepartments;

public class GetDepartmentsByOrganisationQueryHandler
    : IQueryHandler<GetDepartmentsByOrganisationQuery, List<DepartmentResponse>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentsByOrganisationQueryHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public Task<Result<List<DepartmentResponse>>> Handle(
        GetDepartmentsByOrganisationQuery request,
        CancellationToken cancellationToken)
    {
        var departments = _departmentRepository.GetByOrganisationId(new OrganisationId(request.OrganisationId));

        var response = departments.Select(department =>
            new DepartmentResponse(
                department.Id.Value,
                department.Name,
                department.Description,
                department.LogoUri,
                department.ManagerId.Value,
                department.OrganisationId.Value
            )
        ).ToList();

        return Task.FromResult(Result.Success(response));
    }
}