using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Organisations;

public class Organisation : Entity<OrganisationId>
{
    private readonly List<DataManagementPlanTemplate> _dataManagementPlanTemplates = new();

    private readonly List<Department> _departments = new();

    private Organisation() { }

    public IEnumerable<Department> Departments => _departments.ToList();

    public IEnumerable<DataManagementPlanTemplate> DataManagementPlanTemplates => _dataManagementPlanTemplates.ToList();

    public UserId ManagerId { get; private set; } = null!;

    public string InvitationCode { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public Uri? LogoUri { get; private set; }

    public string? Description { get; private set; }

    private static string GenerateRandomString(int length)
    {
        var random = new Random();
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(characters, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static Organisation Create(
        UserId creatorId,
        string name,
        string? description)
    {
        var organisation = new Organisation
        {
            ManagerId = creatorId,
            Name = name,
            Description = description,
            InvitationCode = GenerateRandomString(8)
        };

        return organisation;
    }

    public void UpdateInvitationCode()
    {
        InvitationCode = GenerateRandomString(8);
    }

    public void AddDepartment(
        string name,
        string? description,
        UserId managerId)
    {
        var department = Department.Create(name, description, managerId, Id);
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

    public void AddDataManagementPlanTemplate(
        UserId? managerId,
        string title,
        string? description)
    {
        managerId ??= ManagerId;

        var dataManagementPlanTemplate = new DataManagementPlanTemplate(Id, null, managerId, title, description);
        _dataManagementPlanTemplates.Add(dataManagementPlanTemplate);
    }

    public void RemoveDataManagementPlanTemplate(RecordId recordId)
    {
        var dataManagementPlan = _dataManagementPlanTemplates.SingleOrDefault(x => x.Id == recordId);
        if (dataManagementPlan is null)
        {
            return;
        }

        _dataManagementPlanTemplates.Remove(dataManagementPlan);
    }

    public void UpdateDetails(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public void SetLogo(Uri logoUri)
    {
        LogoUri = logoUri;
    }

    public void UpdateManager(UserId managerId)
    {
        ManagerId = managerId;
    }
}
