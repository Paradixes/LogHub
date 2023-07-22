using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Actions;

public record RecordActionId(Guid Value) : EntityId(Value);
