using Domain.Primitives;

namespace Domain.Entities.Bases;

public record LabelId(Guid Value) : EntityId(Value);