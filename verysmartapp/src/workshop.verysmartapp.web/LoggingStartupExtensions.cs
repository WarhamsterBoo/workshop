using System;
using Microsoft.Extensions.Hosting;
using Prometheus;
using Serilog;
using Serilog.Core;
using Serilog.Events;
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
                        .WriteTo.Elasticsearch(elasticsearchSinkOptions)
                        .WriteTo.Sink<PrometheusLogEventSink>();
                });
        
        private class PrometheusLogEventSink : ILogEventSink
        {
            private static readonly Counter LogEventCountByLevel
                = Metrics.CreateCounter("verysmartapp_events_total", "Total number of Serilog events", "level");

            public void Emit(LogEvent logEvent)
                => LogEventCountByLevel.WithLabels(logEvent.Level.ToString()).Inc();
        }
    }
}
