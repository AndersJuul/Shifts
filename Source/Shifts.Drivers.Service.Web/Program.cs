using Shifts.Drivers.Web.Lib;
using Shifts.Services;
using Topshelf;

namespace Shifts.Drivers.Service.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            EsLogger.SetupGlobalLogger();

            HostFactory.Run(factory =>
            {
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