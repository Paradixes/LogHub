namespace LogHub.Domain.Entities.DataManagementPlans;

public class DataManagementPlan : DataManagementPlanTemplate
{
    private DataManagementPlan() { }

    public DataManagementPlan(DataManagementPlanTemplate template)
        : base(template.OrganisationId, template.CreatorId, template.Title, template.Description)
    {
        foreach (var question in template.Questions)
        {
            AddQuestion(question.Title, question.Description);
        }
    }

    public void UpdateAnswerById(QuestionId questionId, string answer)
    {
        var question = Questions.FirstOrDefault(q => q.Id == questionId);

        if (question is null)
        {
            return;
        }

        question.UpdateAnswer(answer);
    }
}
