using LogHub.Domain.Entities.Actions;

namespace LogHub.Domain.Entities.Logbooks;

public record LogbookActionId(Guid Value) : RecordActionId(Value);