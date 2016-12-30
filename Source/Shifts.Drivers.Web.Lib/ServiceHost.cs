using System;
using System.Configuration;
using Microsoft.Owin.Hosting;
using Serilog;

namespace Shifts.Drivers.Web.Lib
{
    public class ServiceHost
    {
        private string _baseAddress;
        private IDisposable _server;

        public void Start()
        {
            Log.Logger.Information("ServiceHost starting");

            _baseAddress = ConfigurationManager.AppSettings["shifts.drivers.api.url"];
            _server = WebApp.Start<Startup>(_baseAddress);

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