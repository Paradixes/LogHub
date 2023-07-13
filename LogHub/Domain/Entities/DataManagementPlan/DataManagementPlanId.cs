using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.DataManagementPlan;

public record DataManagementPlanId(Guid Value) : RecordId(Value);