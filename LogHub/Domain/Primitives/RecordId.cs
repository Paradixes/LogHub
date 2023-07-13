namespace LogHub.Domain.Primitives;

public abstract record RecordId(Guid Value) : EntityId(Value);