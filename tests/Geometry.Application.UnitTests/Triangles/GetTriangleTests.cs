using FluentAssertions;
using Geometry.Application.Triangles.GetTriangle;
using Geometry.Domain.Triangles;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Geometry.Application.UnitTests.Triangles;

public class GetTriangleTests
{
    private readonly GetTriangleQueryHandler _handler;
    private readonly ITriangleRepository _triangleRepositoryMock;

    public GetTriangleTests()
    {
        _triangleRepositoryMock = Substitute.For<ITriangleRepository>();
        _handler = new GetTriangleQueryHandler(_triangleRepositoryMock);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenTriangleIsNull()
    {
        // Arrange
        var query = new GetTriangleQuery(Guid.NewGuid());
        _triangleRepositoryMock
            .GetByIdAsync(query.TriangleId, Arg.Any<CancellationToken>())
            .Returns((Triangle?)null);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.Error.Should().Be(TriangleErrors.NotFound);
    }
}
