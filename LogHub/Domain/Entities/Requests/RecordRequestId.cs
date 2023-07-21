using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Requests;

public record RecordRequestId(Guid Value) : EntityId(Value);
