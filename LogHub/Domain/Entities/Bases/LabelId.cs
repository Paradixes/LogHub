using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Bases;

public record LabelId(Guid Value) : EntityId(Value);
