using Geometry.Domain.Abstraction;
using MediatR;

namespace Geometry.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
