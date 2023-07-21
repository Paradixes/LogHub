using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Docs;

public class DocLabel
{
    internal DocLabel(RecordId docId, LabelId labelId)
    {
        DocId = docId;
        LabelId = labelId;
    }

    public RecordId DocId { get; }

    public LabelId LabelId { get; }
}
