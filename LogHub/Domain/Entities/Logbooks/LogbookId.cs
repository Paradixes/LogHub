using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Logbooks;

public record LogbookId(Guid Value) : EntityId(Value);