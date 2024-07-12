using FluentAssertions;
using Geometry.Domain.Abstraction;
using NetArchTest.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Geometry.ArchitectureTests.Domain;

public class DomainTests : BaseTest
{
    [Fact]
    public void Entities_ShouldHave_PrivateParameterlessConstructor()
    {
        var entityTypes = Types.InAssembly(DomainAssembly)
            .That()
            .Inherit(typeof(Entity))
            .GetTypes();

        var failingTypes = new List<Type>();
        foreach (var entityType in entityTypes)
        {
            ConstructorInfo[] constructors = entityType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

            if (false == constructors.Any(c => c.IsPrivate && c.GetParameters().Length == 0))
            {
                failingTypes.Add(entityType);
            }
        }

        failingTypes.Should().BeEmpty();
    }
}
