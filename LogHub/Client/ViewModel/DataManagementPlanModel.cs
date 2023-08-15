namespace Client.ViewModel;

public class DataManagementPlanModel
{
    public DataManagementPlanModel(DataManagementPlanModel dataManagementPlan)
    {
        Id = dataManagementPlan.Id;
        Title = dataManagementPlan.Title;
        Icon = dataManagementPlan.Icon;
        OrganisationId = dataManagementPlan.OrganisationId;
        CreatorId = dataManagementPlan.CreatorId;
        Creator = dataManagementPlan.Creator;
        Description = dataManagementPlan.Description;
        Questions = dataManagementPlan.Questions;
    }

    public DataManagementPlanModel() { }

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
