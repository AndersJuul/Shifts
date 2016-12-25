using System;
using System.Configuration;
using Microsoft.Owin.Hosting;

namespace Shifts.Drivers.Web.Lib
{
    public class ServiceHost
    {
        private IDisposable _server;

        private string _baseAddress ;

        public ServiceHost()
        {
            Console.WriteLine("ServiceHost constructed");
        }

        public void Start()
        {
            Console.WriteLine("ServiceHost started");

            _baseAddress = ConfigurationManager.AppSettings["shifts.drivers.api.url"];    
            _server = WebApp.Start<Startup>(url: _baseAddress);

            Console.WriteLine($"Server running at {_baseAddress}");
        }

        public void Shutdown()
        {
            Console.WriteLine("ServiceHost shutting down");

        }

        public void Stop()
        {
            Console.WriteLine("Server shutting down");

            _server.Dispose();

            Console.WriteLine("ServiceHost stopped");
        }
    }
}
