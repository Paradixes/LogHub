namespace Application.Records.Repositories.Labels.GetLabels;

public record LabelResponse(
    Guid Id,
    string Color,
    string Name);