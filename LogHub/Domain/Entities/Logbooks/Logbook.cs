using LogHub.Domain.Entities.Users;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Logbooks;

public class Logbook : RecordEntity
{
    private Logbook() { }

    internal Logbook(
        UserId ownerId,
        RecordId baseId,
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

    public RecordId BaseId { get; private set; } = null!;

    public string? CoverImage { get; private set; }

    public Importance Importance { get; private set; }

    public override RecordType RecordType { get; protected init; } = RecordType.Logbook;

    public void UpdateCoverImage(string coverImage)
    {
        CoverImage = coverImage;
    }

    public void UpdateImportance(Importance importance)
    {
        Importance = importance;
    }
}
