using Domain.Primitives;

namespace Domain.Entities.DataManagementPlans;

public record DmpId(Guid Value) : RecordId(Value);