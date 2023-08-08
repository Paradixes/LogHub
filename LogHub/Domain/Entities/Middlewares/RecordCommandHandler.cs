using Domain.Entities.Records;
using Shared.Enums;

namespace Domain.Entities.Middlewares;

public class RecordCommandHandler
{
    private RecordCommandHandler() { }

    internal RecordCommandHandler(
        RecordId recordId,
        PermissionLevel permissionLevel,
        RecordRequestCommand command)
    {
        RecordId = recordId;
        Level = permissionLevel;
        Command = command;
    }

    public RecordId RecordId { get; private init; } = null!;

    public Record? Record { get; private set; }

    public PermissionLevel Level { get; private set; } = PermissionLevel.Owner;

    public RecordRequestCommand Command { get; private set; }

    public void UpdateLevel(PermissionLevel level)
    {
        Level = level;
    }
}
