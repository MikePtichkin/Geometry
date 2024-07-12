using Geometry.Domain.Abstraction;
using Geometry.Domain.Triangles.Events;
using System;

namespace Geometry.Domain.Triangles;

public sealed class Triangle : Entity, IShape
{
    private Triangle(
        Guid id,
        Side sideA,
        Side sideB,
        Side sideC)
        : base(id)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    private Triangle()
    {
    }

    public Side SideA { get; private set; }
    public Side SideB { get; private set; }
    public Side SideC { get; private set; }
    public double Height {  get; private set; }

    public static Result<Triangle> Create(Side sideA, Side sideB, Side sideC)
    {
        if (sideA.Value + sideB.Value <= sideC.Value ||
            sideA.Value + sideC.Value <= sideB.Value ||
            sideB.Value + sideC.Value <= sideA.Value)
        {
            return Result<Triangle>.Failure(TriangleErrors.TriangleInequality);
        }

        var triangle = new Triangle(Guid.NewGuid(), sideA, sideB, sideC);

        triangle.RaiseDomainEvent(new TriangleCreatedDomainEvent(triangle.Id));
        
        return triangle;
    }

    public double GetArea()
    {
        var semiPerimeter = 0.5 * (SideA.Value + SideB.Value + SideC.Value);

        var area = Math.Sqrt(semiPerimeter
            * (semiPerimeter - SideA.Value)
            * (semiPerimeter - SideB.Value)
            * (semiPerimeter - SideC.Value));

        return area;
    }
}
