using System;

namespace Geometry.Application.Triangles.GetTriangle;

public sealed class TriangleResponse
{
    public Guid Id { get; init; }
    public double SideA { get; init; }
    public double SideB { get; init; }
    public double SideC { get; init; }
}
