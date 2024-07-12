using System;

namespace Geometry.Application.Abstractions.Clock;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
