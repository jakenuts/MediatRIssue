using MediatR;
using MediatRTest.Events;
using Microsoft.Extensions.Logging;

namespace MediatRTest.Handlers;

public class GenericTestEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : TestEventBase
{
    private readonly ILogger _log;

    public GenericTestEventHandler(ILogger<GenericTestEventHandler<TEvent>> log)
    {
        _log = log;
        _log.LogInformation("✨ GenericTestEventHandler Created");
    }

    public Task Handle(TEvent notification, CancellationToken cancellationToken)
    {
        _log.LogInformation("✅ GenericTestEventHandler Handling {note}", notification.GetType());
        return Task.CompletedTask;
    }
}