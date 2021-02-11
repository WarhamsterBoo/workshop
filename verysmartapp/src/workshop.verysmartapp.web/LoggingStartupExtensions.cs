using System;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace workshop.verysmartapp.web
{
    public static class LoggingStartupExtensions
    {
        public static IHostBuilder ConfigureSerilog(this IHostBuilder builder)
            => builder.UseSerilog(
                (hostingContext, loggerConfiguration) =>
                {
                    var configuration = hostingContext.Configuration;
                    var uri = new Uri(configuration["ElasticSearch:ConnectionString"]);
                    
                    var elasticsearchSinkOptions = new ElasticsearchSinkOptions(uri)
                    {
                        AutoRegisterTemplate = true,
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                        IndexFormat = "verysmartapp-{0:yyyy.MM}"
                    };
                    
                    loggerConfiguration
                        .ReadFrom.Configuration(configuration)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .WriteTo.Elasticsearch(elasticsearchSinkOptions);
                });
    }
}
