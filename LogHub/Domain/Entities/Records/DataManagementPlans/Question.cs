using Domain.Primitives;

namespace Domain.Entities.Records.DataManagementPlans;

public class Question : Entity<QuestionId>
{
    private Question() { }

    public RecordId DataManagementPlanId { get; private init; } = null!;

    public DataManagementPlanTemplate DataManagementPlanTemplate { get; private set; } = null!;

    public string Title { get; private set; } = null!;

    public string? Description { get; private set; }

    public string? Answer { get; private set; }

    public static Question Create(
        RecordId dataManagementPlanId,
        string title,
        string? description)
    {
        var question = new Question
        {
            DataManagementPlanId = dataManagementPlanId,
            Title = title,
            Description = description
        };

        return question;
    }

    public void UpdateAnswer(string answer)
    {
        Answer = answer;
    }

    public void UpdateDetails(string title, string? description)
    {
        Title = title;
        Description = description;
    }
}
