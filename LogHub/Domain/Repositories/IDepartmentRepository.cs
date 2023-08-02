using Domain.Entities.Organisations;
using Domain.Entities.Users;

namespace Domain.Repositories;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(DepartmentId id, CancellationToken cancellationToken = default);

    Task<Department?> GetByManagerIdAsync(UserId managerId, CancellationToken cancellationToken = default);

    void Add(Department department);

    void Update(Department department);

    void Remove(Department department);
}