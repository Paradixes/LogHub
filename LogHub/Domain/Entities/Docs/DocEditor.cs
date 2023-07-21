using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Docs;

public class DocEditor
{
    internal DocEditor(RecordId docId, UserId userId)
    {
        DocId = docId;
        UserId = userId;
    }

    public RecordId DocId { get; private set; }

    public UserId UserId { get; private set; }
}
