using Domain.Primitives;

namespace Domain.Entities.Permissions;

public record RecordPermissionId(Guid Value) : EntityId(Value);