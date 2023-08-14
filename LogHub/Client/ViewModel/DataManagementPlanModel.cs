namespace Client.ViewModel;

public class DataManagementPlanModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Icon { get; set; }

    public Guid OrganisationId { get; set; }

    public Guid CreatorId { get; set; }

    public UserAccountModel Creator { get; set; } = new();

    public string? Description { get; set; }

    public List<QuestionModel> Questions { get; set; } = new();
}

public class QuestionModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Answer { get; set; }
}
