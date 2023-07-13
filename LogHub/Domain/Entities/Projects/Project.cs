using LogHub.Domain.DomainEvents.Projects;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Permissions;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Projects;

public class Project : Entity<ProjectId>, IRecordEntity
{
    private readonly List<ProjectAction> _actions = new();

    private readonly List<Permission> _permissions = new();

    private readonly List<ProjectRequest> _requests = new();

    private Project() { }

    public IReadOnlyCollection<Permission> Permissions => _permissions.AsReadOnly();

    public IReadOnlyCollection<ProjectRequest> Requests => _requests.AsReadOnly();

    public IReadOnlyCollection<ProjectAction> Actions => _actions.AsReadOnly();

    public OrganisationId OrganisationId { get; private set; }

    public UserId CreatorId { get; private set; }

    public string Title { get; private set; }

    public string? Icon { get; private set; }

    public string? Description { get; private set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public static Project Create(UserId creatorId, OrganisationId organisationId, string title, string? icon,
        string? description)
    {
        var project = new Project
        {
            Id = new ProjectId(Guid.NewGuid()),
            CreatorId = creatorId,
            OrganisationId = organisationId,
            Title = title,
            Icon = icon,
            Description = description,
            CreatedOnUtc = DateTime.UtcNow
        };

        project.Raise(new ProjectCreatedDomainEvent(
            Guid.NewGuid(),
            project.Id,
            project.CreatorId));

        return project;
    }

    public void Update(string title, string? icon, string? description)
    {
        if (Title != title || Icon != icon || Description != description)
        {
            Raise(new ProjectUpdatedDomainEvent(
                Guid.NewGuid(),
                Id,
                CreatorId));
        }

        Title = title;
        Icon = icon;
        Description = description;
    }

    public void TransferOwnership(UserId newOwnerId, OrganisationId newOrganisationId)
    {
        if (CreatorId != newOwnerId || OrganisationId != newOrganisationId)
        {
            Raise(new ProjectOwnershipTransferredDomainEvent(
                Guid.NewGuid(),
                Id,
                CreatorId,
                newOwnerId));
        }

        CreatorId = newOwnerId;
        OrganisationId = newOrganisationId;
    }
}