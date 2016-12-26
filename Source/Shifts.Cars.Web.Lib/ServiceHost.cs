using System;
using System.Configuration;
using Microsoft.Owin.Hosting;
using Serilog;

namespace Shifts.Cars.Web.Lib
{
    public class ServiceHost
    {
        private IDisposable _server;

        private string _baseAddress ;

        public void Start()
        {
            Log.Logger.Information("ServiceHost starting");

            _baseAddress = ConfigurationManager.AppSettings["shifts.cars.api.url"];    
            //_server = WebApp.Start<Startup>(url: _baseAddress);

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
