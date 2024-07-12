using System;

namespace Geometry.Domain.Triangles;

public sealed record Side
{
    public Side(double value)
    {
        if (value < 0)
        {
            throw new ApplicationException("Side's length cannot be negative");
        }

        Value = value;
    }

    public double Value { get; init; }
};
