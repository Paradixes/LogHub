namespace Client.ViewModel;

public class RepositoryModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Icon { get; set; }

    public string? Description { get; set; }

    public Guid OrganisationId { get; set; }

    public Guid DataManagementPlanId { get; set; }

    public Guid CreatorId { get; set; }

    public UserAccountModel Creator { get; set; } = new();

    public DataManagementPlanModel DataManagementPlan { get; set; } = new();

    public bool IsFinished { get; set; }

    public List<LabelModel> Labels { get; set; } = new();
}
