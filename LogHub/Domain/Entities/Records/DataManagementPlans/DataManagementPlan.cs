using Domain.Entities.Records.Repositories;
using Domain.Entities.Users;

namespace Domain.Entities.Records.DataManagementPlans;

public class DataManagementPlan : DataManagementPlanTemplate
{
    private DataManagementPlan() { }

    public DataManagementPlan(
        DataManagementPlanTemplate template,
        RecordId repositoryId,
        UserId creatorId)
        : base(template, creatorId)
    {
        RepositoryId = repositoryId;
    }

    public RecordId RepositoryId { get; private set; } = null!;

    public Repository? Repository { get; private set; }

    public void UpdateAnswerByIndex(int i, string answer)
    {
        if (i < 0 || i >= _questions.Count)
        {
            throw new IndexOutOfRangeException();
        }

        var question = _questions[i];

        question.UpdateAnswer(answer);
    }
}
