using Domain.Entities.Records;
using Domain.Entities.Records.Docs;
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

    public Document? Doc { get; }

    public LabelId LabelId { get; }

    public Label? Label { get; }
}
