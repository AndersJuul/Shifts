using System;
using System.Web.Http;

namespace Shifts.Drivers.Web.Lib.Controllers
{
    [RoutePrefix("drivers")]
    public class DriversController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(DateTimeOffset.Now);
        }
    }
}