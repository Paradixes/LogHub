using Domain.Entities.Users;
using Domain.Primitives;

namespace Domain.Entities.Organisations;

public class Department : Entity<DepartmentId>
{
    private Department() { }

    public UserId ManagerId { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public Uri? LogoUri { get; private set; }

    public string? Description { get; private set; }

    public OrganisationId OrganisationId { get; private init; } = null!;

    public static Department Create(
        string name,
        string? description,
        UserId managerId,
        OrganisationId parentId)
    {
        var department = new Department
        {
            ManagerId = managerId,
            Name = name,
            Description = description,
            OrganisationId = parentId
        };
        return department;
    }

    public void UpdateDetails(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public void UpdateLogo(Uri? logoUri)
    {
        LogoUri = logoUri;
    }

    public void UpdateManager(UserId managerId)
    {
        ManagerId = managerId;
    }
}