using MediatR;
using MediatRTest.Events;
using Microsoft.Extensions.Logging;

namespace MediatRTest.Handlers;

public class TestEventAHandler : INotificationHandler<TestEventA>
{
    private readonly ILogger<TestEventAHandler> _log;

    public TestEventAHandler(ILogger<TestEventAHandler> log)
    {
        _log = log;
        _log.LogInformation("✨ TestEventAHandler Created");
    }

    /// <summary>Handles a notification</summary>
    /// <param name="notification">The notification</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public Task Handle(TestEventA notification, CancellationToken cancellationToken)
    {
        _log.LogInformation("✅ TestEventAHandler Handling {note}", notification.GetType());
        return Task.CompletedTask;
    }
}