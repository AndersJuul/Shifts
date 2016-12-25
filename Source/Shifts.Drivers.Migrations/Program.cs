using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using DbUp;
using Serilog;
using Serilog.Context;
using Serilog.Enrichers;
using Serilog.Sinks.Elasticsearch;

namespace Shifts.Drivers.Migrations
{
    public class Program
    {
        private static int Main(string[] args)
        {
            // Create Logger
            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            var loggerConfig = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.With<EnvironmentUserNameEnricher>()
                .Enrich.WithProperty("Version", ConfigurationManager.AppSettings["version"])
                .Enrich.WithProperty("ProcessName", assemblyName.Name)
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true
                });

            var logger = loggerConfig.CreateLogger();
            logger.Error("Running Migrations");

            var connectionString =
                args.FirstOrDefault()
                ?? ConfigurationManager.ConnectionStrings["shiftDriversDb"].ConnectionString;
            //"Server=(local)\\SqlExpress; Database="+ConfigurationManager.AppSettings["db-name"]+"; Trusted_connection=true";

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}