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

                x.RunAsLocalSystem();
                x.SetServiceName("ServiceName");
                x.SetDescription("ServiceDesc");
                x.SetDisplayName("ServiceDispName");

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
