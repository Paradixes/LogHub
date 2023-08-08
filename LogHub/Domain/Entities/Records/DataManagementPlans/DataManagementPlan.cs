using Domain.Entities.Records.Repositories;

namespace Domain.Entities.Records.DataManagementPlans;

public class DataManagementPlan : DataManagementPlanTemplate
{
    private DataManagementPlan() { }

    public DataManagementPlan(DataManagementPlanTemplate template, RecordId repositoryId)
        : base(template)
    {
        RepositoryId = repositoryId;
    }

    public RecordId RepositoryId { get; private set; } = null!;

    public Repository? Repository { get; private set; }

    public void UpdateAnswerById(QuestionId questionId, string answer)
    {
        var question = Questions.FirstOrDefault(q => q.Id == questionId);

        question?.UpdateAnswer(answer);
    }
}
