using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LogHub.Persistence.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly LogHubDbContext _context;

    public DepartmentRepository(LogHubDbContext context)
    {
        _context = context;
    }

    public Task<Department?> GetByIdAsync(DepartmentId id, CancellationToken cancellationToken = default)
    {
        return _context
            .Set<Department>()
            .FirstOrDefaultAsync(department => department.Id == id, cancellationToken);
    }

    public Task<Department?> GetByManagerIdAsync(UserId managerId, CancellationToken cancellationToken = default)
    {
        return _context
            .Set<Department>()
            .FirstOrDefaultAsync(department => department.ManagerId == managerId, cancellationToken);
    }

    public void Add(Department department)
    {
        _context.Set<Department>().Add(department);
    }

    public void Update(Department department)
    {
        _context.Set<Department>().Update(department);
    }

    public void Remove(Department department)
    {
        _context.Set<Department>().Remove(department);
    }
}
