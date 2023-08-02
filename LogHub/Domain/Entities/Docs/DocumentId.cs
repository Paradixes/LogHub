using Domain.Primitives;

namespace Domain.Entities.Docs;

public record DocumentId(Guid Value) : RecordId(Value);