using Geometry.Application.Abstractions.Messaging;
using Geometry.Domain.Abstraction;
using Geometry.Domain.Triangles;
using System.Threading;
using System.Threading.Tasks;

namespace Geometry.Application.Triangles.GetArea;

internal sealed class GetAreaQueryHandler : IQueryHandler<GetAreaQuery, double>
{
    private readonly ITriangleRepository _triangleRepository;

    public GetAreaQueryHandler(ITriangleRepository triangleRepository)
    {
        _triangleRepository = triangleRepository;
    }

    public async Task<Result<double>> Handle(GetAreaQuery request, CancellationToken cancellationToken)
    {
        var triangleDomain = await _triangleRepository.GetByIdAsync(request.TriangleId, cancellationToken);
        if (triangleDomain == null)
        {
            return Result<double>.Failure(TriangleErrors.NotFound);
        }

        var result = triangleDomain.GetArea();

        return result;
    }
}
