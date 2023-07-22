using LogHub.Domain.Entities.Requests;

namespace LogHub.Domain.Entities.Logbooks;

public record LogbookRequestId(Guid Value) : RecordRequestId(Value);