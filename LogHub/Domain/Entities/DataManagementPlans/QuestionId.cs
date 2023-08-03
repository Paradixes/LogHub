using Domain.Primitives;

namespace Domain.Entities.DataManagementPlans;

public record QuestionId(Guid Value) : RecordId(Value);