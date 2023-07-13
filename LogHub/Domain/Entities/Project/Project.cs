using LogHub.Domain.Entities.Organisation;
using LogHub.Domain.Entities.User;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Project;

public class Project : Entity<ProjectId>, IRecordEntity
{
    private Project() { }

    public OrganisationId OrganisationId { get; }

    public UserId CreatorId { get; private init; }

    public string Title { get; private set; }

    public string? Icon { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public static Project Create(UserId creatorId, string title, string? icon, string? description)
    {
        var project = new Project
        {
            Id = new ProjectId(Guid.NewGuid()),
            CreatorId = creatorId,
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
}

public record ProjectUpdatedDomainEvent(Guid Id, ProjectId ProjectId, UserId CreatorId) : DomainEvent(Id);

public record ProjectCreatedDomainEvent(Guid Id, ProjectId ProjectId, UserId ProjectCreatorId) : DomainEvent(Id);
