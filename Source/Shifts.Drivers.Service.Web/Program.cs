using System.Configuration;
using Serilog;
using Shifts.Drivers.Web.Lib;
using Shifts.Services;
using Topshelf;

namespace Shifts.Drivers.Service.Web
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EsLogger.SetupGlobalLogger();

            Log.Logger.Information("Ready to start hostfactory");

            HostFactory.Run(factory =>
            {
                factory.OnException(exception => { Log.Logger.Error(exception, "Topshelf xception"); });
                factory.Service<ServiceHost>(service =>
                {
                    service.ConstructUsing(name => new ServiceHost());
                    service.WhenStarted(sh => sh.Start());
                    service.WhenShutdown(sh => sh.Shutdown());
                    service.WhenStopped(sh => sh.Stop());
                });
                factory.SetDescription(ConfigurationManager.AppSettings["version"]);
            });
        }
    }
}