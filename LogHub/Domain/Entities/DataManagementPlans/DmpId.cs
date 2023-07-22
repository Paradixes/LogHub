using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.DataManagementPlans;

public record DmpId(Guid Value) : RecordId(Value);