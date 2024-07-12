using Geometry.Application.Abstractions.Messaging;
using Geometry.Domain.Abstraction;
using Geometry.Domain.Triangles;
using System.Threading;
using System.Threading.Tasks;

namespace Geometry.Application.Triangles.IsRight;

internal sealed class IsRightTriangleQueryHandler : IQueryHandler<IsRightTriangleQuery, bool>
{
    private readonly ITriangleRepository _triangleRepository;

    public IsRightTriangleQueryHandler(ITriangleRepository triangleRepository)
    {
        _triangleRepository = triangleRepository;
    }

    public async Task<Result<bool>> Handle(IsRightTriangleQuery request, CancellationToken cancellationToken)
    {
        var triangle = await _triangleRepository.GetByIdAsync(request.TriangleId, cancellationToken);
        if (triangle == null)
        {
            return Result<bool>.Failure(TriangleErrors.NotFound);
        }
        // проверка на прямоугольность может быть вынесена в доменный сервис.
        // Заодно можно сделать проверку на равнобокость треугольника.
        var a = triangle.SideA.Value;
        var b = triangle.SideB.Value;
        var c = triangle.SideC.Value;

        var isRight =
            (a * a + b * b == c * c) ||
            (a * a + c * c == b * b) ||
            (b * b + c * c == a * a);

        return isRight;
    }
}
