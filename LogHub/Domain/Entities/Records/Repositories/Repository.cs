using Domain.Entities.Organisations;
using Domain.Entities.Records.DataManagementPlans;
using Domain.Entities.Records.Labels;
using Domain.Entities.Records.Logbooks;
using Domain.Entities.Users;

namespace Domain.Entities.Records.Repositories;

public class Repository : Record
{
    private readonly List<Label> _labels = new();

    private readonly List<Logbook> _logbooks = new();

    private Repository() { }

    public Repository(
        string title,
        string? icon,
        string? description,
        UserId creatorId,
        OrganisationId? organisationId)
        : base(creatorId, title, icon, description)
    {
        OrganisationId = organisationId;
    }

    public IEnumerable<Label> Labels => _labels.AsReadOnly();

    public IEnumerable<Logbook> Logbooks => _logbooks.AsReadOnly();

    public OrganisationId? OrganisationId { get; private set; }

    public Organisation? Organisation { get; private set; }

    public bool IsFinished { get; private set; }

    public RecordId DataManagementPlanId { get; private set; } = null!;

    public DataManagementPlan? DataManagementPlan { get; private set; }

    public void UpdateDataManagementPlan(DataManagementPlan dataManagementPlan)
    {
        DataManagementPlanId = dataManagementPlan.Id;
        DataManagementPlan = dataManagementPlan;
    }

    public void AddLabel(string name, string color)
    {
        var label = new Label((Id as RepositoryId)!, name, color);
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
}
