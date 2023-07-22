using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.DataManagementPlans;

public record QuestionId(Guid Value) : RecordId(Value);