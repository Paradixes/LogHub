using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.DataManagementPlans;

public class Question : Entity<QuestionId>
{
    private Question() { }

    public DataManagementPlanId DataManagementPlanId { get; private init; } = null!;

    public string Title { get; private init; } = null!;

    public string? Description { get; private init; }

    public string? Answer { get; private set; }

    public static Question Create(
        DataManagementPlanId dataManagementPlanId,
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
}
