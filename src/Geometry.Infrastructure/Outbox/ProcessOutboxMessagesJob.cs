using Geometry.Application.Abstractions.Clock;
using Geometry.Domain.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geometry.Infrastructure.Outbox;

[DisallowConcurrentExecution]
internal sealed class ProcessOutboxMessagesJob : IJob
{
    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All
    };

    private readonly ApplicationDbContext _dbContext;
    private readonly IPublisher _publisher;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly OutboxOptions _outboxOptions;
    private readonly ILogger<ProcessOutboxMessagesJob> _logger;

    public ProcessOutboxMessagesJob(
        ApplicationDbContext dbContext,
        IPublisher publisher,
        IDateTimeProvider dateTimeProvider,
        IOptions<OutboxOptions> outboxOptions,
        ILogger<ProcessOutboxMessagesJob> logger)
    {
        _dbContext = dbContext;
        _publisher = publisher;
        _dateTimeProvider = dateTimeProvider;
        _logger = logger;
        _outboxOptions = outboxOptions.Value;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("Начинаем обрабатывать outbox сообщения");

        var outboxMessages = GetOutboxMessages();

        foreach (var outboxMessage in outboxMessages)
        {
            Exception? exception = null;

            try
            {
                var domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(
                    outboxMessage.Content,
                    JsonSerializerSettings)!;

                await _publisher.Publish(domainEvent, context.CancellationToken);
            }
            catch (Exception caughtException)
            {
                _logger.LogError(
                    caughtException,
                    "Exception while processing outbox message {MessageId}",
                    outboxMessage.Id);

                exception = caughtException;
            }

            await UpdateOutboxMessageAsync(outboxMessage, exception);
        }

        _logger.LogInformation("Обработка outbox сообщений завершена");
    }

    private IReadOnlyList<OutboxMessage> GetOutboxMessages()
    {
        var messages = _dbContext.Set<OutboxMessage>()
            .Where(m => m.ProcessedOnUtc == null)
            .OrderBy(m => m.OccurredOnUtc)
            .Take(_outboxOptions.BatchSize)
            .ToList();

        return messages;
    }

    private async Task UpdateOutboxMessageAsync(OutboxMessage outboxMessage, Exception? exception)
    {
        outboxMessage.ProcessedOnUtc = DateTime.UtcNow;
        outboxMessage.Error = exception?.ToString();

        await _dbContext.SaveChangesAsync();
    }
}
