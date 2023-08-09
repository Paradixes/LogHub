using Domain.Entities.Behaviours.Actions;
using Domain.Entities.Behaviours.Requests;
using Domain.Entities.Middlewares;
using Domain.Entities.Users;
using Domain.Primitives;
using Shared.Enums;

namespace Domain.Entities.Records;

public abstract class Record : Entity<RecordId>, IAuditableEntity
{
    private readonly List<RecordAction> _actions = new();

    private readonly List<RecordCommandHandler> _commandHandlers = new();

    private readonly List<RecordPermission> _permissions = new();

    private readonly List<RecordRequest> _requests = new();

    protected Record() { }

    protected Record(UserId ownerId, string title, string? icon, string? description)
    {
        Title = title;
        Icon = icon;
        Description = description;

        AddPermission(ownerId, PermissionLevel.Owner);
        InitializeCommandHandlers();
    }

    public IEnumerable<RecordRequest> Requests => _requests.AsReadOnly();

    public IEnumerable<RecordAction> Actions => _actions.AsReadOnly();

    public IEnumerable<RecordPermission> Permissions => _permissions.AsReadOnly();

    public IEnumerable<RecordCommandHandler> CommandHandlers => _commandHandlers.AsReadOnly();

    public string Title { get; private set; } = null!;

    public string? Icon { get; private set; }

    public string? Description { get; private set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public void UpdateDetails(string title, string? icon, string? description)
    {
        Title = title;
        Icon = icon;
        Description = description;
    }

    public void AddPermission(UserId userId, PermissionLevel level)
    {
        if (_permissions.Any(p => p.UserId == userId))
        {
            return;
        }

        var permission = new RecordPermission(userId, Id, level);
        _permissions.Add(permission);
    }

    public void UpdatePermission(UserId userId, PermissionLevel level)
    {
        var permission = _permissions.FirstOrDefault(p => p.UserId == userId);
        if (permission is null)
        {
            throw new InvalidOperationException($"RecordPermission for user {userId} does not exist");
        }

        permission.UpdateLevel(level);
    }

    public void RemovePermission(UserId userId)
    {
        var permission = _permissions.FirstOrDefault(p => p.UserId == userId);
        if (permission is null)
        {
            throw new InvalidOperationException($"RecordPermission for user {userId} does not exist");
        }

        _permissions.Remove(permission);
    }

    public void AddRequest(RecordRequestCommand command, UserId initiatorId, UserId handlerId, string message)
    {
        var request = new RecordRequest(Id, command, initiatorId, handlerId, message);
        _requests.Add(request);
    }

    public void ApproveRequest(RecordRequestId requestId)
    {
        var request = _requests.FirstOrDefault(r => r.Id == requestId);
        if (request is null)
        {
            throw new InvalidOperationException($"Request with id {requestId} does not exist");
        }

        request.Approve();
    }

    public void RejectRequest(RecordRequestId requestId)
    {
        var request = _requests.FirstOrDefault(r => r.Id == requestId);
        if (request is null)
        {
            throw new InvalidOperationException($"Request with id {requestId} does not exist");
        }

        request.Reject();
    }

    public void RemoveRequest(RecordRequestId requestId)
    {
        var request = _requests.FirstOrDefault(r => r.Id == requestId);
        if (request is null)
        {
            return;
        }

        _requests.Remove(request);
    }

    public void AddAction(UserId initiatorId, string message)
    {
        var action = new RecordAction(Id, initiatorId, message);
        _actions.Add(action);
    }

    public UserId GetOwnerId()
    {
        var ownerPermission = _permissions.FirstOrDefault(p => p.Level == PermissionLevel.Owner);
        if (ownerPermission is null)
        {
            throw new InvalidOperationException("Owner permission does not exist");
        }

        return ownerPermission.UserId;
    }

    public bool HasPermission(UserId userId, PermissionLevel level, RecordType recordType)
    {
        var permission = _permissions.FirstOrDefault(p => p.UserId == userId);
        if (permission is null)
        {
            return false;
        }

        return permission.Level >= level;
    }

    public void TransferOwnership(UserId oldOwnerId, UserId newOwnerId)
    {
        if (oldOwnerId != GetOwnerId())
        {
            return;
        }

        RemovePermission(oldOwnerId);
        UpdatePermission(newOwnerId, PermissionLevel.Owner);
    }

    private void InitializeCommandHandlers()
    {
        foreach (var command in Enum.GetValues<RecordRequestCommand>())
        {
            var commandHandler = new RecordCommandHandler(Id, PermissionLevel.Owner, command);
            _commandHandlers.Add(commandHandler);
        }
    }

    public void UpdateCommandHandler(RecordRequestCommand command, PermissionLevel level)
    {
        var commandHandler = _commandHandlers.FirstOrDefault(c => c.Command == command);
        if (commandHandler is null)
        {
            throw new InvalidOperationException($"Command handler for command {command} does not exist");
        }

        commandHandler.UpdateLevel(level);
    }
}
