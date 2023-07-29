using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;
using LogHub.Shared.Enums;

namespace LogHub.Domain.Entities.Logbooks;

public class Logbook : RecordEntity<LogbookId, LogbookActionId, LogbookPermissionId, LogbookRequestId>
{
    private Logbook() { }

    internal Logbook(
        UserId ownerId,
        BaseId baseId,
        string title,
        string? icon,
        string? description,
        string? coverImage,
        Importance importance)
        : base(ownerId, title, icon, description)
    {
        BaseId = baseId;
        CoverImage = coverImage;
        Importance = importance;
    }

    public BaseId BaseId { get; private set; } = null!;

    public string? CoverImage { get; private set; }

    public Importance Importance { get; private set; }

    public void UpdateCoverImage(string coverImage)
    {
        CoverImage = coverImage;
    }

    public void UpdateImportance(Importance importance)
    {
        Importance = importance;
    }
}