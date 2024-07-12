using Geometry.Application.Abstractions.Messaging;
using Geometry.Domain.Abstraction;
using Geometry.Domain.Triangles;
using System.Threading;
using System.Threading.Tasks;

namespace Geometry.Application.Triangles.GetTriangle;

internal sealed class GetTriangleQueryHandler : IQueryHandler<GetTriangleQuery, TriangleResponse>
{
    private readonly ITriangleRepository _triangleRepository;

    public GetTriangleQueryHandler(ITriangleRepository triangleRepository)
    {
        _triangleRepository = triangleRepository;
    }

    public async Task<Result<TriangleResponse>> Handle(GetTriangleQuery request, CancellationToken cancellationToken)
    {
        var triangleDomain = await _triangleRepository.GetByIdAsync(request.TriangleId, cancellationToken);
        if (triangleDomain == null)
        {
            return Result<TriangleResponse>.Failure(TriangleErrors.NotFound);
        }

        return new TriangleResponse()
        {
            Id = triangleDomain.Id,
            SideA = triangleDomain.SideA.Value,
            SideB = triangleDomain.SideB.Value,
            SideC = triangleDomain.SideC.Value
        };
    }
}
