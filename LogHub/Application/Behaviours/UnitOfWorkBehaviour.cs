using System.Transactions;
using Application.Data;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Behaviours;

public sealed class UnitOfWorkBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogHubDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkBehaviour(IUnitOfWork unitOfWork, ILogHubDbContext dbContext)
    {
        _unitOfWork = unitOfWork;
        _dbContext = dbContext;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (IsNotCommand())
        {
            return await next();
        }

        using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var response = await next();

        UpdateAuditableEntities();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        transactionScope.Complete();

        return response;
    }

    private static bool IsNotCommand()
    {
        return !typeof(TRequest).Name.EndsWith("Command");
    }

    private void UpdateAuditableEntities()
    {
        var entries = _dbContext.ChangeTracker
            .Entries<IAuditableEntity>();

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property(a => a.CreatedOnUtc)
                    .CurrentValue = DateTime.UtcNow;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Property(a => a.ModifiedOnUtc)
                    .CurrentValue = DateTime.UtcNow;
            }
        }
    }
}