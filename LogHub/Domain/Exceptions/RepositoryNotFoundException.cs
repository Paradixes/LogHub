using Domain.Entities.Records.Repositories;

namespace Domain.Exceptions;

public class RepositoryNotFoundException : Exception
{
    public RepositoryNotFoundException(RepositoryId repositoryId) :
        base($"Repository with id {repositoryId.Value} was not found.") { }
}
