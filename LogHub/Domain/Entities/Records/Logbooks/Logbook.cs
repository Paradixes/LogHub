using Domain.Entities.Records.Docs;
using Domain.Entities.Records.Repositories;
using Domain.Entities.Users;
using Shared.Enums;

namespace Domain.Entities.Records.Logbooks;

public class Logbook : Record
{
    private readonly List<Document> _documents = new();

    private Logbook() { }

    internal Logbook(
        UserId ownerId,
        RepositoryId repositoryId,
        string title,
        string? icon,
        string? description,
        string? coverImage,
        Importance importance)
        : base(ownerId, title, icon, description)
    {
        RepositoryId = repositoryId;
        CoverImage = coverImage;
        Importance = importance;
    }

    public IEnumerable<Document> Documents => _documents.AsReadOnly();

    public RecordId RepositoryId { get; private set; } = null!;

    public Repository? Repository { get; private set; }

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
