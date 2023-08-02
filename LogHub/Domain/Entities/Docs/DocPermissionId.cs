using Domain.Entities.Permissions;

namespace Domain.Entities.Docs;

public record DocPermissionId(Guid Value) : RecordPermissionId(Value);