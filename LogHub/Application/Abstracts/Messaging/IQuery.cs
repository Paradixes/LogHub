using LogHub.Domain.Shared;
using MediatR;

namespace LogHub.Application.Abstracts.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
