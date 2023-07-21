using LogHub.Domain.Entities.Users;

namespace LogHub.Domain.Entities.Docs;

public class DocEditor
{
    internal DocEditor(DocumentId docId, UserId userId)
    {
        DocId = docId;
        UserId = userId;
    }

    public DocumentId DocId { get; private set; }

    public UserId UserId { get; private set; }
}
