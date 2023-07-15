using LogHub.Domain.DomainEvents.Logbooks;
using LogHub.Domain.Entities.Projects;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Logbooks;

public class Logbook : Entity<LogbookId>, IRecordEntity
{
    private Logbook() { }

    public ProjectId ProjectId { get; private set; }

    public string? CoverImage { get; private set; }

    public Importance Importance { get; private set; }

    public UserId CreatorId { get; private set; }

    public string Title { get; private set; }

    public string? Icon { get; private set; }

    public string? Description { get; private set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public static Logbook Create(UserId creatorId, ProjectId projectId, string title, string? icon, string? description,
        string? coverImage, Importance importance)
    {
        var logbook = new Logbook
        {
            Id = new LogbookId(Guid.NewGuid()),
            CreatorId = creatorId,
            ProjectId = projectId,
            Title = title,
            Icon = icon,
            Description = description,
            CoverImage = coverImage,
            Importance = importance
        };

        logbook.Raise(new LogbookCreatedDomainEvent(
            Guid.NewGuid(),
            logbook.Id,
            logbook.CreatorId));

        return logbook;
    }

    public void UpdateDetails(string title, string? icon, string? description, string? coverImage,
        Importance importance)
    {
        if (Title != title || Icon != icon || Description != description || CoverImage != coverImage ||
            Importance != importance)
        {
            Raise(new LogbookDetailsUpdatedDomainEvent(Guid.NewGuid(), Id));
        }

        Title = title;
        Icon = icon;
        Description = description;
        CoverImage = coverImage;
        Importance = importance;
    }

    public void UpdateCoverImage(string coverImage)
    {
        if (CoverImage != coverImage)
        {
            Raise(new LogbookCoverImageUpdatedDomainEvent(Guid.NewGuid(), Id));
        }

        CoverImage = coverImage;
    }

    public void UpdateImportance(Importance importance)
    {
        if (Importance != importance)
        {
            Raise(new LogbookImportanceUpdatedDomainEvent(Guid.NewGuid(), Id));
        }

        Importance = importance;
    }
}
