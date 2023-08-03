using Domain.Entities.Permissions;

namespace Domain.Entities.Logbooks;

public record LogbookPermissionId(Guid Value) : RecordPermissionId(Value);