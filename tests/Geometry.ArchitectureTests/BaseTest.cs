using Geometry.Api;
using Geometry.Application.Abstractions.Messaging;
using Geometry.Domain.Abstraction;
using Geometry.Infrastructure;
using System.Reflection;

namespace Geometry.ArchitectureTests;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(Entity).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(ICommand<>).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
}
