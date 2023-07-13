using LogHub.Domain.DomainEvents.DataManagementPlans;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.DataManagementPlans;

public class DataManagementPlan : Entity<DataManagementPlanId>, IRecordEntity
{
    private readonly List<Question> _questions = new();
    private DataManagementPlan() { }

    public IReadOnlyCollection<Question> Questions => _questions;

    public UserId CreatorId { get; private init; }

    public string Title { get; private set; }

    public string? Icon { get; private set; }

    public string? Description { get; private set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public static IRecordEntity Create(UserId creatorId, string title, string? icon, string? description)
    {
        var dataManagementPlan = new DataManagementPlan
        {
            CreatorId = creatorId,
            Title = title,
            Icon = icon,
            Description = description
        };

        dataManagementPlan.Raise(
            new DataManagementPlanCreatedDomainEvent(Guid.NewGuid(), creatorId, dataManagementPlan.Id));

        return dataManagementPlan;
    }

    public void UpdateDetails(string title, string? icon, string? description)
    {
        if (Title != title || Icon != icon || Description != description)
        {
            Raise(new DataManagementPlanDetailsUpdatedDomainEvent(Guid.NewGuid(), Id));
        }

        Title = title;
        Icon = icon;
        Description = description;
    }

    public void AddQuestion(UserId creatorId, string title, string icon, string description)
    {
        var question = Question.Create(creatorId, title, icon, description);

        _questions.Add(question);

        Raise(new QuestionAddedDomainEvent(Guid.NewGuid(), Id, question.Id));
    }

    public void RemoveQuestion(QuestionId questionId)
    {
        var question = _questions.FirstOrDefault(q => q.Id == questionId);

        if (question is null)
        {
            return;
        }

        _questions.Remove(question);

        Raise(new QuestionRemovedDomainEvent(Guid.NewGuid(), Id, questionId));
    }
}