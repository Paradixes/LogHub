using Domain.Primitives;

namespace Domain.Entities.Events.Actions;

public record RecordActionId(Guid Value) : EntityId(Value);