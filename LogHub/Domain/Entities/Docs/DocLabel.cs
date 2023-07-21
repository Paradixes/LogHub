using LogHub.Domain.Entities.Bases;

namespace LogHub.Domain.Entities.Docs;

public class DocLabel
{
    internal DocLabel(DocumentId docId, LabelId labelId)
    {
        DocId = docId;
        LabelId = labelId;
    }

    public DocumentId DocId { get; }

    public LabelId LabelId { get; }
}
