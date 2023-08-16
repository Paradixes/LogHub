using Domain.Entities.Records;
using Domain.Entities.Users;

namespace Domain.Exceptions.Records;

public class RecordPermissionAlreadyExistsException : Exception
{
    public RecordPermissionAlreadyExistsException(RecordId recordId, UserId userId)
        : base($"Record permission already exists for record {recordId.Value} and user {userId.Value}") { }
}
