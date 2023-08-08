using Domain.Primitives;

namespace Domain.Entities.Records.DataManagementPlans;

public record QuestionId(Guid Value) : RecordId(Value);