using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace Credfeto.Mediatr.Cmd.ServiceStartup;

internal static class Logging
{
    /// <summary>
    ///     Configures logging in dependency injection.
    /// </summary>
    /// <param name="services">The dependency injection collection to add the services to</param>
    public static IServiceCollection AddAppLogging(this IServiceCollection services)
    {
        // add logging to the services
        return services.AddLogging(AddFilters);
    }

    /// <summary>
    ///     Initialise logging.
    /// </summary>
    /// <param name="loggerFactory">The logger factory.</param>
    [SuppressMessage(category: "Microsoft.Reliability", checkId: "CA2000:DisposeObjectsBeforeLosingScope", Justification = "Lives for program lifetime")]
    [SuppressMessage(category: "ReSharper", checkId: "UnusedMember.Global", Justification = "Not easily testable as uses third party services")]
    public static void InitializeLogging(ILoggerFactory loggerFactory)
    {
        // set up Serilog logger
        Log.Logger = CreateLogger();

        // set up the logger factory
        loggerFactory.AddSerilog();
    }

    private static Logger CreateLogger()
    {
        return new LoggerConfiguration().Enrich.FromLogContext()
                                        .Enrich.WithMachineName()
                                        .Enrich.WithProcessId()
                                        .Enrich.WithThreadId()
                                        .Enrich.WithProperty(name: @"ProcessName", typeof(Program).Namespace!)
                                        .WriteTo.Console()
                                        .CreateLogger();
    }

    private static void AddFilters(ILoggingBuilder builder)
    {
        builder.AddFilter(category: @"Microsoft", level: LogLevel.Warning)
               .AddFilter(category: @"System.Net.Http.HttpClient", level: LogLevel.Warning)
               .AddFilter(category: @"Microsoft.AspNetCore.ResponseCaching.ResponseCachingMiddleware", level: LogLevel.Error);
    }
}