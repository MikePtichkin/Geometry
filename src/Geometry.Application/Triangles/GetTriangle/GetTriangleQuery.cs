using Geometry.Application.Abstractions.Messaging;
using System;

namespace Geometry.Application.Triangles.GetTriangle;

public sealed record GetTriangleQuery(Guid TriangleId) : IQuery<TriangleResponse>;
