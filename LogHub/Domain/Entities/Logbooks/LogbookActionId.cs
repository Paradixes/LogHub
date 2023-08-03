using Domain.Entities.Actions;

namespace Domain.Entities.Logbooks;

public record LogbookActionId(Guid Value) : RecordActionId(Value);