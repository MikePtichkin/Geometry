using Geometry.Domain.Abstraction;
using MediatR;

namespace Geometry.Application.Abstractions.Messaging;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
