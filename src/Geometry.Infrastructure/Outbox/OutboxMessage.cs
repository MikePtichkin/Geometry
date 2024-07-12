using System;

namespace Geometry.Infrastructure.Outbox;

public sealed class OutboxMessage
{
    public OutboxMessage(Guid id, DateTime occurredOnUtc, string type, string content)
    {
        Id = id;
        OccurredOnUtc = occurredOnUtc;
        Content = content;
        Type = type;
    }

    public Guid Id { get; init; }
    public DateTime OccurredOnUtc { get; init; }
    public string Type { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public DateTime? ProcessedOnUtc { get; set; }
    public string? Error { get; set; }

}