using Domain.Primitives;

namespace Domain.Entities.Records.Labels;

public record LabelId(Guid Value) : EntityId(Value);