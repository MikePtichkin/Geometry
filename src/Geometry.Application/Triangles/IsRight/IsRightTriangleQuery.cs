using Geometry.Application.Abstractions.Messaging;
using System;

namespace Geometry.Application.Triangles.IsRight;

public sealed record IsRightTriangleQuery(Guid TriangleId) : IQuery<bool>;
