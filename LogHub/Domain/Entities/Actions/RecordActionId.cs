using Domain.Primitives;

namespace Domain.Entities.Actions;

public record RecordActionId(Guid Value) : EntityId(Value);