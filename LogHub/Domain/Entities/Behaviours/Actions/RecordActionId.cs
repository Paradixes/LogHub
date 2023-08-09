using Domain.Primitives;

namespace Domain.Entities.Behaviours.Actions;

public record RecordActionId(Guid Value) : EntityId(Value);