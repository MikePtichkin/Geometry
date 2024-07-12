using Geometry.Domain.Triangles.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Geometry.Application.Triangles.CreateTriangle;

internal sealed class TriangleCreatedDomainEventHandler : INotificationHandler<TriangleCreatedDomainEvent>
{
    public Task Handle(TriangleCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}
