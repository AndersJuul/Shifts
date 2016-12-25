using System;
using System.Web.Http;

namespace Shifts.Drivers.Web.Lib.Controllers
{
    [RoutePrefix("time")]
    public class TimeController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(DateTimeOffset.Now);
        }
    }
}