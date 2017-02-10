using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            var connectionString = ConfigurationManager.ConnectionStrings["shiftDriversDb"].ConnectionString;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //var content = db.Query<Driver>("Select * From Drivers").ToList();
                var content = new[] {new Driver {id = 1, name = "Anders"}, new Driver {id = 2, name = "Per"}};
                return Ok(content);
            }
        }
    }
}