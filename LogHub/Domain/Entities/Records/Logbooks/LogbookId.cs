using Domain.Primitives;

namespace Domain.Entities.Records.Logbooks;

public record LogbookId(Guid Value) : RecordId(Value);