using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace Credfeto.Mediatr.Background.Services.Services;

public sealed class TickerWorker : BackgroundService
{
    private static readonly TimeSpan Interval = TimeSpan.FromSeconds(5);
    private readonly IMediator _mediator;

    public TickerWorker(IMediator mediator)
    {
        this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await this._mediator.Publish(new Ping("Hello World"), cancellationToken: stoppingToken);
            await Task.Delay(delay: Interval, cancellationToken: stoppingToken);
        }
    }
}