using Geometry.Domain.Abstraction;
using MediatR;

namespace Geometry.Application.Abstractions.Messaging;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
