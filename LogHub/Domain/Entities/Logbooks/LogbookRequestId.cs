using Domain.Entities.Requests;

namespace Domain.Entities.Logbooks;

public record LogbookRequestId(Guid Value) : RecordRequestId(Value);