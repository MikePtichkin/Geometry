using Geometry.Domain.Triangles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Geometry.Infrastructure.Repositories;

internal sealed class TriangleRepository : ITriangleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TriangleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Triangle?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Triangle>()
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    }

    public async Task<Guid> AddAsync(Triangle triangle, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<Triangle>().Add(triangle);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return triangle.Id;
    }
}
