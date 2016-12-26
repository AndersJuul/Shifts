using System;
using System.Configuration;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Logging;
using Serilog;

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
            Log.Logger.Information("ServiceHost started");

            _baseAddress = ConfigurationManager.AppSettings["shifts.drivers.api.url"];    
            _server = WebApp.Start<Startup>(url: _baseAddress);

            Log.Logger.Information($"Server running at {_baseAddress}");
        }

        public void Shutdown()
        {
            Log.Logger.Information("ServiceHost shutting down");

        }

        public void Stop()
        {
            Log.Logger.Information("Server shutting down");

            _server.Dispose();

            Log.Logger.Information("ServiceHost stopped");
        }
    }
}
