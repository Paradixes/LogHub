using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Organisations;

public class Department : Entity<DepartmentId>
{
    private Department() { }

    public UserId ManagerId { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public string? Icon { get; private set; }

    public string? Description { get; private set; }

    public OrganisationId OrganisationId { get; private init; } = null!;

    public static Department Create(
        string name,
        string? icon,
        string? description,
        UserId managerId,
        OrganisationId parentId)
    {
        var department = new Department
        {
            ManagerId = managerId,
            Name = name,
            Icon = icon,
            Description = description,
            OrganisationId = parentId
        };
        return department;
    }

    public void UpdateDetails(string name, string? icon, string? description)
    {
        Name = name;
        Icon = icon;
        Description = description;
    }

    public void UpdateManager(UserId managerId)
    {
        ManagerId = managerId;
    }
}
