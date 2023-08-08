using Domain.Entities.Records;
using Domain.Entities.Users;

namespace Domain.Entities.Middlewares;

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
