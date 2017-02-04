using System.Web.Http;
using Shifts.Drivers.Contracts;

namespace Shifts.Drivers.Web.Lib.Controllers
{
    //[RoutePrefix("drivers")]
    [Route("drivers")]
    public class DriversController : ApiController
    {
        public IHttpActionResult Get()
        {
            var arr = new[] {new Driver {id = 1, name = "Anders"}};

            return Ok(arr);
        }
    }
}