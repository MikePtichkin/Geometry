using Geometry.Application.Abstractions.Clock;
using System;

namespace Geometry.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
