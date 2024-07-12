using Geometry.Application.Abstractions.Messaging;
using System;

namespace Geometry.Application.Triangles.CreateTriangle;

public sealed record CreateTriangleQuery(
    double SideA,
    double SideB,
    double SideC) : ICommand<Guid>;
