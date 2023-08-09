using Domain.Primitives;

namespace Domain.Entities.Records;

public record RecordId(Guid Value) : EntityId(Value);
