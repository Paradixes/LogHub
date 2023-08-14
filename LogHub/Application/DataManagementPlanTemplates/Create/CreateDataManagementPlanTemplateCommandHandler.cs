using Domain.Entities.Records.DataManagementPlans;
using Domain.Repositories;
using MediatR;

namespace Application.DataManagementPlanTemplates.Create;

public class
    CreateDataManagementPlanTemplateCommandHandler : IRequestHandler<CreateDataManagementPlanTemplateCommand, Guid>
{
    private readonly IDataManagementPlanTemplateRepository _dataManagementPlanTemplateRepository;

    public CreateDataManagementPlanTemplateCommandHandler(
        IDataManagementPlanTemplateRepository dataManagementPlanTemplateRepository)
    {
        _dataManagementPlanTemplateRepository = dataManagementPlanTemplateRepository;
    }

    public Task<Guid> Handle(CreateDataManagementPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        var dataManagementPlanTemplate = DataManagementPlanTemplate.Create(
            request.OrganisationId,
            request.CreatorId,
            request.Title,
            request.Icon,
            request.Description);

        foreach (var question in request.Questions)
        {
            dataManagementPlanTemplate.AddQuestion(question.Title, question.Description);
        }

        _dataManagementPlanTemplateRepository.Add(dataManagementPlanTemplate);

        return Task.FromResult(dataManagementPlanTemplate.Id.Value);
    }
}
