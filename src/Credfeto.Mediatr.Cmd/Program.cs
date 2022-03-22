using System.Threading.Tasks;
using Credfeto.Mediatr.Cmd.Helpers;
using Credfeto.Mediatr.Cmd.ServiceStartup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Credfeto.Mediatr.Cmd;

internal static class Program
{
    public static Task Main(string[] args)
    {
        StartupBanner.Show();

        return CreateHostBuilder(args)
               .Build()
               .InitializeLogging()
               .RunAsync();
    }

    private static IHost InitializeLogging(this IHost host)
    {
        ILoggerFactory loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();

        Logging.InitializeLogging(loggerFactory: loggerFactory);

        return host;
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
                   .ConfigureServices(Services.Configure)
                   .ConfigureLogging(InitialiseProviders)
                   .UseWindowsService()
                   .UseSystemd();
    }

    private static void InitialiseProviders(HostBuilderContext hostBuilderContext, ILoggingBuilder logger)
    {
        logger.ClearProviders();
    }
}