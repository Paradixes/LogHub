namespace Application.Records.Repositories.GetLabels;

public record LabelResponse(
    Guid Id,
    string Color,
    string Name);
