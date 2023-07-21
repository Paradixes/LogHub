using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Permissions;

public record PermissionId(Guid Value) : EntityId(Value);
