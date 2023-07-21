using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.DataManagementPlans;

public class DataManagementPlan : RecordEntity<DataManagementPlanId>
{
    private readonly List<Question> _questions = new();

    private DataManagementPlan() { }

    public DataManagementPlan(
        OrganisationId organisationId,
        UserId creatorId,
        string title,
        string? icon,
        string? description)
        : base(creatorId, title, icon, description)
    {
        OrganisationId = organisationId;
    }

    public IEnumerable<Question> Questions => _questions;

    public OrganisationId OrganisationId { get; private set; } = null!;

    public override RecordType RecordType { get; protected init; } = RecordType.DataManagementPlan;

    public void AddQuestion(string title, string? description)
    {
        var question = Question.Create(Id, title, description);

        _questions.Add(question);
    }

    public void RemoveQuestion(QuestionId questionId)
    {
        var question = _questions.FirstOrDefault(q => q.Id == questionId);

        if (question is null)
        {
            return;
        }

        _questions.Remove(question);
    }
}
