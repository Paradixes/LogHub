using LogHub.Domain.Entities.Permissions;

namespace LogHub.Domain.Entities.Logbooks;

public record LogbookPermissionId(Guid Value) : RecordPermissionId(Value);