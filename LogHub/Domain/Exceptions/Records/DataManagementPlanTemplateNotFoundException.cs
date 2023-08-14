using Domain.Entities.Records.DataManagementPlans;

namespace Domain.Exceptions.Records;

public class DataManagementPlanTemplateNotFoundException : Exception
{
    public DataManagementPlanTemplateNotFoundException(DataManagementPlanId id) :
        base($"Data management plan template with id {id} was not found.") { }
}
