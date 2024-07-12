using Geometry.Domain.Abstraction;
using System;

namespace Geometry.Domain.Triangles.Events;

public sealed record TriangleCreatedDomainEvent(Guid TriangleId) : IDomainEvent
{
}
