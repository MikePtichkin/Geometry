using FluentAssertions;
using Geometry.Domain.Triangles;

namespace Geometry.Domain.UnitTests.Triangles;

public class TriangleTests
{
    [Fact]
    public void Create_WithRightSides_Should_SetSides()
    {
        // Arrange
        var sideA = new Side(3);
        var sideB = new Side(4);
        var sideC = new Side(5);

        // Act
        var triangle = Triangle.Create(sideA, sideB, sideC);

        // Assert
        triangle.IsSuccess.Should().BeTrue();
        triangle.Value.SideA.Should().Be(sideA);
        triangle.Value.SideB.Should().Be(sideB);
        triangle.Value.SideC.Should().Be(sideC);
    }

    [Fact]
    public void Create_WithWrongSides_Should_Return_TriangleInequalityError()
    {
        // Arange
        var sideA = new Side(3);
        var sideB = new Side(4);
        var sideC = new Side(100);

        // Act
        var triangle = Triangle.Create(sideA, sideB, sideC);

        // Assert
        triangle.IsFailure.Should().BeTrue();
        triangle.Error.Should().Be(TriangleErrors.TriangleInequality);
    }

    [Fact]
    public void GetArea_Should_Return_RightArea()
    {
        // Arrange
        var sideA = new Side(3);
        var sideB = new Side(4);
        var sideC = new Side(5);
        var triangle = Triangle.Create(sideA, sideB, sideC);

        // Act
        var result = triangle.Value.GetArea();

        // Assert
        triangle.IsSuccess.Should().BeTrue();
        result.Should().Be(6);
    }
}