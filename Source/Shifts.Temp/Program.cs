using System.Configuration;
using Topshelf;

namespace Shifts.Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<MyService>(config =>
                {
                    config.ConstructUsing(o => new MyService());
                    config.WhenStarted(o => o.Start());
                    config.WhenStopped(o => { o.Stop();  });
                });

                x.SetServiceName("QA-ShiftTesting");
                x.SetDescription(ConfigurationManager.AppSettings["serviceDescription"]);
                x.SetDisplayName(ConfigurationManager.AppSettings["serviceDisplayName"]);

            });
        }
    }

    internal class MyService
    {
        public void Stop()
        {
            
        }

        public void Start()
        {
            
        }
    }
}
