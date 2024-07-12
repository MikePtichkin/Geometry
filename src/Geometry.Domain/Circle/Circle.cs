using Geometry.Domain.Abstraction;
using System;

namespace Geometry.Domain.Circle;

public sealed class Circle : Entity, IShape
{
    private Circle(Guid id, Radius radius)
        : base(id)
    {
        Radius = radius;
    }

    private Circle()
    {
    }

    public Radius Radius { get; private set; }

    public static Result<Circle> Create(Radius radius)
    {
        var circle = new Circle(Guid.NewGuid(), radius);

        return circle;
    }

    public double GetArea() =>
        Math.PI * Radius.Value * Radius.Value;
}
