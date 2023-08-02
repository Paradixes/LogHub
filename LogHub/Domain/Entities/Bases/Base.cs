using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Bases;

public class Base : RecordEntity<BaseId, BaseActionId, BasePermissionId, BaseRequestId>
{
    private readonly List<Label> _labels = new();

    private Base() { }

    internal Base(
        string title,
        string? icon,
        string? description,
        UserId creatorId,
        OrganisationId organisationId,
        DepartmentId? departmentId)
        : base(creatorId, title, icon, description)
    {
        OrganisationId = organisationId;
        DepartmentId = departmentId;
    }

    public IEnumerable<Label> Labels => _labels.AsReadOnly();

    public OrganisationId OrganisationId { get; private set; } = null!;

    public DepartmentId? DepartmentId { get; private set; }

    public bool IsFinished { get; private set; }

    public DmpId DmpId { get; private set; } = null!;

    public void AddLabel(string name, string color)
    {
        var label = new Label(Id, name, color);
        _labels.Add(label);
    }

    public void UpdateLabel(LabelId labelId, string name, string color)
    {
        var label = _labels.FirstOrDefault(l => l.Id == labelId);
        if (label is null)
        {
            throw new InvalidOperationException($"Label with id {labelId} does not exist");
        }

        label.Update(name, color);
    }

    public void RemoveLabel(LabelId labelId)
    {
        var label = _labels.FirstOrDefault(l => l.Id == labelId);
        if (label is null)
        {
            throw new InvalidOperationException($"Label with id {labelId} does not exist");
        }

        _labels.Remove(label);
    }

    public void Finish()
    {
        IsFinished = true;
    }

    public void SetDepartmentId(DepartmentId? departmentId)
    {
        DepartmentId = departmentId;
    }
}
