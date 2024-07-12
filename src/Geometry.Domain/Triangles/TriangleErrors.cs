using Geometry.Domain.Abstraction;

namespace Geometry.Domain.Triangles;

public static class TriangleErrors
{
    public static Error NotFound = new(
        "Triangle.NotFound",
        "Triangle with specified identifier was not found");

    public static Error TriangleInequality = new(
        "Triangle.SidesInequality",
        "Triange cannot exist with such sides");
}
