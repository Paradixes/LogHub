using LogHub.Domain.Entities.Users;

namespace LogHub.Domain.Entities.Docs;

public class FavouriteDoc
{
    internal FavouriteDoc(UserId userId, DocumentId docId)
    {
        UserId = userId;
        DocId = docId;
    }

    public UserId UserId { get; set; }

    public DocumentId DocId { get; set; }
}
