using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Permissions;

public record RecordPermissionId(Guid Value) : EntityId(Value);