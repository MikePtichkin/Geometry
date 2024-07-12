using System;
using System.Threading;
using System.Threading.Tasks;

namespace Geometry.Domain.Triangles;

public interface ITriangleRepository
{
    Task<Triangle?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> AddAsync(Triangle triangle, CancellationToken cancellationToken = default);
}
