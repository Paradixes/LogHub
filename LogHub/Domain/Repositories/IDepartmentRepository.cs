using Domain.Entities.Organisations;
using Domain.Entities.Users;

namespace Domain.Repositories;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(DepartmentId id);

    Task<Department?> GetByManagerIdAsync(UserId managerId);

    void Add(Department department);

    void Update(Department department);

    void Remove(Department department);

    List<Department> GetByOrganisationId(OrganisationId organisationId);
}
