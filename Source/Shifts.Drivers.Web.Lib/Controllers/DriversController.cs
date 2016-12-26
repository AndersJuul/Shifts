using System;
using System.Web.Http;
using Shifts.Drivers.Contracts;

namespace Shifts.Drivers.Web.Lib.Controllers
{
    [RoutePrefix("drivers")]
    public class DriversController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new Driver());
        }
    }
}