using System;
using System.Threading;
using System.Threading.Tasks;
using Credfeto.Mediatr.Background.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Credfeto.Mediatr.Cmd.Handlers;

/// <summary>
///     A Handler
/// </summary>
public sealed class PingWarningNotificationHandler : INotificationHandler<Ping>
{
    private readonly ILogger<PingWarningNotificationHandler> _logger;

    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="logger">Logging</param>
    public PingWarningNotificationHandler(ILogger<PingWarningNotificationHandler> logger)
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc />
    public Task Handle(Ping notification, CancellationToken cancellationToken)
    {
        this._logger.LogWarning($"Ping: {notification.Message}");

        return Task.CompletedTask;
    }
}