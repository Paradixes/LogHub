using Domain.Entities.Records;

namespace Domain.Exceptions.Records;

public class RecordNotFoundException : Exception
{
    public RecordNotFoundException(RecordId recordId) :
        base($"Record with id {recordId.Value} was not found.") { }
}
