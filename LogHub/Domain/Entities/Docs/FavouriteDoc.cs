using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Docs;

public class FavouriteDoc
{
    internal FavouriteDoc(UserId userId, RecordId docId)
    {
        UserId = userId;
        DocId = docId;
    }

    public UserId UserId { get; set; }

    public RecordId DocId { get; set; }
}
