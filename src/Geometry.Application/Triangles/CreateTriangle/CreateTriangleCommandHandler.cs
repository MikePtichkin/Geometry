using Geometry.Application.Abstractions.Messaging;
using Geometry.Domain.Abstraction;
using Geometry.Domain.Triangles;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Geometry.Application.Triangles.CreateTriangle;

internal class CreateTriangleCommandHandler : ICommandHandler<CreateTriangleQuery, Guid>
{
    private readonly ITriangleRepository _triangleRepository;

    public CreateTriangleCommandHandler(ITriangleRepository triangleRepository)
    {
        _triangleRepository = triangleRepository;
    }

    public async Task<Result<Guid>> Handle(CreateTriangleQuery request, CancellationToken cancellationToken)
    {
        var sideA = new Side(request.SideA);
        var sideB = new Side(request.SideB);
        var sideC = new Side(request.SideC);

        var triangle = Triangle.Create(sideA, sideB, sideC);
        if (triangle.IsSuccess)
        {
            var id =  await _triangleRepository.AddAsync(triangle.Value, cancellationToken);
            return id;
        }

        return Result<Guid>.Failure(triangle.Error);
    }
}
