using Domain.Entities.Permissions;

namespace Domain.Entities.Bases;

public record BasePermissionId(Guid Value) : RecordPermissionId(Value);