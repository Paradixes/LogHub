using LogHub.Domain.Entities.Permissions;

namespace LogHub.Domain.Entities.DataManagementPlans;

public record DmpPermissionId(Guid Value) : RecordPermissionId(Value);