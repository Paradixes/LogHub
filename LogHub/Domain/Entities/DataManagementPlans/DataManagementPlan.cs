namespace Domain.Entities.DataManagementPlans;

public class DataManagementPlan : DataManagementPlanTemplate
{
    private DataManagementPlan() { }

    public DataManagementPlan(DataManagementPlanTemplate template)
        : base(template) { }

    public void UpdateAnswerById(QuestionId questionId, string answer)
    {
        var question = Questions.FirstOrDefault(q => q.Id == questionId);

        question?.UpdateAnswer(answer);
    }
}