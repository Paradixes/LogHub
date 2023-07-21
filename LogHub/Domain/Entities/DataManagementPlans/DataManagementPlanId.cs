using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.DataManagementPlans;

public record DataManagementPlanId(Guid Value) : RecordId(Value);