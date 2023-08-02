using Domain.Primitives;

namespace Domain.Entities.DataManagementPlans;

public class Question : Entity<QuestionId>
{
    private Question() { }

    public DmpId DmpId { get; private init; } = null!;

    public string Title { get; private init; } = null!;

    public string? Description { get; private init; }

    public string? Answer { get; private set; }

    public static Question Create(
        DmpId dmpId,
        string title,
        string? description)
    {
        var question = new Question
        {
            DmpId = dmpId,
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