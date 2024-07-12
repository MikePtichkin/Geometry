using Geometry.Application.Abstractions.Messaging;
using System;

namespace Geometry.Application.Triangles.GetArea;

public sealed record GetAreaQuery(Guid TriangleId) : IQuery<double>;
