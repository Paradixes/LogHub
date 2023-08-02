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
        DepartmentId? departmentId,
        UserId creatorId,
        string title,
        string? description)
    {
        OrganisationId = organisationId;
        DepartmentId = departmentId;
        CreatorId = creatorId;
        Title = title;
        Description = description;
    }

    protected DataManagementPlanTemplate(DataManagementPlanTemplate template)
    {
        OrganisationId = template.OrganisationId;
        DepartmentId = template.DepartmentId;
        CreatorId = template.CreatorId;
        Title = template.Title;
        Description = template.Description;

        foreach (var question in template.Questions)
        {
            AddQuestion(question.Title, question.Description);
        }
    }

    public string? Description { get; }

    public string Title { get; } = null!;

    public UserId? CreatorId { get; }

    public IEnumerable<Question> Questions => _questions;

    public OrganisationId? OrganisationId { get; }

    public DepartmentId? DepartmentId { get; }

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
