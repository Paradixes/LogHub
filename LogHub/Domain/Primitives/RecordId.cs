namespace LogHub.Domain.Primitives;

public record RecordId(Guid Value) : EntityId(Value);
