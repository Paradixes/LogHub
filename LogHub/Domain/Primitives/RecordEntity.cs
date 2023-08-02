using Domain.Entities.Actions;
using Domain.Entities.Permissions;
using Domain.Entities.Requests;
using Domain.Entities.Users;
using Shared.Enums;

namespace Domain.Primitives;

public abstract class RecordEntity<TId, TActionId, TPermissionId, TRequestId> : Entity<TId>, IAuditableEntity
    where TId : RecordId
    where TActionId : RecordActionId
    where TPermissionId : RecordPermissionId
    where TRequestId : RecordRequestId
{
    private readonly List<RecordAction<TActionId, TId>> _actions = new();

    private readonly List<RecordPermission<TPermissionId, TId>> _permissions = new();

    private readonly List<RecordRequest<TRequestId, TId>> _requests = new();

    protected RecordEntity() { }

    protected RecordEntity(UserId ownerId, string title, string? icon, string? description)
    {
        Title = title;
        Icon = icon;
        Description = description;

        AddPermission(ownerId, PermissionLevel.Owner);
    }

    public IEnumerable<RecordRequest<TRequestId, TId>> Requests => _requests.AsReadOnly();

    public IEnumerable<RecordAction<TActionId, TId>> Actions => _actions.AsReadOnly();

    public IEnumerable<RecordPermission<TPermissionId, TId>> Permissions => _permissions.AsReadOnly();

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

        var permission = new RecordPermission<TPermissionId, TId>(userId, Id, level);
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

    public void AddRequest(UserId initiatorId, UserId handlerId, string message)
    {
        var request = new RecordRequest<TRequestId, TId>(Id, initiatorId, handlerId, message);
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
        var action = new RecordAction<TActionId, TId>(Id, initiatorId, message);
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
}