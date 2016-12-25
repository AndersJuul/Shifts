using System;
using Microsoft.Owin.Hosting;

namespace Shifts.Cars.Web.Lib
{
    public class ServiceHost
    {
        // Create the variable for our self-hosted server
        //
        private IDisposable _server;

        // Just hard-code the address for now
        //
        private string _baseAddress = "http://localhost:7331";

        public ServiceHost()
        {
            Console.WriteLine("ServiceHost constructed");
        }

        public void Start()
        {
            Console.WriteLine("ServiceHost started");

            // Start up the server by providing our OWIN Startup class as the source type.
            //  We also save the return object so we can dispose of it properly when the
            //  service is shutdown
            //
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

            // Dispose of the server object since we're shutting everything down
            //
            _server.Dispose();

            Console.WriteLine("ServiceHost stopped");
        }
    }
}
