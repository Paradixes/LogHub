using Domain.Entities.Users;

namespace Domain.Entities.Docs;

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