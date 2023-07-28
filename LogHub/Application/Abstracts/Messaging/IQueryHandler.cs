using LogHub.Domain.Shared;
using MediatR;

namespace LogHub.Application.Abstracts.Messaging;

public interface IQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse> { }
