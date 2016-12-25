using System;
using System.Web.Http;

namespace Shifts.Cars.Web.Lib.Controllers
{
    [RoutePrefix("cars")]
    public class CarsController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(DateTimeOffset.Now);
        }
    }
}