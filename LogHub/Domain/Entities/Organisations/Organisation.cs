using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Organisations;

public class Organisation : Entity<OrganisationId>
{
    private readonly List<DataManagementPlan> _dataManagementPlans = new();

    private readonly List<Department> _departments = new();

    private Organisation() { }

    public IEnumerable<Department> Departments => _departments.ToList();

    public IEnumerable<DataManagementPlan> DataManagementPlans => _dataManagementPlans.ToList();

    public UserId ManagerId { get; private set; } = null!;

    public string InvitationCode { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public string? Icon { get; private set; }

    public string? Description { get; private set; }

    private static string GenerateRandomString(int length)
    {
        var random = new Random();
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(characters, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static Organisation Create(
        string name,
        string? icon,
        UserId creatorId)
    {
        var organisation = new Organisation
        {
            ManagerId = creatorId,
            Name = name,
            Icon = icon,
            InvitationCode = GenerateRandomString(8)
        };

        return organisation;
    }

    public void AddDepartment(
        string name,
        string? icon,
        string? description,
        UserId managerId)
    {
        var department = Department.Create(name, icon, description, managerId, Id);
        _departments.Add(department);
    }

    public void RemoveDepartment(OrganisationId childOrganisationId)
    {
        var department = _departments.SingleOrDefault(x => x.Id == childOrganisationId);
        if (department is null)
        {
            return;
        }

        _departments.Remove(department);
    }

    public void AddDataManagementPlan(
        UserId? managerId,
        string title,
        string? icon,
        string? description)
    {
        managerId ??= ManagerId;

        var dataManagementPlan = new DataManagementPlan(Id, managerId, title, icon, description);
        _dataManagementPlans.Add(dataManagementPlan);
    }

    public void RemoveDataManagementPlan(RecordId recordId)
    {
        var dataManagementPlan = _dataManagementPlans.SingleOrDefault(x => x.Id == recordId);
        if (dataManagementPlan is null)
        {
            return;
        }

        _dataManagementPlans.Remove(dataManagementPlan);
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
