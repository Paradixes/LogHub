using Domain.Entities.Records;
using Domain.Entities.Records.Labels;

namespace Domain.Entities.Middlewares;

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
