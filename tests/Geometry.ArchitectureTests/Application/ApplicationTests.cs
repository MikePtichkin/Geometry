using FluentAssertions;
using Geometry.Application.Abstractions.Messaging;
using NetArchTest.Rules;

namespace Geometry.ArchitectureTests;

public class ApplicationTests : BaseTest
{
    [Fact]
    public void CommandHandler_ShouldHave_NameEndingWith_CommandHandler()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void CommandHandler_Should_NotBePublic()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .NotBePublic()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void QuerydHandler_ShouldHave_NameEndingWith_QueryHandler()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void QueryHandler_Should_NotBePublic()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .NotBePublic()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    // еще тут можно проверять валидаторы для FluentValidation если такие используются
}