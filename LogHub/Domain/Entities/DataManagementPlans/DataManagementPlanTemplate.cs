using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.DataManagementPlans;

public class DataManagementPlanTemplate : Entity<DmpId>, IAuditableEntity
{
    private readonly List<Question> _questions = new();

    protected DataManagementPlanTemplate() { }

    public DataManagementPlanTemplate(
        OrganisationId organisationId,
        UserId creatorId,
        string title,
        string? description)
    {
        OrganisationId = organisationId;
        CreatorId = creatorId;
        Title = title;
        Description = description;
    }

    public string? Description { get; private set; }

    public string Title { get; private set; } = null!;

    public UserId? CreatorId { get; private init; }

    public IEnumerable<Question> Questions => _questions;

    public OrganisationId? OrganisationId { get; private init; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

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
