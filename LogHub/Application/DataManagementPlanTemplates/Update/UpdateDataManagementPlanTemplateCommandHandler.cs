using Domain.Entities.Records.DataManagementPlans;
using Domain.Exceptions.Records;
using Domain.Repositories;
using MediatR;

namespace Application.DataManagementPlanTemplates.Update;

public class UpdateDataManagementPlanTemplateCommandHandler : IRequestHandler<UpdateDataManagementPlanTemplateCommand>
{
    private readonly IDataManagementPlanTemplateRepository _dataManagementPlanTemplateRepository;

    public UpdateDataManagementPlanTemplateCommandHandler(
        IDataManagementPlanTemplateRepository dataManagementPlanTemplateRepository)
    {
        _dataManagementPlanTemplateRepository = dataManagementPlanTemplateRepository;
    }

    public async Task Handle(UpdateDataManagementPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        var dataManagementPlanTemplate = await _dataManagementPlanTemplateRepository.GetByIdAsync(request.Id);

        if (dataManagementPlanTemplate is null)
        {
            throw new DataManagementPlanTemplateNotFoundException(request.Id);
        }

        dataManagementPlanTemplate.UpdateDetails(
            request.Title,
            request.Icon,
            request.Description);

        foreach (var question in request.Questions)
        {
            dataManagementPlanTemplate.UpdateQuestion(
                new QuestionId(question.Id), question.Title, question.Description);
        }
    }
}
