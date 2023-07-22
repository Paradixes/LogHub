using LogHub.Domain.Entities.Requests;

namespace LogHub.Domain.Entities.DataManagementPlans;

public record DmpRequestId(Guid Value) : RecordRequestId(Value);