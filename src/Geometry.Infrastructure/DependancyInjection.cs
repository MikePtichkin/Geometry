using Geometry.Application.Abstractions.Clock;
using Geometry.Domain.Triangles;
using Geometry.Infrastructure.Clock;
using Geometry.Infrastructure.Outbox;
using Geometry.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;

namespace Geometry.Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<ITriangleRepository, TriangleRepository>();

        var connectionString = configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.Configure<OutboxOptions>(configuration.GetSection("Outbox"));

        services.AddQuartz();
        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
        services.ConfigureOptions<ProcessOutboxMessagesJobSetup>();

        return services;
    }
}
