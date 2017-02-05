using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json;
using Shifts.Drivers.Contracts;

namespace WebApplication1.Controllers
{
    public class DriversController : ApiController
    {
        public Driver[] Get()
        {
            var urlString = ConfigurationManager.AppSettings["shifts.drivers.api.url"] + "/api/drivers";
            
            var request = (HttpWebRequest) WebRequest.Create(urlString);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (var response = (HttpWebResponse) request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var readToEnd = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<Driver[]>(readToEnd);
                    }
                }
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}