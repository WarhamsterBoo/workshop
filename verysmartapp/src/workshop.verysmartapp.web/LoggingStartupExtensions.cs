using Microsoft.Extensions.Hosting;
using Serilog;

namespace workshop.verysmartapp.web
{
    public static class LoggingStartupExtensions
    {
        public static IHostBuilder ConfigureSerilog(this IHostBuilder builder)
            => builder.UseSerilog(
                (hostingContext, loggerConfiguration) =>
                {
                    var configuration = hostingContext.Configuration;

                    loggerConfiguration
                        .ReadFrom.Configuration(configuration)
                        .Enrich.FromLogContext()
                        .WriteTo.Console();
                });
    }
}
