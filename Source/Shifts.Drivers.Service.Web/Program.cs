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

            HostFactory.Run(factory =>
            {
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