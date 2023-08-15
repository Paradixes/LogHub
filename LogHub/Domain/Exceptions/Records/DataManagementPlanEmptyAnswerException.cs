using Domain.Entities.Records.DataManagementPlans;

namespace Domain.Exceptions.Records;

public class DataManagementPlanEmptyAnswerException : Exception
{
    public DataManagementPlanEmptyAnswerException(QuestionId id) :
        base($"Data management plan question with id {id.Value} has an empty answer.") { }
}
