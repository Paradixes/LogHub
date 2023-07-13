using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Permission;

public record PermissionId(Guid Value) : EntityId(Value);