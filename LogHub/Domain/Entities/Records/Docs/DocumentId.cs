using Domain.Primitives;

namespace Domain.Entities.Records.Docs;

public record DocumentId(Guid Value) : RecordId(Value);