using Serilog;
using Shifts.Drivers.Web.Lib;
using Shifts.Services;
using Topshelf;
using Topshelf.Logging;

namespace Shifts.Drivers.Service.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            EsLogger.SetupGlobalLogger();

            Log.Logger.Information("Ready to start hostfactory");

            HostFactory.Run(factory =>
            {
                Log.Logger.Information("hostfactory 1");

                factory.OnException(exception => {Log.Logger.Error(exception,"Topshelf xception"); });
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