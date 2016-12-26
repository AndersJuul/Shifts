using System;
using System.Configuration;
using System.Reflection;
using Serilog;
using Serilog.Enrichers;
using Serilog.Sinks.Elasticsearch;

namespace Shifts.Services
{
    public class EsLogger
    {
        public static void SetupGlobalLogger()
        {
            var assemblyName = Assembly.GetEntryAssembly().GetName();
            var loggerConfig = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.With<EnvironmentUserNameEnricher>()
                .Enrich.WithProperty("Version", ConfigurationManager.AppSettings["version"])
                .Enrich.WithProperty("ProcessName", assemblyName.Name)
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true
                });

            Log.Logger = loggerConfig.CreateLogger();
        }
    }
}