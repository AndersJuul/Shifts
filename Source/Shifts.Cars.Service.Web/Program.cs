using Serilog;
using Shifts.Cars.Web.Lib;
using Shifts.Services;
using Topshelf;

namespace Shifts.Cars.Service.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(factory =>
            {
                EsLogger.SetupGlobalLogger();

                Log.Logger.Information("Ready to start hostfactory");

                Log.Logger.Information("hostfactory 1");
                factory.Service<ServiceHost>(service =>
                {
                    service.ConstructUsing(name => new ServiceHost());
                    service.WhenStarted(sh => sh.Start());
                    service.WhenShutdown(sh => sh.Shutdown());
                    service.WhenStopped(sh => sh.Stop());
                });
            });
        }
    }
}