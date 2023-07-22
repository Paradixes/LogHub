using LogHub.Domain.Entities.Permissions;

namespace LogHub.Domain.Entities.Docs;

public record DocPermissionId(Guid Value) : RecordPermissionId(Value);