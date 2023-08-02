using Domain.Shared;
using MediatR;

namespace Application.Abstracts.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }