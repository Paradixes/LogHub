using LogHub.Domain.Shared;
using MediatR;

namespace LogHub.Application.Abstracts.Messaging;

public interface ICommand : IRequest<Result> { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }