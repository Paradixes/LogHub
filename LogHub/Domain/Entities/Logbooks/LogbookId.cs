using Domain.Primitives;

namespace Domain.Entities.Logbooks;

public record LogbookId(Guid Value) : RecordId(Value);