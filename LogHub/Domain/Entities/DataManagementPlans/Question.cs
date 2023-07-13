using LogHub.Domain.DomainEvents.DataManagementPlans;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.DataManagementPlans;

public class Question : Entity<QuestionId>, IRecordEntity
{
    private Question() { }

    public string? Answer { get; private set; }

    public UserId CreatorId { get; private init; }

    public string Title { get; private set; }

    public string? Icon { get; private set; }

    public string? Description { get; private set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public void UpdateDetails(string title, string? icon, string? description)
    {
        if (Title != title || Icon != icon || Description != description)
        {
            Raise(new QuestionDetailsUpdatedDomainEvent(Guid.NewGuid(), Id));
        }

        Title = title;
        Icon = icon;
        Description = description;
    }

    public static Question Create(UserId creatorId, string title, string? icon, string? description)
    {
        var question = new Question
        {
            Id = new QuestionId(Guid.NewGuid()),
            CreatorId = creatorId,
            Title = title,
            Icon = icon,
            Description = description
        };

        question.Raise(new QuestionCreatedDomainEvent(Guid.NewGuid(), creatorId, question.Id));

        return question;
    }

    public void UpdateAnswer(string answer)
    {
        if (Answer != answer)
        {
            Raise(new QuestionAnswerUpdatedDomainEvent(Guid.NewGuid(), Id));
        }

        Answer = answer;
    }
}