namespace Client.ViewModel;

public class LabelModel
{
    public Guid Id { get; set; }

    public Guid RepositoryId { get; set; }

    public string Name { get; set; } = "Report";

    public string Color { get; set; } = "#000000";
}
