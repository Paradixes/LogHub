using LogHub.Domain.Entities.Actions;

namespace LogHub.Domain.Entities.DataManagementPlans;

public record DmpActionId(Guid Value) : RecordActionId(Value);