using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.DataManagementPlan;

public record QuestionId(Guid Value) : RecordId(Value);