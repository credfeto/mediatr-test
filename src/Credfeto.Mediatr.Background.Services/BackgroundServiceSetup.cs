using Credfeto.Mediatr.Background.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Credfeto.Mediatr.Background.Services;

public static class BackgroundServiceSetup
{
    public static IServiceCollection AddBackgroundService(this IServiceCollection services)
    {
        return services.AddHostedService<TickerWorker>();
    }
}