using Domain.Entities.Organisations;
using Domain.Entities.Users;

namespace Domain.Entities.Records.DataManagementPlans;

public class DataManagementPlanTemplate : Record
{
    private readonly List<Question> _questions = new();

    protected DataManagementPlanTemplate() { }

    private DataManagementPlanTemplate(
        OrganisationId organisationId,
        UserId creatorId,
        string title,
        string? icon,
        string? description)
        : base(creatorId, title, icon, description)
    {
        OrganisationId = organisationId;
    }

    protected DataManagementPlanTemplate(DataManagementPlanTemplate template)
    {
        OrganisationId = template.OrganisationId;

        foreach (var question in template.Questions)
        {
            AddQuestion(question.Title, question.Description);
        }
    }


    public IEnumerable<Question> Questions => _questions;

    public OrganisationId? OrganisationId { get; }

    public Organisation? Organisation { get; private set; }

    public static DataManagementPlanTemplate Create(
        OrganisationId organisationId,
        UserId creatorId,
        string title,
        string? icon,
        string? description)
    {
        return new DataManagementPlanTemplate(organisationId, creatorId, title, icon, description);
    }

    public void AddQuestion(string title, string? description)
    {
        var question = Question.Create((Id as DataManagementPlanId)!, title, description);

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
