using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.OpenTelemetry;

namespace SIG2M.API.Utils
{
    public static class ConfiguradorLogs
    {
        public static void ConfigurarLogger(this IServiceCollection services, IConfiguration configuration, string nomeAplicacao)
        {

            string seqUrl = configuration["SEQ__URL"];
            if (string.IsNullOrWhiteSpace(seqUrl))
            {
                seqUrl = Environment.GetEnvironmentVariable("SEQ__URL");
                if (string.IsNullOrWhiteSpace(seqUrl))
                    throw new NullReferenceException("Please provide a valid SEQ__URL");
            }

            services.AddOpenTelemetry()
                .ConfigureResource(resource =>
                {
                    resource.AddService(nomeAplicacao);
                    resource.AddTelemetrySdk();
                })
                .WithMetrics(m =>
                {
                    m.AddAspNetCoreInstrumentation();
                    m.AddOtlpExporter(e =>
                    {
                        e.Endpoint = new Uri($"{seqUrl}/ingest/otlp/v1/logs");
                        e.Protocol = OtlpExportProtocol.HttpProtobuf;
                        e.ExportProcessorType = ExportProcessorType.Batch;
                    });
                })
                .WithTracing(t =>
                {
                    t.SetErrorStatusOnException()
                        .SetSampler(new AlwaysOnSampler())
                        .AddOtlpExporter(e =>
                        {
                            e.Endpoint = new Uri($"{seqUrl}/ingest/otlp/v1/traces");
                            e.Protocol = OtlpExportProtocol.HttpProtobuf;
                        });
                });

            services.AddSerilog((sp, config) =>
            {
                config.ReadFrom
                    .Services(sp)
                    .Filter.ByExcluding(e => string.IsNullOrWhiteSpace(e.MessageTemplate.Text))
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("Application", nomeAplicacao)
                    .WriteTo.Console();


                config.Destructure.ToMaximumDepth(3);
                config.WriteTo.OpenTelemetry(oop =>
                {
                    oop.Endpoint = $"{seqUrl}/ingest/otlp/v1/logs";
                    oop.Protocol = OtlpProtocol.HttpProtobuf;
                    oop.IncludedData = IncludedData.TraceIdField | IncludedData.SpanIdField |
                                       IncludedData.SourceContextAttribute;
                    oop.ResourceAttributes = new Dictionary<string, object>
                {
                    { "service.name", nomeAplicacao }
                };
                });

                // Also write logs to Windows Event Viewer (Application log)
                // Note: creating the event source may require administrative privileges on first run.
                // config.WriteTo.EventLog(
                //     source: nomeAplicacao,
                //     manageEventSource: true,
                //     restrictedToMinimumLevel: LogEventLevel.Information,
                //     logName: "Application");
            });

            SelfLog.Enable(Console.Error);

            services.AddLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Information);
                logging.AddOpenTelemetry(options =>
                {
                    options.SetResourceBuilder(
                        ResourceBuilder.CreateEmpty().AddService(nomeAplicacao));

                    options.IncludeScopes = true;
                    options.IncludeFormattedMessage = true;

                    options.AddOtlpExporter(exporter =>
                    {
                        exporter.Endpoint =
                            new Uri($"{seqUrl}/ingest/otlp/v1/logs");
                        exporter.Protocol = OtlpExportProtocol.HttpProtobuf;
                    });
                });
            });
        }
    }
}
