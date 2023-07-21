using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Docs;

public record DocumentId(Guid Value) : RecordId(Value);