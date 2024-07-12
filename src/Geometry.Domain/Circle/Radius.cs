using System;

namespace Geometry.Domain.Circle;

public sealed record Radius
{
    public Radius(double value)
    {
        if (value < 0)
        {
            throw new ApplicationException("Radius cannot be negative");
        }

        Value = value;
    }

    public double Value { get; init; }
}
