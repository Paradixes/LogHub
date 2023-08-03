using Domain.Entities.Organisations;
using Domain.Entities.Users;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly LogHubDbContext _context;

    public DepartmentRepository(LogHubDbContext context)
    {
        _context = context;
    }

    public Task<Department?> GetByIdAsync(DepartmentId id)
    {
        return _context
            .Set<Department>()
            .FirstOrDefaultAsync(department => department.Id == id);
    }

    public Task<Department?> GetByManagerIdAsync(UserId managerId)
    {
        return _context.Departments
            .FirstOrDefaultAsync(department => department.ManagerId == managerId);
    }

    public void Add(Department department)
    {
        _context.Departments.Add(department);
    }

    public void Update(Department department)
    {
        _context.Departments.Update(department);
    }

    public void Remove(Department department)
    {
        _context.Departments.Remove(department);
    }

    public List<Department> GetByOrganisationId(OrganisationId organisationId)
    {
        return _context.Departments
            .Where(department => department.OrganisationId == organisationId)
            .ToList();
    }
}