using Domain.Entities.Records.Labels;

namespace Domain.Exceptions.Records;

public class LabelNotFoundException : Exception
{
    public LabelNotFoundException(LabelId labelId) :
        base($"Label with id {labelId.Value} was not found.") { }
}
