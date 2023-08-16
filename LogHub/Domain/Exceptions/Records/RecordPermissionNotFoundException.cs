using Domain.Entities.Records;
using Domain.Entities.Users;
using Shared.Enums;

namespace Domain.Exceptions.Records;

public class RecordPermissionNotFoundException : Exception
{
    public RecordPermissionNotFoundException(RecordId recordId, UserId uerId) :
        base($"Record permission not found for record {recordId.Value} and user {uerId}") { }

    public RecordPermissionNotFoundException(RecordId recordId, PermissionLevel level) :
        base($"Record permission not found for record {recordId.Value} and level {level}") { }
}
