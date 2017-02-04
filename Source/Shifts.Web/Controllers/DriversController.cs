using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using Shifts.Drivers.Contracts;

namespace WebApplication1.Controllers
{
    public class DriversController : ApiController
    {
        // GET api/values
        public Driver[] Get()
        {
            var urlString = ConfigurationManager.AppSettings["shifts.drivers.api.url"] + "/api/drivers";




            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlString);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<Driver[]>(html);
            //return html;

            //return new[]
            //{
            //    new
            //    {
            //        id = 1,
            //        date=DateTime.Today,
            //        name = "A"
            //    },
            //    new
            //    {
            //        id = 2,
            //        date=DateTime.Today,
            //        name = "B"
            //    }
            //};
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