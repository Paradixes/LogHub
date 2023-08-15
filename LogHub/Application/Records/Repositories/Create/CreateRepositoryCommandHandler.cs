using Domain.Entities.Records.DataManagementPlans;
using Domain.Entities.Records.Repositories;
using Domain.Exceptions.Records;
using Domain.Repositories;
using MediatR;

namespace Application.Records.Repositories.Create;

public class CreateRepositoryCommandHandler : IRequestHandler<CreateRepositoryCommand, Guid>
{
    private readonly IDataManagementPlanTemplateRepository _dataManagementPlanTemplateRepository;
    private readonly IRepositoryRepository _repositoryRepository;

    public CreateRepositoryCommandHandler(
        IRepositoryRepository repositoryRepository,
        IDataManagementPlanTemplateRepository dataManagementPlanTemplateRepository)
    {
        _repositoryRepository = repositoryRepository;
        _dataManagementPlanTemplateRepository = dataManagementPlanTemplateRepository;
    }

    public async Task<Guid> Handle(CreateRepositoryCommand request, CancellationToken cancellationToken)
    {
        var dmpTemplateId = new DataManagementPlanId(request.DataManagementPlan.Id);

        var dataManagementPlanTemplate = await _dataManagementPlanTemplateRepository.GetByIdAsync(dmpTemplateId);


        var repository = new Repository(
            request.Title,
            request.Icon,
            request.Description,
            request.CreatorId,
            request.OrganisationId);

        if (dataManagementPlanTemplate == null)
        {
            throw new DataManagementPlanTemplateNotFoundException(dmpTemplateId);
        }

        var dataManagementPlan = new DataManagementPlan(dataManagementPlanTemplate, repository.Id, request.CreatorId);

        for (var i = 0; i < request.DataManagementPlan.Questions.Count; i++)
        {
            var question = request.DataManagementPlan.Questions[i];
            if (question.Answer == null)
            {
                throw new DataManagementPlanEmptyAnswerException(new QuestionId(question.Id));
            }

            dataManagementPlan.UpdateAnswerByIndex(i, question.Answer);
        }

        repository.UpdateDataManagementPlan(dataManagementPlan);

        _repositoryRepository.Add(repository);

        return repository.Id.Value;
    }
}
