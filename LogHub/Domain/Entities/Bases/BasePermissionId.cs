using LogHub.Domain.Entities.Permissions;

namespace LogHub.Domain.Entities.Bases;

public record BasePermissionId(Guid Value) : RecordPermissionId(Value);